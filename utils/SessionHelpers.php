<?php


namespace utils;


class SessionHelpers
{
    public function __construct()
    {
        SessionHelpers::init();
    }

    static function setFlashMessage(string $key, mixed $value): void
    {
        $_SESSION['FLASH'][$key] = $value;
    }

    static function getFlashMessage(string $key): mixed
    {
        if (isset($_SESSION['FLASH'][$key])) {
            $value = $_SESSION['FLASH'][$key];
            unset($_SESSION['FLASH'][$key]); // Supprimer le message après l'avoir récupéré
            return $value;
        }

        return null; // Retourne null si le message n'existe pas
    }

    static function init(): void
    {
        session_start();
    }

    static function login(mixed $equipe): void
    {
        $_SESSION['LOGIN'] = $equipe;
    }

    static function logout(): void
    {
        unset($_SESSION['LOGIN']);
        session_regenerate_id(true); // Pour éviter les attaques de fixation de session.
    }

    static function getConnected(): mixed
    {
        if (SessionHelpers::isLogin()) {
            return $_SESSION['LOGIN'];
        } else {
            return array();
        }
    }

    static function isLogin(): bool
    {
        self::ensureSessionStarted();
        return isset($_SESSION['LOGIN']);
    }


    // Méthode pour vérifier le timeout de session

    public static function checkSessionTimeout(): void
    {
        self::ensureSessionStarted();

        // ⛔ Ne rien faire si personne n'est connecté (évite expired=1 sur /connexion.html)
        if (!self::isLogin()) {
            return;
        }

        $TempsLimiteInactivité = (int) 36000;
        $DureeSessionServeur = (int) 3600;
        $DureeMaxSession = (int) 172800;
        
        // BLOC POUR LE TIMEOUT D'INACTIVITE

        // Initialise le timestamp de la dernière activité si non défini
        if (!isset($_SESSION['LAST_ACTIVITY'])) {
            $_SESSION['LAST_ACTIVITY'] = time();
        }

        // Vérifie le timeout d'inactivité
        if ((time() - $_SESSION['LAST_ACTIVITY']) > $TempsLimiteInactivité) {
            self::clearSession();
            header("Location: /connexion.html?expired=1");
            exit;
        }
        /* ------------------------------------------------------------------------- */
        // BLOC POUR LA REGENERATION PERIODIQUE DE L'ID DE SESSION

        // Regénération périodique de l'ID de session pour plus de sécurité
        if (!isset($_SESSION['CREATED'])) {
            $_SESSION['CREATED'] = time();
        } elseif ((time() - $_SESSION['CREATED']) > $DureeSessionServeur) {
            session_regenerate_id(true);
            $_SESSION['CREATED'] = time();
        }

        /* ------------------------------------------------------------------------- */

        // BLOC POUR LA DUREE TOTALE DE LA SESSION
        if (!isset($_SESSION['SESSION_START_TIME'])) {
            $_SESSION['SESSION_START_TIME'] = time();
        }

        // Vérifie la durée totale de la session (temps maximal avant expiration)
        if ((time() - $_SESSION['SESSION_START_TIME']) > $DureeMaxSession) {
            self::clearSession();
            SessionHelpers::setFlashMessage('error', 'Votre session a expiré après une durée maximale. Veuillez vous reconnecter.');
            header("Location: /connexion.html?expired=max");
            exit;
        }

        /* ------------------------------------------------------------------------- */         

        // Met à jour le timestamp de la dernière activité
        $_SESSION['LAST_ACTIVITY'] = time();
    }


    // Méthodes pour gérer le forfait sélectionné par l'utilisateur avant la connexion
    static function saveSelectedForfait(int $idForfait): void
    {
        $_SESSION['SELECTED_FORFAIT'] = $idForfait;
    }


    static function getSelectedForfait(): ?int
    {
        $selectedForfait = $_SESSION['SELECTED_FORFAIT'] ?? null;
        unset($_SESSION['SELECTED_FORFAIT']); // Suppression du forfait sélectionné après récupération
        return $selectedForfait;
    }


