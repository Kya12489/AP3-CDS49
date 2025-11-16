<?php

namespace controllers;

use utils\Template;
use models\EleveModel;
use models\InscrireModel;
use utils\SessionHelpers;
use controllers\base\WebController;
use models\ForfaitModel;

class UtilisateurController extends WebController
{
    private EleveModel $eleveModel;
    private ForfaitModel $forfaitModel;

    function __construct()
    {
        $this->eleveModel = new EleveModel();
        $this->forfaitModel = new ForfaitModel();
    }

    /**
     * Affiche le formulaire de création de compte et gère la soumission du formulaire.
     *
     * @return string
     */
    public function creerCompte(): string
    {
        // Si l'utilisateur est déjà connecté, redirige vers la page de compte.
        if (SessionHelpers::isLogin()) {
            $this->redirect('/mon-compte/');
        }

        // Génération d'un token CSRF pour la sécurité quand on affiche le formulaire.
        // Concrètement, on génère une chaîne aléatoire unique et on la stocke dans la
        // session utilisateur pour la comparer lors de la soumission du formulaire.

       if(!$this->isPost()) {
           SessionHelpers::generateCsrfToken();
       }

       // Et ici ?
       // Cette condition vérifie si la requête est de type POST, ce qui signifie que l'utilisateur a soumis le formulaire. Dans ce cas, on traite les données envoyées.
        if ($this->isPost()) {
            $csrfToken = $_POST['csrf_token'] ?? '';

            // Vérification du token CSRF pour prévenir les attaques CSRF.
            if (!SessionHelpers::verifyCsrfToken($csrfToken)) {
                SessionHelpers::setFlashMessage('error', 'Token CSRF invalide. Réessayez.');
                $this->redirect('/creer-compte.html');
            }
            
            // Récupération et traitement des données du formulaire.
            $nom = $_POST['nom'] ?? null;
            $prenom = $_POST['prenom'] ?? null;
            $email = trim($_POST['email'] ?? null); $email = filter_var($email, FILTER_SANITIZE_EMAIL);
            $telephone = trim($_POST['telephone'] ?? null);
            $password = $_POST['password'] ?? null;
            $confirmPassword = $_POST['confirm_password'] ?? null;
            $dateNaissance = trim($_POST['date_naissance'] ?? null);

            // --- Validation des champs (vérification que tous les champs sont remplis, sauf le numéro de téléphone facultatif). ---

            if (empty($nom) || empty($prenom) || empty($email) || empty($password) || empty($confirmPassword) || empty($dateNaissance)) {
                SessionHelpers::setFlashMessage('error', 'Tous les champs sont requis.');
                $this->redirect('/creer-compte.html');
            }

            // --- Vérifications individuelles des champs ---

            // Vérification du nom
            if (!preg_match("/^(?=.{2,50}$)[A-Za-zÀ-ÖØ-öø-ÿ]+([ '-][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/u", $nom)) {
                SessionHelpers::setFlashMessage('error', 'Le nom est invalide et doit contenir entre 2 et 50 caractères.');
                $this->redirect('/creer-compte.html');
            }

            // Vérification du prénom
            if (!preg_match("/^(?=.{2,50}$)[A-Za-zÀ-ÖØ-öø-ÿ]+([ '-][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/u", $prenom)) {
                SessionHelpers::setFlashMessage('error', 'Le prénom est invalide et doit contenir entre 2 et 50 caractères.');
                $this->redirect('/creer-compte.html');
            }

            // Vérification de l'email
            // 1- Utilisation de filter_var pour valider l'email
            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                SessionHelpers::setFlashMessage('error', "L'adresse email est invalide.");
                $this->redirect('/creer-compte.html');
            }
            // 2- Vérification de l'unicité de l'email
            $existingUser = $this->eleveModel->existsByEmail($email);
            if ($existingUser) {
                SessionHelpers::setFlashMessage('error', "L'adresse email saisie est déjà utilisée par un autre utilisateur.");
                $this->redirect('/creer-compte.html');
            }
            
            // Vérification du téléphone (si fourni)
            if (!empty($telephone) && !preg_match('/^[0-9]{10}$/', $telephone)) {
                SessionHelpers::setFlashMessage('error', 'Le numéro de téléphone est invalide et doit contenir 10 chiffres.');
                $this->redirect('/creer-compte.html');
            }

            // Vérification de la date de naissance (au moins 15 ans)
            if (!preg_match('/^\d{4}-\d{2}-\d{2}$/', $dateNaissance)) {
                SessionHelpers::setFlashMessage('error', 'La date de naissance doit être au format AAAA-MM-JJ.');
                $this->redirect('/creer-compte.html');
            }
            $today = new \DateTime();
            $birthDate = new \DateTime($dateNaissance);
            $year = (int)$birthDate->format('Y');
            $currentYear = (int) $today->format('Y');

            if ($year < 1900 || $year > $currentYear) {
                SessionHelpers::setFlashMessage('error', 'Veuillez entrer une date de naissance valide entre 1900 et aujourd\'hui.');
                $this->redirect('/creer-compte.html');
            }
            
            $age = $today->diff($birthDate)->y;
            if ($age < 15) {
                SessionHelpers::setFlashMessage('error', 'Vous devez avoir au moins 15 ans pour créer un compte.');
                $this->redirect('/creer-compte.html');
            }

            // Vérification du mot de passe (au moins 8 caractères)
            
            // 1- Vérification de la longueur
            if (strlen($password) < 8) {
                SessionHelpers::setFlashMessage('error', 'Le mot de passe doit contenir au moins 8 caractères.');
                $this->redirect('/creer-compte.html');
            }
            // 2- Vérification majuscule.
            if (!preg_match('/[A-Z]/', $password)) {
                SessionHelpers::setFlashMessage('error', 'Le mot de passe doit contenir au moins une majuscule.');
                $this->redirect('/creer-compte.html');
            }
            // 3- Vérification minuscule.
            if (!preg_match('/[a-z]/', $password)) {
                SessionHelpers::setFlashMessage('error', 'Le mot de passe doit contenir au moins une minuscule.');
                $this->redirect('/creer-compte.html');
            }
            // 4- Vérification chiffre.
            if (!preg_match('/[0-9]/', $password)) {
                SessionHelpers::setFlashMessage('error', 'Le mot de passe doit contenir au moins un chiffre.');
                $this->redirect('/creer-compte.html');
            }
            // 5- Vérification caractère spécial.
            if (!preg_match('/[!@#$%^&*(),.?":{}|<>]/', $password)) {
                SessionHelpers::setFlashMessage('error', 'Le mot de passe doit contenir au moins un caractère spécial.');
                $this->redirect('/creer-compte.html');
            }
            
            // Vérification de la correspondance des mots de passe
            if ($password !== $confirmPassword) {
                SessionHelpers::setFlashMessage('error', 'Les mots de passe ne correspondent pas.');
            } else {
                // Création de l'élève dans la base de données (en utilisant le modèle EleveModel) --- LOT 1 ---
                $success = $this->eleveModel->creer_eleve($nom, $prenom, $email, $password, $dateNaissance, $telephone);

                if ($success) {
                    $message = "Compte créé avec succès.\nVous pouvez maintenant vous connecter.";
                    SessionHelpers::setFlashMessage('success', $message);
                    SessionHelpers::invalidateCsrfToken(); // Supprime le token CSRF après une création de compte réussie.
                    $this->redirect('/connexion.html');
                } else {
                    SessionHelpers::setFlashMessage('error', "L'adresse email est déjà utilisée ou une erreur est survenue.");
                    $this->redirect('/creer-compte.html');
                }
            }
            // Rediriger vers la page de création de compte pour afficher le message d'erreur ou si la création a échoué
            $this->redirect('/creer-compte.html');
        }

