<?php

namespace models;

use models\base\SQL;
use utils\EmailUtils;
use utils\SessionHelpers;

/**
 * Champs:
 * - ideleve (int, PK)
 * - nomeleve (varchar)
 * - prenomeleve (varchar)
 * - emaileleve (varchar)
 * - motpasseeleve (varchar)
 * - datenaissanceeleve (date)
 */
class DocumentModel extends SQL{
    
    public function __construct()
    {
        parent::__construct('justificatifs', 'idDoc');
    }

    public function getNbDocumentsNoReadByEleve(int $idEleve): int
    {
        $stmt = $this->getPdo()->prepare("SELECT COUNT(*) as nb FROM justificatifs WHERE idEleve = :ideleve AND idStatut in(1,4)");
        $stmt->execute([':ideleve' => $idEleve]);
        $result = $stmt->fetch();
        return $result ? (int)$result["nb"] : 0;
    }

    public function getDocumentByEleve(int $idEleve){
        $stmt = $this->getPdo()->prepare("SELECT * FROM justificatifs D join typeDoculent T on T.idType = D.idType join statut S on S.idStatut=D.idStatut WHERE idEleve=?");
        $stmt->execute([$idEleve]);
        return $stmt->fetchAll();
    }

    public function updateLienDocument(int $idDoc, string $lien){
        $stmt = $this->getPdo()->prepare("UPDATE justificatifs SET lienDoc = :lien WHERE idDoc = :idDoc");
        return $stmt->execute([':lien' => $lien, ':idDoc' => $idDoc]);
    }

    public function updateIdStatut(int $idDoc, int $idStatut){
        $stmt = $this->getPdo()->prepare("UPDATE justificatifs SET idStatut = :idStatut WHERE idDoc = :idDoc");
        return $stmt->execute([':idStatut' => $idStatut, ':idDoc' => $idDoc]);
    }

    public function getById(int $idDoc) {
    $stmt = $this->getPdo()->prepare("
        SELECT D.*, T.libelle as type, S.libelle as statut 
        FROM justificatifs D 
        JOIN typeDoculent T ON T.idType = D.idType 
        JOIN statut S ON S.idStatut = D.idStatut 
        WHERE idDoc = ?
    ");
    $stmt->execute([$idDoc]);
    return $stmt->fetch();
}
}