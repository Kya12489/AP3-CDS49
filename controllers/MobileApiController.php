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
    function getQuestions(int $n = 40)
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

        if ($score === null || $nbQuestions === null) {
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
        if (!$this->isPost()) {
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

    function getDocuments(){
        if (!$this->isPost()) {
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
        $documents = $documentModel->getDocumentByEleve($user["ideleve"]);

        return $this->successResponse('Documents récupérés avec succès', ['documents' => $documents]);
    }

   public function uploadDocument(){


    if ($_SERVER['REQUEST_METHOD'] === 'OPTIONS') {
        http_response_code(200);
        exit();
    }

    try {
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

        if (!isset($_POST['document_id'])) {
            return $this->errorResponse('ID du document manquant', 400);
        }

        // ← Vérifier que le fichier est bien reçu
        if (!isset($_FILES['document'])) {
            return $this->errorResponse('Aucun fichier reçu', 400);
        }

        if ($_FILES['document']['error'] !== UPLOAD_ERR_OK) {
            return $this->errorResponse('Erreur upload: ' . $_FILES['document']['error'], 400);
        }

        $documentId = intval($_POST['document_id']);
        $file = $_FILES['document'];

        $allowedTypes = ['application/pdf', 'image/jpeg', 'image/jpg', 'image/png'];
        $fileType = mime_content_type($file['tmp_name']);

        if (!in_array($fileType, $allowedTypes)) {
            return $this->errorResponse('Type non autorisé: ' . $fileType, 400);
        }

        $maxSize = 10 * 1024 * 1024;
        if ($file['size'] > $maxSize) {
            return $this->errorResponse('Fichier trop volumineux', 400);
        }

        // ← Vérifier le chemin du dossier
        $uploadDir = realpath(__DIR__ . '/../../documents/');
        if ($uploadDir === false) {
            // Le dossier n'existe pas encore, le créer
            $uploadDir = __DIR__ . '/../../documents/';
            if (!mkdir($uploadDir, 0777, true)) {
                return $this->errorResponse('Impossible de créer le dossier: ' . $uploadDir, 500);
            }
            $uploadDir = realpath($uploadDir);
        }
        $uploadDir .= '/';

        $extension = pathinfo($file['name'], PATHINFO_EXTENSION);
        $fileName = uniqid('doc_' . $documentId . '_', true) . '.' . $extension;
        $filePath = $uploadDir . $fileName;

        if (!move_uploaded_file($file['tmp_name'], $filePath)) {
            return $this->errorResponse('Impossible de déplacer le fichier vers: ' . $filePath, 500);
        }

        try {
            $documentModel = new \models\DocumentModel();
            $documentModel->updateLienDocument($documentId, $fileName);
            $documentModel->updateIdStatut($documentId, 2);

            return $this->successResponse('Document téléversé avec succès', [
                'document_id' => $documentId,
                'file_name' => $fileName,
                'file_path' => $fileName,
                'file_size' => $file['size'],
                'file_type' => $fileType
            ]);

        } catch (\Exception $e) {
            if (file_exists($filePath)) {
                unlink($filePath);
            }
            return $this->errorResponse('Erreur BDD: ' . $e->getMessage(), 500);
        }

    } catch (\Exception $e) {
        return $this->errorResponse('Erreur générale: ' . $e->getMessage(), 500);
    }
}

public function downloadDocument(){
    if (!$this->isPost()) {
        return $this->errorResponse('Méthode non autorisée', 405);
    }

    // Récupération du token
    $token = trim(str_replace('Bearer ', '', $_SERVER['HTTP_AUTHORIZATION'] ?? ''));

    if (empty($token)) {
        return $this->errorResponse('Token requis', 401);
    }

    $user = $this->eleveModel->getByToken($token);
    if (!$user) {
        return $this->errorResponse('Utilisateur non trouvé', 404);
    }

    // Récupérer l'ID du document depuis l'URL
    if (!isset($_GET['document_id'])) {
        return $this->errorResponse('ID du document manquant', 400);
    }

    $documentId = intval($_GET['document_id']);

    $documentModel = new \models\DocumentModel();
    $document = $documentModel->getById($documentId);

    if (!$document) {
        return $this->errorResponse('Document non trouvé', 404);
    }

    // Vérifier que le document appartient à l'utilisateur
    if ($document['idEleve'] != $user['ideleve']) {
        return $this->errorResponse('Accès non autorisé', 403);
    }

    // Vérifier que le document a un fichier
    if (empty($document['lienDoc'])) {
        return $this->errorResponse('Aucun fichier disponible', 404);
    }

    // Chemin du fichier
    $filePath = __DIR__ . '/../../documents/' . $document['lienDoc'];

    if (!file_exists($filePath)) {
        return $this->errorResponse('Fichier introuvable sur le serveur', 404);
    }

    // Déterminer le type MIME
    $finfo = finfo_open(FILEINFO_MIME_TYPE);
    $mimeType = finfo_file($finfo, $filePath);
    finfo_close($finfo);

    // Nom du fichier pour le téléchargement
    $fileName = basename($document['lienDoc']);

    // Headers pour forcer le téléchargement
    header('Content-Description: File Transfer');
    header('Content-Type: ' . $mimeType);
    header('Content-Disposition: attachment; filename="' . $fileName . '"');
    header('Content-Transfer-Encoding: binary');
    header('Expires: 0');
    header('Cache-Control: must-revalidate');
    header('Pragma: public');
    header('Content-Length: ' . filesize($filePath));

    // Nettoyer le buffer de sortie
    ob_clean();
    flush();

    // Envoyer le fichier
    readfile($filePath);
    exit;
}
}
