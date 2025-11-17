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
        parent::__construct('document', 'idDoc');
    }

    public function getNbDocumentsNoReadByEleve(int $idEleve): int
    {
        $stmt = $this->getPdo()->prepare("SELECT COUNT(*) as nb FROM document WHERE idEleve = :ideleve AND idStatut in(1,4)");
        $stmt->execute([':ideleve' => $idEleve]);
        $result = $stmt->fetch();
        return $result ? (int)$result["nb"] : 0;
    }
}