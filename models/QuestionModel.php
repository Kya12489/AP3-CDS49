<?php

namespace models;

use models\base\SQL;

/**
 * Champs:
 * - idquestion (int, PK)
 * - libellequestion (varchar)
 * - imagequestion (varchar)
 */
class QuestionModel extends SQL
{
    public function __construct()
    {
        parent::__construct('question', 'idquestion');
    }

    /**
     * Retourne N questions aléatoires.
     */
    public function getRandomQuestions(int $count = 10): array
    {
        $stmt = $this->getPdo()->prepare("SELECT * FROM question ORDER BY RAND() LIMIT :count");
        $stmt->bindValue(':count', $count, \PDO::PARAM_INT);
        $stmt->execute();
        return $stmt->fetchAll(\PDO::FETCH_OBJ);
    }
    public function getCategorieQuestions(int $idCat,int $count = 10): array
    {
        $stmt = $this->getPdo()->prepare("SELECT * FROM question WHERE idCategorie = :id ORDER BY RAND() LIMIT :count");
        $stmt->bindValue(':count', $count, \PDO::PARAM_INT);
        $stmt->bindValue(':id', $idCat, \PDO::PARAM_INT);
        $stmt->execute();
        return $stmt->fetchAll(\PDO::FETCH_OBJ);
    }
}