    static function hasSelectedForfait(): bool
    {
        return isset($_SESSION['SELECTED_FORFAIT']);
    }

    
    // Méthode pour s'assurer qu'une sesssion a été démarré
    public static function ensureSessionStarted(): void
    {
        if (session_status() === PHP_SESSION_NONE) {
            session_start();
        }
    }


    public static function generateCsrfToken(): string
    {
        self::ensureSessionStarted(); // Assure que la session est démarrée
        $token = bin2hex(random_bytes(32)); // Génère un token aléatoire sécurisé
        $_SESSION['csrf_token'] = $token; // Stocke le token en session.
        $_SESSION['csrf_token_time'] = time(); // Stocke le temps de création du token (optionnel)
        return $_SESSION['csrf_token'];
    }


    // Méthode de vérification du token CSRF, c'est-à-dire qu'on compare
    // le token reçu avec celui stocké en session.
    
    public static function verifyCsrfToken(string $token): bool
    {
        self::ensureSessionStarted(); // Assure que la session est démarrée

        // Vérifie la présence du token dans la session et le POST
        if (empty($_SESSION['csrf_token']) || empty($token)) {
            error_log('[SECURITY] CSRF manquant ou vide.'); // log côté serveur
            SessionHelpers::setFlashMessage('error', 'Token CSRF manquant ou vide.');
            return false;
        }

        // Vérifie la durée de validité (ex : 14 min).
        if (isset($_SESSION['csrf_token_time']) && time() - $_SESSION['csrf_token_time'] > 840) {
            error_log('[SECURITY] CSRF expiré (plus de 14 minutes).');
            unset($_SESSION['csrf_token']); // Supprime le token expiré de la session.
            unset($_SESSION['csrf_token_time']);
            SessionHelpers::setFlashMessage('error', 'Le token CSRF a expiré. Veuillez réessayer.');
            return false;
        }

        // Compare les deux tokens de façon sécurisée (contre timing attacks)
        $isValid = hash_equals($_SESSION['csrf_token'], $token);

        if (!$isValid) {
            error_log('[SECURITY] Jeton CSRF invalide : tentative d\'attaque possible.');

        }

        // 🔁 Si invalide, régénère immédiatement un nouveau token pour la prochaine requête
        if (!$isValid) {
            $_SESSION['csrf_token'] = bin2hex(random_bytes(32));
            $_SESSION['csrf_token_time'] = time();
        }
        return $isValid;
    }


    // Supprime le token après validation
    public static function invalidateCsrfToken(): void
    {
        self::ensureSessionStarted();
        unset($_SESSION['csrf_token'], $_SESSION['csrf_token_time']);
        // Supprime le token et son temps de création de la session pour éviter toute réutilisation.
    }


    // Méthode pour vider complètement la session, c'est-à-dire supprimer toutes les données de session
    // associées à l'utilisateur, y compris les cookies de session si nécessaire.

    public static function clearSession(): void
    {
        self::ensureSessionStarted();
        $_SESSION = []; // Vide le tableau de session

        // Détruit le cookie de session si nécessaire
        if (ini_get("session.use_cookies")) {
            $params = session_get_cookie_params();
            setcookie(session_name(), '', time() - 42000, // Et donc ici 42000 secondes dans le passé, soit 70 minutes.
                $params["path"], $params["domain"],
                $params["secure"], $params["httponly"]
            );
        }
        session_destroy(); // Détruit la session
    }


    public static function getFailedLoginAttempts(): int
    {
        self::ensureSessionStarted();
        return $_SESSION['FAILED_LOGIN_ATTEMPTS'] ?? 0;
    }


    public static function incrementFailedLoginAttempts(): void
    {
        self::ensureSessionStarted();
        if (!isset($_SESSION['FAILED_LOGIN_ATTEMPTS'])) {
            $_SESSION['FAILED_LOGIN_ATTEMPTS'] = 0;
        }
        $_SESSION['FAILED_LOGIN_ATTEMPTS']++;
    }

}
