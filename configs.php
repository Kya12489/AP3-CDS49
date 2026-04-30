<?php

$DB_SERVER = getenv("MVC_SERVER") ?: "192.168.10.16"; // Correspond au nom de domaine de la machine qui héberge la base de données.
$DB_DATABASE = getenv("MVC_DB") ?: "ap3_lws";
$DB_USER = getenv("MVC_USER") ?: "ap3_lws-1";
$DB_PASSWORD = getenv("MVC_TOKEN") ?: "QBk2eSrI"; // Ici, le TOKEN représente le mot de passe de la base de données.
$DEBUG = getenv("MVC_DEBUG") ?: true;
$URL_BASE = getenv("URL_BASE") ?: "http://localhost:9000/";
$MAIL_SERVER = getenv("MVC_MAIL_SERVER") ?: "mail.dombtsig.local";
$FROM_EMAIL = getenv("MVC_FROM_EMAIL") ?: "contact@localhost.fr";
$PASSWORD_PEPPER = getenv("PASSWORD_PEPPER") ?: "Pacquemus?%VN%NV?NZ%CEFUPN?%VJ28RKD?"; // Pepper pour le hachage des mots de passe

return array(
    "DB_USER" => $DB_USER,
    "DB_PASSWORD" => $DB_PASSWORD,
    // Pour MySQL, utilisez la ligne suivante :
    "DB_DSN" => "mysql:host=$DB_SERVER;dbname=$DB_DATABASE;charset=utf8",
    // Pour du SQLite, utilisez la ligne suivante :
    // "DB_DSN" => "sqlite:./data/database.db",
    "DEBUG" => $DEBUG,
    "MAIL_SERVER" => $MAIL_SERVER,
    "FROM_EMAIL" => $FROM_EMAIL,
    "URL_BASE" => $URL_BASE,
    "PASSWORD_PEPPER" => $PASSWORD_PEPPER
);

/*
$DB_SERVER = getenv("MVC_SERVER") ?: "phpmyadmin.dombtsig.local"; // Correspond au nom de domaine de la machine qui héberge la base de données.
$DB_DATABASE = getenv("MVC_DB") ?: "ap3_2025_2026";
$DB_USER = getenv("MVC_USER") ?: "ap3_2025_2026";
$DB_PASSWORD = getenv("MVC_TOKEN") ?: "NO0k6GX5"; // Ici, le TOKEN représente le mot de passe de la base de données.
$DEBUG = getenv("MVC_DEBUG") ?: true;
$URL_BASE = getenv("URL_BASE") ?: "http://localhost:9000/";
$MAIL_SERVER = getenv("MVC_MAIL_SERVER") ?: "mail.dombtsig.local";
$FROM_EMAIL = getenv("MVC_FROM_EMAIL") ?: "contact@localhost.fr";

return array(
    "DB_USER" => $DB_USER,
    "DB_PASSWORD" => $DB_PASSWORD,
    // Pour MySQL, utilisez la ligne suivante :
    "DB_DSN" => "mysql:host=$DB_SERVER;dbname=$DB_DATABASE;charset=utf8",
    // Pour du SQLite, utilisez la ligne suivante :
    // "DB_DSN" => "sqlite:./data/database.db",
    "DEBUG" => $DEBUG,
    "MAIL_SERVER" => $MAIL_SERVER,
    "FROM_EMAIL" => $FROM_EMAIL,
    "URL_BASE" => $URL_BASE
);
*/
?>