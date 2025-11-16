<?php

namespace controllers;

use utils\Template;
use models\EleveModel;
use models\InscrireModel;
use utils\SessionHelpers;
use controllers\base\WebController;
use models\ConduireModel;

class CompteController extends WebController
{
    private EleveModel $eleveModel;
    private InscrireModel $inscrireModel;
    private ConduireModel $conduireModel;

    public function __construct()
    {
        $this->eleveModel = new EleveModel();
        $this->inscrireModel = new InscrireModel();
        $this->conduireModel = new ConduireModel();
    }

    /**
     * Affiche le compte utilisateur.
     *
     * @return string
     */
    public function monCompte()
    {
        $this->redirect('/mon-compte/planning.html');
    }

    public function mesInformations(): string
    {
        if (!$this->isPost()) {
            SessionHelpers::generateCsrfToken();
        }

         // --- Traitement du formulaire de mise à jour des informations ---

        if ($this->isPost()) {
            
            // --- Vérification du token CSRF ---
            // Est ce nécessaire de verifier le token CSRF ici ?
            
            $csrfToken = $_POST['csrf_token'] ?? '';
            if (!SessionHelpers::verifyCsrfToken($csrfToken)) {
                SessionHelpers::setFlashMessage('error', 'Jeton CSRF invalide. Veuillez réessayer.');
                $this->redirect('/mon-compte/profil.html');
            }

            // Traitement de la mise à jour des informations de l'utilisateur

            // Définition : on récupère les informations actuelles de l'utilisateur connecté,
            // Puis on met à jour les champs avec les nouvelles valeurs soumises via le formulaire.
            $eleve = $this->eleveModel->getMe();
            if (!$eleve) {
                SessionHelpers::setFlashMessage('error', 'Utilisateur non trouvé. Veuillez vous reconnecter.');
                $this->redirect('/mon-compte/connexion.html');
            }

            // Récupération des données du formulaire

            $nom = $_POST['nom'] ?? null;
            $prenom = $_POST['prenom'] ?? null;
            $email = trim($_POST['email'] ?? null); $email = filter_var($email, FILTER_SANITIZE_EMAIL);
            $dateNaissance = trim($_POST['datenaissance'] ?? null);
            
            // Récupération du téléphone (facultatif)
            $telephone = trim($_POST['telephone'] ?? null);

            // ------ AJOUT DES VERIFICATIONS DES CHAMPS EN LIEN AVEC LE TRAITEMENT DE LA MISE A JOUR DES INFORMATIONS DE L'ÉLÈVE ------

            // Validation des champs (vérification que tous les champs sont remplis, sauf le numéro de téléphone facultatif). ---
            if (empty($nom) || empty($prenom) || empty($email) || empty($dateNaissance)) {
                SessionHelpers::setFlashMessage('error', 'Tous les champs sont requis.');
                $this->redirect('/mon-compte/profil.html');
            }

            // Vérification du nom
            if (!preg_match('/^(?=.{2,50}$)[A-Za-zÀ-ÖØ-öø-ÿ]+([ \'-][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/u', $nom)) {
                SessionHelpers::setFlashMessage('error', 'Le nom est invalide et doit contenir entre 2 et 50 caractères.');
                $this->redirect('/mon-compte/profil.html');
            }

            // Vérification du prénom
            if (!preg_match('/^(?=.{2,50}$)[A-Za-zÀ-ÖØ-öø-ÿ]+([ \'-][A-Za-zÀ-ÖØ-öø-ÿ]+)*$/u', $prenom)) {
                SessionHelpers::setFlashMessage('error', 'Le prénom est invalide et doit contenir entre 2 et 50 caractères.');
                $this->redirect('/mon-compte/profil.html');
            }

            // VÉRIFICATION DE L'EMAIL
            // 1- Utilisation de filter_var pour valider l'email
            if (!filter_var($email, FILTER_VALIDATE_EMAIL)) {
                SessionHelpers::setFlashMessage('error', "L'adresse email est invalide.");
                $this->redirect('/mon-compte/profil.html');
            }
            // 2- Vérification de l'unicité de l'email (sauf si c'est l'email actuel de l'utilisateur)
            $existingUser = $this->eleveModel->getByEmail($email);
            if ($existingUser && $existingUser['ideleve'] !== $eleve['ideleve']) {
                SessionHelpers::setFlashMessage('error', "L'adresse email est déjà utilisée par un autre compte.");
                $this->redirect('/mon-compte/profil.html');
            }        

            // Vérification du téléphone (facultatif)
            if (!empty($telephone) && !preg_match('/^[0-9]{10}$/', $telephone)) {
                SessionHelpers::setFlashMessage('error', 'Le numéro de téléphone est invalide et doit contenir 10 chiffres.');
                $this->redirect('/mon-compte/profil.html');
            }

            // Vérification de la date de naissance
            if (!preg_match('/^\d{4}-\d{2}-\d{2}$/', $dateNaissance)) {
                SessionHelpers::setFlashMessage('error', 'La date de naissance est invalide et doit être au format AAAA-MM-JJ.');
                $this->redirect('/mon-compte/profil.html');
            }
            $birthDate = new \DateTime($dateNaissance);
            $today = new \DateTime();
            $year = (int)$birthDate->format('Y');
            $currentYear = (int) $today->format('Y');

            if ($year < 1900 || $year > $currentYear) {
                SessionHelpers::setFlashMessage('error', 'L\'année de naissance doit être comprise entre 1900 et l\'année en cours.');
                $this->redirect('/mon-compte/profil.html');
            }

            $age = $today->diff($birthDate)->y;
            if ($age < 15) {
                SessionHelpers::setFlashMessage('error', 'Vous devez avoir au moins 15 ans.');
                $this->redirect('/mon-compte/profil.html');
            }

            // --- BONUS INTERMEDIAIRE -- GESTION DU CHANGEMENT DE MOT DE PASSE (FACULTATIF) PAR RAPPORT AU MOT DE PASSE ACTUEL ---

            $newPassword = $_POST['new_password'] ?? null;
            $confirmNewPassword = $_POST['confirm_new_password'] ?? null;
            $currentPassword = $_POST['current_password'] ?? null;

            if (!empty($newPassword) || !empty($confirmNewPassword)) {
                // Si l'utilisateur souhaite changer son mot de passe, le mot de passe actuel est requis
                if (empty($currentPassword)) {
                    SessionHelpers::setFlashMessage('error', 'Le mot de passe actuel est requis pour changer le mot de passe.');
                    $this->redirect('/mon-compte/profil.html');
                }

                // VERIFICATION DU MOT DE PASSE ACTUEL
                $eleve = $this->eleveModel->getMe();
                if (!$eleve || !password_verify($currentPassword, $eleve['motpasseeleve'])) {
                    SessionHelpers::setFlashMessage('error', 'Le mot de passe actuel est incorrect.');
                    $this->redirect('/mon-compte/profil.html');
                }

                // LE NOUVEAU MOT DE PASSE DOIT ÊTRE DIFFÉRENT DE L'ANCIEN
                if ($currentPassword === $newPassword) {
                    SessionHelpers::setFlashMessage('error', 'Le nouveau mot de passe doit être différent de l\'ancien.');
                    $this->redirect('/mon-compte/profil.html');
                }

                // VERIFICATION QUE LES NOUVEAUX MOTS DE PASSE CORRESPONDENT
                if ($newPassword !== $confirmNewPassword) {
                    SessionHelpers::setFlashMessage('error', 'Les nouveaux mots de passe ne correspondent pas.');
                    $this->redirect('/mon-compte/profil.html');
                }

                // AJOUT DE RÈGLES DE VALIDATION SUPPLÉMENTAIRES POUR LE NOUVEAU MOT DE PASSE ICI (LONGUEUR, COMPLEXITÉ, ETC.)
                // Exemple : au moins 8 caractères, une majuscule, une minuscule, un chiffre et un caractère spécial
                
                if (strlen($newPassword) < 8) {
                    SessionHelpers::setFlashMessage('error', 'Le nouveau mot de passe doit contenir au moins 8 caractères.');
                    $this->redirect('/mon-compte/profil.html');
                }

                if (!preg_match('/[A-Z]/', $newPassword)) {
                    SessionHelpers::setFlashMessage('error', 'Le nouveau mot de passe doit contenir au moins une lettre majuscule.');
                    $this->redirect('/mon-compte/profil.html');
                }
                if (!preg_match('/[a-z]/', $newPassword)) {
                    SessionHelpers::setFlashMessage('error', 'Le nouveau mot de passe doit contenir au moins une lettre minuscule.');
                    $this->redirect('/mon-compte/profil.html');
                }
                if (!preg_match('/[0-9]/', $newPassword)) {
                    SessionHelpers::setFlashMessage('error', 'Le nouveau mot de passe doit contenir au moins un chiffre.');
                    $this->redirect('/mon-compte/profil.html');
                }
                if (!preg_match('/[\W]/', $newPassword)) {
                    SessionHelpers::setFlashMessage('error', 'Le nouveau mot de passe doit contenir au moins un caractère spécial.');
                    $this->redirect('/mon-compte/profil.html');
                }
                
                // Toutes les validations sont passées, on peut procéder à la mise à jour du mot de passe.
                $success = $this->eleveModel->updatePassword(SessionHelpers::getConnected()['ideleve'], $newPassword);
                if (!$success) {
                    SessionHelpers::setFlashMessage('error', "Une erreur est survenue lors de la mise à jour de votre mot de passe.");
                    $this->redirect('/mon-compte/profil.html');
                }
                else {
                    SessionHelpers::setFlashMessage('success', 'Mot de passe changé avec succès. Vous serez redirigé vers la page de connexion.');
                    SessionHelpers::invalidateCsrfToken();
                    SessionHelpers::clearSession();
                    SessionHelpers::logout();
                    header('Refresh: 5; URL=/connexion.html');
                    exit();
                }
            }
            
            // --- FIN DU BONUS DE CHANGEMENT DE PASSE ---
            
            // Mise à jour des informations de l'utilisateur dans la base de données
            $success = $this->eleveModel->update(
                SessionHelpers::getConnected()['ideleve'],
                $nom,
                $prenom,
                $email,
                $dateNaissance,
                $telephone // Ajout du téléphone dans la mise à jour -- LOT 1 --
            );

            if ($success) {
                SessionHelpers::setFlashMessage('success', 'Vos informations ont été mises à jour avec succès.');
                $this->redirect('/mon-compte/profil.html');
                exit;
            } else {
                SessionHelpers::setFlashMessage('error', "Une erreur est survenue lors de la mise à jour de vos informations.");
                $this->redirect('/mon-compte/profil.html');
                exit;
            }
        }

        $eleveData = $this->eleveModel->getMe() ?: [];

        return template::render(
            "views/utilisateur/compte/mes-informations.php",
            array_merge(
            [
                'titre' => 'Mes informations',
                'error' => SessionHelpers::getFlashMessage('error'),
                'success' => SessionHelpers::getFlashMessage('success'),
            ], $eleveData)

            // eleveDate : Ajoute l'ensemble des informations de l'utilisateur connecté
            // (concatène les données de l'utilisateur connecté + les données de la vue, résultat un tableau associatif)
        );
    }

