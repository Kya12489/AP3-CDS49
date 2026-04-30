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
    public function monCompte(): string
    {
        $this->redirect('/mon-compte/planning.html');
    }

    public function mesInformations(): string
    {
        if ($this->isPost()) {
            // Traitement de la mise à jour des informations de l'utilisateur
            $nom = $_POST['nom'] ?? null;
            $prenom = $_POST['prenom'] ?? null;
            $email = $_POST['email'] ?? null;
            $dateNaissance = $_POST['datenaissance'] ?? null;

            // ------ AJOUT DU CHAMP TELEPHONE DANS LE TRAITEMENT DE LA MISE A JOUR DES INFORMATIONS -- LOT 1 --
            
            // Récupération du téléphone (facultatif)
            $telephone = $_POST['telephone'] ?? null;
            // Vous pouvez ajouter une validation supplémentaire pour le téléphone si nécessaire
            if ( !empty($telephone) && !preg_match('/^[0-9]{10}$/', $telephone) ) {
                SessionHelpers::setFlashMessage('error', 'Le numéro de téléphone doit contenir exactement 10 chiffres.');
                $this->redirect('/mon-compte/profil.html');
            }
            // ------ FIN DU CHAMP TELEPHONE LOT 1 ------


            // Validation des données (exemple simple, à adapter selon les besoins)
            if (empty($nom) || empty($prenom) || empty($email) || empty($dateNaissance)) {
                SessionHelpers::setFlashMessage('error', 'Tous les champs sont requis.');
                $this->redirect('/mon-compte/profil.html');
            }

            // --- BONUS -- Gestion du changement de mot de passe (facultatif) par rapport au mot de passe actuel ---
            $newPassword = $_POST['new_password'] ?? null;
            $confirmNewPassword = $_POST['confirm_new_password'] ?? null;
            $currentPassword = $_POST['current_password'] ?? null;
            
            if (!empty($newPassword) || !empty($confirmNewPassword)) {
                // Si l'utilisateur souhaite changer son mot de passe, le mot de passe actuel est requis
                if (empty($currentPassword)) {
                    SessionHelpers::setFlashMessage('error', 'Le mot de passe actuel est requis pour changer le mot de passe.');
                    $this->redirect('/mon-compte/profil.html');
                }

                // Vérification du mot de passe actuel
                $eleve = $this->eleveModel->getMe();
                $pepper = getenv('PASSWORD_PEPPER') ?: '';
                if (!$eleve || !password_verify($currentPassword . $pepper, $eleve['motpasseeleve'])) {
                    SessionHelpers::setFlashMessage('error', 'Le mot de passe actuel est incorrect.');
                    $this->redirect('/mon-compte/profil.html');
                }

                // LE NOUVEAU MOT DE PASSE DOIT ÊTRE DIFFÉRENT DE L'ANCIEN
                if ($currentPassword === $newPassword) {
                    SessionHelpers::setFlashMessage('error', 'Le nouveau mot de passe doit être différent de l\'ancien.');
                    $this->redirect('/mon-compte/profil.html');
                }

                // Vérification que les nouveaux mots de passe correspondent
                if ($newPassword !== $confirmNewPassword) {
                    SessionHelpers::setFlashMessage('error', 'Les nouveaux mots de passe ne correspondent pas.');
                    $this->redirect('/mon-compte/profil.html');
                }

                // AJOUT DE RÈGLES DE VALIDATION SUPPLÉMENTAIRES POUR LE NOUVEAU MOT DE PASSE ICI (LONGUEUR, COMPLEXITÉ, ETC.)

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
                
                // Toutes les validations sont passées, on peut procéder à la mise à jour du mot de passe

                $this->eleveModel->updatePassword(SessionHelpers::getConnected()['ideleve'], $newPassword);

                // Vous pouvez également envisager d'invalider les sessions actives ou de forcer une reconnexion après le changement de mot de passe pour des raisons de sécurité.
                SessionHelpers::logout();
                SessionHelpers::setFlashMessage('success', 'Mot de passe changé avec succès. Veuillez vous reconnecter.');
                $this->redirect('/connexion.html');
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
            } else {
                SessionHelpers::setFlashMessage('error', "Une erreur est survenue lors de la mise à jour de vos informations.");
            }
        }

        return template::render(
            "views/utilisateur/compte/mes-informations.php",
            [
                'titre' => 'Mes informations',
                'error' => SessionHelpers::getFlashMessage('error'),
                'success' => SessionHelpers::getFlashMessage('success'),
            ] + $this->eleveModel->getMe() // Ajoute l'ensemble des informations de l'utilisateur connecté (concatène les données de l'utilisateur connecté + les données de la vue, résultat un tableau associatif)
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
        SessionHelpers::logout();
        $this->redirect('/');
    }
}
