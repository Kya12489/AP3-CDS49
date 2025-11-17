<?php

namespace controllers;

use controllers\base\ApiController;
use DateTime;
use Exception;
use models\CategorieModel;
use models\EleveModel;
use models\QuestionModel;
use models\ReponseModel;
use models\ResultatModel;
use utils\SessionHelpers;

class MobileApiController extends ApiController
{
    private EleveModel $eleveModel;
    private QuestionModel $questionModel;
    private ReponseModel $reponseModel;
    private ResultatModel $resultatModel;
    private CategorieModel $categorieModel;

    function __construct()
    {
        $this->eleveModel = new EleveModel();
        $this->questionModel = new QuestionModel();
        $this->reponseModel = new ReponseModel();
        $this->resultatModel = new ResultatModel();
        $this->categorieModel = new CategorieModel();
    }

    function index()
    {
        return $this->redirect('/documentation-api.html');
    }

    /**
     * path: /api/login
     * method: POST
     * Méthode pour gérer la connexion des utilisateurs via l'API mobile.
     */
    function login()
    {
        if (!$this->isPost()) {
            return $this->errorResponse('Méthode non autorisée', 405);
        }

        // Lire les données JSON du corps de la requête
        $json = file_get_contents('php://input');
        $data = json_decode($json, true);

        $email = $data['email'] ?? null;
        $password = $data['password'] ?? null;

        if (empty($email) || empty($password)) {
            return $this->errorResponse('Email et mot de passe requis', 400);
        }
        $token = bin2hex(random_bytes(16));
        $user = $this->eleveModel->connexion($email, $password, $token);
        
        if ($user) {
            return $this->successResponse('Connexion réussie', ['user' => $user, 'token' => $token]);
        } else {
            return $this->errorResponse('Identifiants invalides', 401);
        }
    }

    /**
     * path: /api/signup
     * method: POST
     * Méthode pour gérer l'inscription des utilisateurs via l'API mobile.
     */
    function signUp(){
    if(!$this->isPost()){
        return $this->errorResponse("Methode non autorisée", 405);
    }
    $json = file_get_contents('php://input');
    $data = json_decode($json, true);
    
    if($data === null){
        return $this->errorResponse("JSON invalide");
    }
    
    $nom = trim($data["nom"] ?? "");
    $prenom = trim($data["prenom"] ?? "");
    $dn = trim($data["dateNaissance"] ?? "");
    $email = trim($data["email"] ?? "");
    $mdp = trim($data["mdp"] ?? "");
    
    if(empty($nom) || empty($prenom) || empty($email) || empty($mdp) || empty($dn)){
        return $this->errorResponse("Tous les champs sont prérequis",406);
    }
    
    // Convertir le format DD/MM/YYYY vers Y-m-d
    try {
        // Utiliser createFromFormat pour parser le format français
        $dn2 = DateTime::createFromFormat('d/m/Y', $dn);
        
        if($dn2 === false){
            return $this->errorResponse("Format de date invalide. Utilisez JJ/MM/AAAA",407);
        }
        
        $age = $dn2->diff(new DateTime())->y;
        
        if($age < 16){
            return $this->errorResponse("Vous devez avoir plus de 16 ans pour vous inscrire",408);
        }
        
        // Convertir au format Y-m-d pour la base de données
        $dnFormatted = $dn2->format('Y-m-d');
        
    } catch (Exception) {
        return $this->errorResponse("Date de naissance invalide",407);
    }
    
    // Créer l'élève avec la date au bon format
    if($this->eleveModel->creer_eleve($nom, $prenom, $email, $mdp, $dnFormatted, "")){
        $token = "votre_token"; // À implémenter
        return $this->successResponse('Inscription réussie', [
            'token' => $token,
            'user' => [
                'nom' => $nom,
                'prenom' => $prenom,
                'email' => $email
            ]
        ]);
    } else {
        return $this->errorResponse("Erreur lors de l'inscription",409);
    }
}
    /**
     * path: /api/profile/get
     * method: GET
     * Méthode pour récupérer les informations de l'utilisateur spécifié par le token.
     */
    function getProfile()
    {
        if ($this->isPost()) {
            return $this->errorResponse('Méthode non autorisée', 405);
        }

        // Récupération depuis l'en-tête (Bearer token), on ne garde que le token
        $token = trim(str_replace('Bearer ', '', $_SERVER['HTTP_AUTHORIZATION'] ?? ''));

        if (empty($token)) {
            return $this->errorResponse('Token requis', 401);
        }

        $user = $this->eleveModel->getByToken($token);
        $user = $this->eleveModel->getUserById($user["ideleve"]);
        if ($user) {
            return $this->successResponse('Informations utilisateur récupérées avec succès', ['user' => $user]);
        } else {
            return $this->errorResponse('Utilisateur non trouvé', 404);
        }
    }