        return Template::render(
            "views/utilisateur/creer-compte.php",
            [
                'titre' => 'Créer un compte',
                'error' => SessionHelpers::getFlashMessage('error'),
                'success' => SessionHelpers::getFlashMessage('success')
            ]
        );
    }

    /**
     * Affiche le formulaire de connexion.
     *
     * @return string
     */
    public function connexion(): string
    {
        // Si l'utilisateur est déjà connecté, redirige vers la page de compte.
        if (SessionHelpers::isLogin()) {
            $this->redirect('/mon-compte/');
        }
        
        if(!$this->isPost()) {
            SessionHelpers::generateCsrfToken();
        }

        // Détecte une expiration de session via ?expired=...
        $expiredMessage = null;
        if (isset($_GET['expired'])) {
            switch ($_GET['expired']) {
                case '1':
                    $expiredMessage = 'Votre session a expiré après une période d\'inactivité. Veuillez vous reconnecter.';
                    break;
                case 'max':
                    $expiredMessage = 'Votre session a expiré après une durée maximale. Veuillez vous reconnecter.';
                    break;
                default:
                    $expiredMessage = null;
                    break;
            }
        }
        
        // Si la requête est de type POST, traite la soumission du formulaire.
        if ($this->isPost()) {

            $csrfToken = $_POST['csrf_token'] ?? '';

            // Vérification du token CSRF pour prévenir les attaques CSRF.
            if (!SessionHelpers::verifyCsrfToken($csrfToken)) {
                SessionHelpers::setFlashMessage('error', 'Token CSRF invalide ou expiré. Réessayez.');
                $this->redirect('/connexion.html');
            }

            // Récupération et traitement des données du formulaire.
            $email = trim($_POST['email'] ?? ''); $email = filter_var($email, FILTER_SANITIZE_EMAIL);
            $password = $_POST['password'] ?? '';

            // --- VALIDATION DES CHAMPS ---

            if (empty($email) || empty($password)) {
                SessionHelpers::setFlashMessage('error', 'Tous les champs sont requis.');
                $this->redirect('/connexion.html');
            }
            if(!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                SessionHelpers::setFlashMessage('error', "L'adresse email est invalide.");
                $this->redirect('/connexion.html');
            }            
            
            // Vérification des identifiants de l'utilisateur (en utilisant le modèle EleveModel).
            $eleve = $this->eleveModel->connexion($email, $password);

            if ($eleve) {
                // Si les identifiants sont corrects, on enregistre les informations de l'utilisateur en session.
                SessionHelpers::login($eleve);
                SessionHelpers::invalidateCsrfToken(); // Supprime le token CSRF après une connexion réussie.
                $this->redirect('/mon-compte/');
            } else {
                SessionHelpers::setFlashMessage('error', 'Identifiants incorrects.');
                $this->redirect('/connexion.html');
            }
        }

        return Template::render("views/utilisateur/connexion.php", [
            'titre' => 'Connexion',
            'error' => SessionHelpers::getFlashMessage('error'),
            'success' => SessionHelpers::getFlashMessage('success'),
            'expiredMessage' => $expiredMessage // Message d'expiration de session, s'il y en a un. On l'affiche dans la vue.
        ]);
    }

    /**
     * Affiche le formulaire de mot de passe oublié.
     *
     * @return string
     */
    public function motDePasseOublie(): string
    {
        if ($this->isPost()) {
            // TODO: Implémenter la logique de réinitialisation du mot de passe.
            // La réinitialisation va se dérouler en plusieurs étapes :
            // 1. L'utilisateur entre son adresse email.
            // 2. Un email de réinitialisation est envoyé avec un lien unique. (à implémenter, implique la création d'un token de réinitialisation à stocker en base de données. Un token est un identifiant UUID associé à l'utilisateur, avec une date d'expiration.)
            // 3. L'utilisateur clique sur le lien et est redirigé vers un formulaire pour entrer un nouveau mot de passe. (à implémenter, création d'une page + récupération du token de réinitialisation)
            // 4. Le mot de passe est mis à jour dans la base de données. (à implémenter)
        }

        return Template::render(
            "views/utilisateur/mot-de-passe-oublie.php",
            [
                'titre' => 'Mot de passe oublié',
                'error' => SessionHelpers::getFlashMessage('error'),
                'success' => SessionHelpers::getFlashMessage('success')
            ]
        );
    }

    /**
     * Code d'activation d'une offre.
     * Cette méthode permet à l'utilisateur d'activer l'offre choisi (passage de paramètre dans l'URL).
     */
    public function activerOffre(): string
    {
        $idForfait = $_GET['idforfait'] ?? null;

        $forfait = $this->forfaitModel->getById($idForfait);

        if (!$forfait) {
            $this->redirect('/forfaits.html');
        }

        return Template::render(
            "views/utilisateur/activer-offre.php",
            [
                'titre' => 'Activer une offre',
                'error' => SessionHelpers::getFlashMessage('error'),
                'success' => SessionHelpers::getFlashMessage('success')
            ]
        );
    }
}