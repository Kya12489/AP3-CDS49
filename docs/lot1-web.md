# LOT 1 – Web (Branche Web_PHP)

## Objectif
Livrer la première itération complète du module web de gestion des comptes élèves :
- Création de compte
- Connexion
- Gestion du profil
- Sécurité et validations
- Page “À propos”

---

## Fonctionnalités principales
### A. Page À propos
- Accessible depuis le header (connecté ou non)
- Présente les informations générales et légales

### B. Téléphone
- Champ ajouté dans inscription et profil
- Optionnel à la création, modifiable ensuite
- Validation côté client et serveur
- Sauvegarde en base via EleveModel

### C. Sécurité
- Hachage des mots de passe (password_hash / verify)
- Changement de mot de passe sécurisé
- Token CSRF sur tous formulaires
- Protection XSS via htmlspecialchars

### D. Validation
- JS dynamique sur tous champs
- Vérifications côté serveur en miroir
- Refus si incohérence ou champ vide

---

## Tests effectués
| Cas testé | Résultat attendu | Résultat obtenu |
|------------|------------------|-----------------|
| Inscription correcte | Redirection connexion | ✅ |
| Inscription sans email | Message erreur | ✅ |
| Connexion valide | Accès compte | ✅ |
| Mauvais mot de passe | Erreur “Identifiants incorrects” | ✅ |
| Modification profil | Message succès | ✅ |
| Insertion <script> dans profil | Affichage texte brut (XSS bloquée) | ✅ |

---

## Statut
✅ Livré et testé  
⏳ Prochaine étape : Lot 2 – Réinitialisation du mot de passe (cycle token/email)



---------------------------------------------





VRAI VERSION:

Lot 1 – Documentation Web (Version Professionnelle)
Projet : CDS 49 – Espace Élève & Portail Public
1. Introduction

Le Lot 1 a pour objectif d’améliorer l’existant de la partie Web du projet CDS49.
Il couvre la création de pages, l’ajout de nouvelles données dans le modèle utilisateur, la sécurisation des formulaires et la mise en conformité de la gestion des sessions.

Ce document liste précisément toutes les modifications réalisées dans le cadre du Lot 1.

2. Ajout de la page “À propos”
Objectifs

Ajouter une page statique informative.

Rendre la page accessible depuis la navigation principale.

Centraliser les mentions importantes (présentation, légalité, informations diverses).

Travaux réalisés

Création du fichier de vue : views/public/apropos.php

Ajout de la route dédiée dans Web.php

Mise en place du contrôleur associé dans PublicWebController

Intégration dans le header (visiteur + connecté)

3. Ajout du champ Téléphone
Modifications en base de données

Ajout du champ :

ALTER TABLE eleve ADD numeroteleleve VARCHAR(10) NULL;

Modèles concernés

EleveModel → Ajout du champ dans :

creer_eleve()

update()

Gestion de la mise à jour de session

Formulaires mis à jour

Formulaire de création de compte (creercompte)

Formulaire “Mes informations” dans l’espace élève

Validations

JavaScript

Vérification dynamique (regex 10 chiffres)

PHP

Validation stricte côté serveur

Saisie facultative mais format obligatoire si remplie

4. Sécurisation des mots de passe
Problème initial

Mot de passe stocké en clair.

Comparaison directe en base.

Absence de règles de complexité.

Travaux réalisés

Passage au hachage sécurisé :

password_hash($motDePasse, PASSWORD_BCRYPT);


Vérification à la connexion :

password_verify($motDePasse, $eleve['motpasseeleve']);


Ajout de règles de sécurité :

Min 8 caractères

1 majuscule

1 minuscule

1 chiffre

1 caractère spécial

Mise à jour du mot de passe

Vérification obligatoire du mot de passe actuel

Vérification nouveau ≠ ancien

Validation de la confirmation

Invalidation de la session + reconnexion forcée après modification

5. Protection CSRF
Système mis en place

Génération aléatoire d’un token (32 bytes) stocké en session

Ajout automatique d’un input hidden dans les formulaires sensibles

Vérification sécurisée via hash_equals()

Expiration configurable du token via .env

Invalidations et regeneration automatique après utilisation ou après expiration

Pages protégées

Formulaire de connexion

Formulaire “Mes informations”

Formulaire de création de compte (si nécessaire)

Toute action impliquant une modification en base

6. Gestion sécurisée des sessions
Travail réalisé

Mise en place d’un système complet conforme aux recommandations OWASP Session Management :

✔ Timeout d’inactivité

Basé sur la variable session LAST_ACTIVITY.

✔ Durée maximale de session

Basée sur SESSION_START_TIME.

✔ Regénération périodique ID de session

Protection contre les attaques par fixation de session.

✔ Nettoyage complet à la déconnexion

Via clearSession() + session_destroy().

✔ Configuration dynamique (via .env)

Exemples :

DURATION_INACTIVITY_TIMEOUT=36000
SESSSION_MAX_LIFETIME=172800
DURATION_SESSION_SERVER=3600

7. Validation globale des données
Côté client (JavaScript)

Feedback instantané

Messages d’erreur dynamiques

Styles visuels (valid / invalid)

Contrôles spécifiques (âge, date, format téléphone, email…)

Côté serveur (PHP)

Regex strictes pour nom / prénom

Validation email (format + unicité)

Vérification date de naissance (format AAAA-MM-JJ + ≥ 15 ans)

Contrôles mot de passe

Double barrière JS + PHP

8. Architecture MVC consolidée

Le Lot 1 a permis d’ajuster l’architecture pour la rendre plus propre et professionnelle :

Routes clairement séparées – Web.php, Api.php, etc.

Contrôleurs spécialisés – PublicWebController, CompteController, UtilisateurController

EntryPoint unique gérant :

Initialisation session

Sécurité

Delegation vers Router

Modèles structurés

Vues isolées (aucune logique métier)