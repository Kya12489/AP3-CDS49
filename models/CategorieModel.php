<?php
namespace models;

use models\base\SQL;

/**
 * Champs:
 * - idCategorie (int, PK)
 * - libelleCategorie (varchar)
 */

class CategorieModel extends SQL
{
    public function __construct()
    {
        parent::__construct('Categories', 'idCategorie');
    }
}