    /**
     * Affiche le planning de l'utilisateur connecté.
     */
    public function planning(): string
    {
        // Récupération du forfait de l'utilisateur connecté
        $forfait = $this->inscrireModel->getForfaitEleveConnecte();

        // Récupération du planning de l'utilisateur connecté (modèle conduire)
        $planning = $this->conduireModel->getLessonsByEleve();

        return Template::render(
            "views/utilisateur/compte/planning.php",
            [
                'titre' => 'Mon planning',
                'forfait' => $forfait,
                'planning' => $planning,
                'eleve' => SessionHelpers::getConnected(),
                'error' => SessionHelpers::getFlashMessage('error'),
                'success' => SessionHelpers::getFlashMessage('success')
            ]
        );
    }

    /**
     * Déconnecte l'utilisateur.
     *
     * @return void
     */
    public function deconnexion(): void
    {
        SessionHelpers::clearSession();

        // Déconnexion de l'utilisateur
        SessionHelpers::logout();
        $this->redirect('/');
    }

    /**
     * Supprime le compte de l'utilisateur connecté en lien avec son email.
     * LOT 1
     * @return void
     */
    public function supprimerCompte(): void
    {
        $eleve = $this->eleveModel->getMe();
        if (!$eleve) {
            SessionHelpers::setFlashMessage('error', 'Utilisateur non trouvé. Veuillez vous reconnecter.');
            $this->redirect('/mon-compte/connexion.html');
        }

        $success = $this->eleveModel->deleteByEmail($eleve['emaileleve']);
        if ($success) {
            SessionHelpers::setFlashMessage('success', 'Votre compte a été supprimé avec succès.');
            SessionHelpers::clearSession();
            SessionHelpers::logout();
            $this->redirect('/');
        } else {
            SessionHelpers::setFlashMessage('error', "Une erreur est survenue lors de la suppression de votre compte.");
            $this->redirect('/mon-compte/profil.html');
        }
    }
}