    /**
     * path: /api/profile/update
     * method: POST
     * Méthode pour mettre à jour les informations de l'utilisateur.
     */
    function updateProfile()
    {
        if (!$this->isPost()) {
            return $this->errorResponse('Méthode non autorisée', 405);
        }

        // Lire les données JSON du corps de la requête
        $data = $this->getJsonData();

        // Récupération depuis l'en-tête (Bearer token)
        $token = $this->getAuthToken();

        if (empty($token)) {
            return $this->errorResponse('Token requis', 401);
        }

        $nom = $data['nom'] ?? null;
        $prenom = $data['prenom'] ?? null;
        $email = $data['email'] ?? null;
        $datenaissance = $data['datenaissance'] ?? null;
        $motDePasse = $data['motdepasse'] ?? null;

        if (empty($nom) || empty($prenom) || empty($email) || empty($datenaissance)) {
            return $this->errorResponse('Tous les champs sont requis', 400);
        }

        $success = $this->eleveModel->updateByToken($token, $nom, $prenom, $email, $datenaissance, $motDePasse);

        if ($success) {
            return $this->successResponse('Informations mises à jour avec succès');
        } else {
            return $this->errorResponse('Échec de la mise à jour des informations', 500);
        }
    }

    /**
     * path: /api/questions/{n}?categorie=0
     * method: GET
     * Retourne N questions et leur réponse associée.
     */
    public function getQuestions(int $n = 40)
    {
        if ($this->isPost()) {
            return $this->errorResponse('Méthode non autorisée', 405);
        }

        if ($n <= 0) {
            return $this->errorResponse('Le nombre de questions doit être supérieur à zéro', 400);
        }

        $categorie = $_GET['categorie'] ?? 0;

        // TODO: Implémenter la logique de filtrage par catégorie si nécessaire
        $questions = [];
        $output = [];
        // Si la catégorie est null ou 'random', on récupère des questions aléatoires
        if ($categorie == null || $categorie == 0) {
            $questions = $this->questionModel->getRandomQuestions($n);
        } else {
            $questions = $this->questionModel->getCategorieQuestions($categorie,$n);
        }


        foreach ($questions as $question) {
            $reponses = $this->reponseModel->getByQuestion($question->idquestion);
            $output[] = [
                'question' => $question,
                'reponses' => $reponses
            ];
        }

        return $this->successResponse('', $output);
    }

    public function getCategories(){
        return $this->successResponse('', $this->categorieModel->getAll());
    }

    /**
     * path: /api/fin-test
     * method: POST
     * Sauvegarde du score de l'élève.
     */
    function saveScore()
    {
        if (!$this->isPost()) {
            return $this->errorResponse('Méthode non autorisée', 405);
        }

        // Récupération depuis l'en-tête (Bearer token), on ne garde que le token
        $token = $this->getAuthToken();
        $success = false;

        /**
         * Data est un JSON qui contient :
         * {score: 1234, nbquestions: 40}
         */
        $data = $this->getJsonData();

        $score = $data['score'] ?? null;
        $nbQuestions = $data['nbquestions'] ?? null;

        if (empty($score) || empty($nbQuestions)) {
            return $this->errorResponse('Score et nombre de questions requis', 400);
        }

        // Récupération du connecté dans la session
        if (!$token && SessionHelpers::getConnected()) {
            // Id de l'élève connecté
            $ideleve = SessionHelpers::getConnected()['ideleve'] ?? null;

            if (empty($ideleve)) {
                return $this->errorResponse('Vous devez être connecté pour sauvegarder un score', 401);
            }

            // Sauvegarde du score dans la base de données par ID d'élève
            $success = $this->resultatModel->saveScoreById($ideleve, $score, $nbQuestions);
        } else {
            if (empty($token)) {
                return $this->errorResponse('Token requis', 401);
            }

            // Sauvegarde du score dans la base de données
            $success = $this->resultatModel->saveScoreByToken($token, $score, $nbQuestions);
        }

        if ($success) {
            return $this->successResponse('Score sauvegardé avec succès');
        } else {
            return $this->errorResponse('Échec de la sauvegarde du score', 500);
        }
    }

    function getScore(){
       if (!$this->isPost()) {
            return $this->errorResponse('Méthode non autorisée', 405);
        }
        
         $token = trim(str_replace('Bearer ', '', $_SERVER['HTTP_AUTHORIZATION'] ?? ''));

        if (empty($token)) {
            return $this->errorResponse('Token requis', 401);
        }

        $user = $this->eleveModel->getByToken($token);
        if (!$user) {
            return $this->errorResponse('Utilisateur non trouvé', 404);
        }

        $scores = $this->resultatModel->getScoreByUserId($user["ideleve"]);
        if ($scores) {
            
            return $this->successResponse('Informations score récupérées avec succès', ['scores' => $scores]);
        } else {
            return $this->errorResponse('score non trouvé', 404);
        }
    }

    public function getNbNotif(){
        if ($this->isPost()) {
            return $this->errorResponse('Méthode non autorisée', 405);
        }

        // Récupération depuis l'en-tête (Bearer token), on ne garde que le token
        $token = trim(str_replace('Bearer ', '', $_SERVER['HTTP_AUTHORIZATION'] ?? ''));

        if (empty($token)) {
            return $this->errorResponse('Token requis', 401);
        }

        $user = $this->eleveModel->getByToken($token);
        if (!$user) {
            return $this->errorResponse('Utilisateur non trouvé', 404);
        }

        $documentModel = new \models\DocumentModel();
        $nbNotif = $documentModel->getNbDocumentsNoReadByEleve($user["ideleve"]);

        return $this->successResponse('Nombre de notifications récupérées avec succès', ['nbNotif' => $nbNotif]);
    }
}
