<?php
namespace controllers;
use controllers\base\WebController;
use models\DocumentModel;

class DocumentController extends WebController
{
    private DocumentModel $documentModel;

    function __construct()
    {
        $this->documentModel = new DocumentModel();
    }

    function showDocument(string $lien)
    {
        // Chemin absolu vers le fichier
        $filePath = 'documents/' . $lien;

        // Vérifier si le fichier existe
        if (!file_exists($filePath)) {
            http_response_code(404);
            echo "Fichier introuvable.";
            return;
        }

        // Déterminer le type MIME du fichier
        $finfo = finfo_open(FILEINFO_MIME_TYPE);
        $mimeType = finfo_file($finfo, $filePath);
        finfo_close($finfo);

        // Envoyer les en-têtes HTTP pour forcer le téléchargement ou l'affichage
        header('Content-Type: ' . $mimeType);
        header('Content-Disposition: inline; filename="' . basename($filePath) . '"');
        header('Content-Length: ' . filesize($filePath));

        // Nettoyer le buffer de sortie
        ob_clean();
        flush();

        // Lire et envoyer le fichier
        readfile($filePath);
        exit;
    }
}
