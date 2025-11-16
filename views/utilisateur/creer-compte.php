<!-- En sachant que si tout est correct et que le formulaire est valide, l'inscription sera créée avec succès et l'utilisateur sera redirigé vers la page de connexion pour se connecter avec ses identifiants.
 Après l'inscription, les champs seront réinitialisés. On fait quoi ? -->
 
<main class="container mt-5 pt-5 mb-5">
    <section id="creer-compte-form" class="py-5">
        <div class="row justify-content-center">
            <div class="col-lg-6">
                <div class="text-center mb-4">
                    <img src="/public/images/logo_cds49.jpeg" alt="Logo CDS 49" style="max-width: 150px; border-radius: 10px;">
                </div>
                <h2 class="display-5 fw-light text-center mb-4">Inscription</h2>

                <?php if (!empty($error)) { ?>
                    <div class="alert alert-danger" role="alert">
                        <?= htmlspecialchars($error, ENT_QUOTES, 'UTF-8') ?> <!-- Échappement pour éviter les injections XSS -->
                    </div>
                <?php } ?>

                <?php if (!empty($success)) { ?>
                    <div class="alert alert-success" role="alert">
                        <?= htmlspecialchars($success, ENT_QUOTES, 'UTF-8') ?>
                    </div>
                <?php } ?>

                <form method="POST" action="creer-compte.html">
                    <div class="mb-3">
                        <label for="nom" class="form-label">Nom</label>
                        <input type="text" class="form-control" id="nom" name="nom" maxlength="50" pattern="[A-Za-zÀ-ÿ\s\-]{2,50}" required>
                    </div>
                    <div class="mb-3">
                        <label for="prenom" class="form-label">Prénom</label>
                        <input type="text" class="form-control" id="prenom" name="prenom" maxlength="50" pattern="[A-Za-zÀ-ÿ\s\-]{2,50}" required>
                    </div>
                    <div class="mb-3">
                        <label for="email" class="form-label">Adresse Email</label>
                        <input type="email" class="form-control" id="email" name="email" maxlength="100" pattern="^[^\s@]+@[^\s@]+\.[^\s@]+$" autocomplete="email"
                        inputmode="email" required>
                    </div>

                    <!-- AJOUT DU CHAMP TELEPHONE POUR AJOUT FACULTATIF PAR L'ELEVE - LOT 1 --->
                    <div class="mb-3">
                        <label for="telephone" class="form-label">Numéro de téléphone</label>
                        <input type="tel" class="form-control" id="telephone" name="telephone" pattern="[0-9]{10}" >
                        <div class="form-text">Format attendu : 10 chiffres (ex: 0612345678)</div>
                    </div>

                    <!-- AJOUT DU CHAMP MOT DE PASSE AVEC LA POSSIBILITÉ DE L'AFFICHER EN CLIQUANT SUR UNE ICÔNE INTÉGRÉE DANS LE CHAMP INPUT - LOT 1 --->
                    <div class="mb-3">
                        <div class="group-password">
                            <label for="password" class="form-label">Mot de passe</label>
                            
                            <!-- Affichage de la force du mot de passe -->
                            <div id="password-strength">
                                <div class="progress" style="height: 8px;">
                                    <div id="strength-bar" class="progress-bar" role="progressbar" style="width: 0%;"></div>
                                </div>
                                <div id="strength-text"></div>
                            </div>
                        </div>

                        <!-- CHAMP MOT DE PASSE AVEC PATTERN POUR VALIDATION CÔTÉ CLIENT -->
                        <input type="password" class="form-control" id="password" name="password" maxlength="128" value=""
                        pattern='^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?\":{}|<>])[A-Za-z\d!@#$%^&*(),.?\":{}|<>]{8,}$' required>
                    </div>

                    <!-- CHAMP CONFIRMATION DU MOT DE PASSE -->
                    <div class="mb-3">
                        <label for="confirm-password" class="form-label">Confirmer le mot de passe</label>
                        <input type="password" class="form-control" id="confirm-password" name="confirm_password" maxlength="128" required>
                    </div>

                    <!-- CHAMP DATE DE NAISSANCE -->
                    <div class="mb-3">
                        <label for="date_naissance" class="form-label">Date de naissance</label>
                        <input type="date" class="form-control" id="date_naissance" name="date_naissance" min="1900-01-01" max="<?= date('Y-m-d', strtotime('-15 years')) ?>" required>
                        <div class="form-text">Minimum 15 ans pour s'inscrire.</div>
                    </div>

                    <div class="d-grid">
                        <!-- Token CSRF pour la sécurité afin d'éviter les attaques CSRF, c'est-à-dire que le formulaire ne peut être soumis que par l'utilisateur authentifié -->
                        <input type="hidden" name="csrf_token" value="<?= htmlspecialchars($_SESSION['csrf_token'] ?? '', ENT_QUOTES, 'UTF-8') ?>">
                        <button type="submit" class="btn btn-primary btn-lg">Créer mon compte</button>
                        
                        <!-- Une fois qu'on a fini de saisir les infos pour s'inscrire et après avoir cliqué sur le bouton "Créer mon compte", on
                         réinitialise le formulaire si tout est correct et que l'inscription a été créée avec succès. -->
                         <script>
                            if (window.history.replaceState) {
                                window.history.replaceState(null, null, window.location.href);
                            }
                         </script>
                    </div>
                </form>
                <p class="text-center mt-4">
                    Déjà un compte ? <a href="connexion.html">Connectez-vous ici</a>.
                </p>
            </div>
        </div>
    </section>
</main>

<!-- Script de validation côté client pour le formulaire d'inscription-->

<script>
document.addEventListener("DOMContentLoaded", function() {
    const form = document.querySelector("form");
    const nom = document.getElementById("nom");
    const prenom = document.getElementById("prenom");
    const email = document.getElementById("email");
    const telephone = document.getElementById("telephone");
    const password = document.getElementById("password");
    const confirmPassword = document.getElementById("confirm-password");
    const dateNaissance = document.getElementById("date_naissance");

    // Fonction utilitaire pour afficher une erreur sous le champ
    function showError(input, message) {
        let error = input.parentElement.querySelector(".error-message");
        if (!error) {
            error = document.createElement("div");
            error.classList.add("error-message", "text-danger", "mt-1");
            input.parentElement.appendChild(error);
        }
        error.textContent = message;
        input.classList.add("is-invalid");
    }
    // Fonction pour retirer le message d’erreur
    function clearError(input) {
        let error = input.parentElement.querySelector(".error-message");
        if (error) error.remove();

        // Supprime un ancien symbole si déjà présent
        let mark = input.parentElement.querySelector(".success-mark");
        if (mark) mark.remove();

        input.classList.remove("is-invalid");
    }

    function checkAllFields() {
        validateNom();
        validatePrenom();
        validateEmail();
        validatePassword();
        validateConfirmPassword();
        validateDateNaissance();
        validateTelephone();
    }
    
    // Fonction pour évaluer la force du mot de passe
    function getPasswordStrength(password) {
        let score = 0;
        if (password.length >= 8) score++;
        if (password.length >= 12) score++; // bonus longueur
        if (/[A-Z]/.test(password)) score++;
        if (/[a-z]/.test(password)) score++;
        if (/[0-9]/.test(password)) score++;
        if (/[!@#$%^&*(),.?":{}|<>]/.test(password)) score++;

        // Total sur 6 → 0 à 6
        return score;
    }

    // Mise à jour de la barre de force du mot de passe
    function updateStrengthDisplay(score) {
        const bar = document.getElementById("strength-bar");
        const text = document.getElementById("strength-text");
        
        const levels = [
            { text: "Très faible", color: "#dc3545", width: "10%" },
            { text: "Faible", color: "#fd7e14", width: "30%" },
            { text: "Moyen", color: "#ffc107", width: "50%" },
            { text: "Bon", color: "#0d6efd", width: "70%" },
            { text: "Fort", color: "#198754", width: "90%" },
            { text: "Très fort", color: "#0dca73", width: "100%" },
        ];

        // Décalage d’un cran : score=1 → "Très faible"
        const index = Math.min(Math.max(score - 1, 0), levels.length - 1);
        const level = levels[index];

        // Si score = 0, on peut même tout “vider”
        if (score === 0) {
            bar.style.width = "0";
            bar.style.backgroundColor = "#e0e0e0";
            text.textContent = "Sécurité : —";
            text.style.color = "#999";
            return;
        }

        bar.style.width = level.width;
        bar.style.backgroundColor = level.color;
        
        text.textContent = `Sécurité : ${level.text}`;
        text.style.color = level.color;
        text.style.fontSize = "0.7rem"; // Taille de police par défaut
    }

    // Ajoute une coche verte à côté du champ input

    function addSuccessMark(input) {
        // Supprime un ancien symbole si déjà présent
        const oldMark = input.parentElement.querySelector(".success-mark");
        if (oldMark) oldMark.remove();

        // Ajoute le nouveau ✔
        const mark = document.createElement("span");
        mark.classList.add("success-mark");
        mark.textContent = "✔";
        mark.style.color = "green";

        // Ajoute le symbole après le champ input
        input.parentElement.style.position = "relative"; // Assure que le parent est en position relative
        input.parentElement.appendChild(mark);
    }

    // Fonction pour retirer la coche verte présente dans les div
    // puisque les champs sont dans des divs.

    function removeSuccessMark(input) {
        const mark = input.closest(".mb-3")?.querySelector(".success-mark");
        if (mark) mark.remove();
    }

    // VERIFICATIONS EN LIVE
    nom.addEventListener("input", () => {
        if(nom.checkValidity() === false) {
            nom.value.trim() === ""
                ? showError(nom, "Le nom est requis.")
                : showError(nom, "Le nom doit contenir entre 2 et 50 caractères (lettres, espaces, traits d'union).");
            removeSuccessMark(nom);
        } else {
            clearError(nom); addSuccessMark(nom);
        }
    });

    prenom.addEventListener("input", () => {
        if(prenom.checkValidity() === false) {
            prenom.value.trim() === ""
                ? showError(prenom, "Le prénom est requis.")
                : showError(prenom, "Le prénom doit contenir entre 2 et 50 caractères (lettres, espaces, traits d'union).");
            removeSuccessMark(prenom);
        } else {
            clearError(prenom); addSuccessMark(prenom);
        }
    });
        
    email.addEventListener("input", () => {
        if(email.checkValidity() === false) {
            email.value.trim() === ""
                ? showError(email, "L'adresse email est requise.")
                : showError(email, "L'adresse email est invalide.");
            removeSuccessMark(email);
        } else {
            clearError(email);
            addSuccessMark(email);
        }
    });

    // Partie validation du mot de passe : chaque fois que l'utilisateur tape quelque chose, on lui dit séparément
    // selon le mot de passe saisi si c'est bon ou pas : c'est à dire s'il saisit le mot de passe au fur et à mesure, on lui indique
    // si les critères sont remplis ou pas (au moins 8 caractères, une majuscule, une minuscule, un chiffre et un caractère spécial)

    password.addEventListener("input", () => {
        const value = password.value.trim();
        const score = getPasswordStrength(value);
        updateStrengthDisplay(score);

        const regexMaj = /[A-Z]/;
        const regexMin = /[a-z]/;
        const regexChiffre = /[0-9]/;
        const regexSpecial = /[!@#$%^&*(),.?":{}|<>]/;

        if (password.value.length < 8) {
            showError(password, "Minimum 8 caractères (1 Maj., 1 Min., 1 chiffre, 1 caractère spécial).");
            removeSuccessMark(password);
        } else if (!regexMaj.test(value)) {
            showError(password, "Le mot de passe doit contenir au moins une lettre majuscule.");
            removeSuccessMark(password);
        } else if (!regexMin.test(value)) {
            showError(password, "Le mot de passe doit contenir au moins une lettre minuscule.");
            removeSuccessMark(password);
        } else if (!regexChiffre.test(value)) {
            showError(password, "Le mot de passe doit contenir au moins un chiffre.");
            removeSuccessMark(password);
        } else if (!regexSpecial.test(value)) {
            showError(password, "Le mot de passe doit contenir au moins un caractère spécial exemple : !@#$%^&*().");
            removeSuccessMark(password);
        } else {
            clearError(password);
            addSuccessMark(password);
        }
    });

    // Je veux que la confirmation s'actualise en continu en fonction du mot de passe saisi
    confirmPassword.addEventListener("input", () => {
        if (password.value === "") {
            removeSuccessMark(confirmPassword);
            clearError(confirmPassword);
            return;
        }

        if (password.value !== confirmPassword.value) {
            showError(confirmPassword, "Les mots de passe ne correspondent pas.");
            removeSuccessMark(confirmPassword);
        } else {
            clearError(confirmPassword);
            addSuccessMark(confirmPassword);
        }
    });

    const checkPasswords = () => {
        if (password.value === "" && confirmPassword.value === "") {
            removeSuccessMark(confirmPassword);
            clearError(confirmPassword);
            return;
        }

        if (password.value !== confirmPassword.value) {
            showError(confirmPassword, "Les mots de passe ne correspondent pas.");
            removeSuccessMark(confirmPassword);
        } else {
            clearError(confirmPassword);
            addSuccessMark(confirmPassword);
        };
    };

password.addEventListener("input", checkPasswords);
confirmPassword.addEventListener("input", checkPasswords);

    dateNaissance.addEventListener("input", () => {
        const today = new Date();
        const birthDate = new Date(dateNaissance.value);
        const year = birthDate.getFullYear();
        const currentYear = today.getFullYear();

        if (year < 1900 || year > currentYear) {
            showError(dateNaissance, "Veuillez entrer une date valide entre 1900 et aujourd'hui.");
            removeSuccessMark(dateNaissance);
            return;
        }


        if (isNaN(birthDate.getTime())) {
            showError(dateNaissance, "Veuillez entrer une date valide.");
            removeSuccessMark(dateNaissance);
            return;
        }

        if (birthDate > today) {
            showError(dateNaissance, "La date de naissance ne peut pas être dans le futur.");
            removeSuccessMark(dateNaissance);
            return;
        }

        let age = today.getFullYear() - birthDate.getFullYear();
        const monthDiff = today.getMonth() - birthDate.getMonth();
        if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }

        if (age < 15) {
            showError(dateNaissance, `Vous avez ${age} ans. Vous devez avoir au moins 15 ans.`);
            removeSuccessMark(dateNaissance);
        } else {
            clearError(dateNaissance);
            addSuccessMark(dateNaissance);
        }
    });


    // Vérification du numéro de téléphone : doit contenir exactement 10 chiffres

    telephone.addEventListener("input", () => {
        const regex = /^[0-9]{10}$/;
        if (telephone.value.trim() !== "") {
            if(!regex.test(telephone.value) || telephone.checkValidity() === false) {
                showError(telephone, "Le numéro doit contenir 10 chiffres.");
                removeSuccessMark(telephone);
            } else {
                clearError(telephone);
                addSuccessMark(telephone);
            }
        } else {
            clearError(telephone);
            removeSuccessMark(telephone);
        }
    });

    // Validation finale avant envoi, en sachant que s'il y a des champs sont invalides, on empêche l'envoi du formulaire et on affiche
    // un message au lieu d'une alerte générique en haut du formulaire.
    
    form.addEventListener("submit", (e) => {
        // On empêche l'envoi du formulaire si des champs sont invalides
        checkAllFields();

        let hasError = false;

        // Vérification de chaque champ
        // NOM
        if(nom.checkValidity() === false) {
            nom.value.trim() === ""
                ? (showError(nom, "Le nom est requis."), (hasError = true))
                : (showError(nom, "Le nom doit contenir entre 2 et 50 caractères (lettres, espaces, traits d'union)."), (hasError = true));
        } else {
            clearError(nom);
        }

        // PRÉNOM
        if(prenom.checkValidity() === false) {
            prenom.value.trim() === ""
                ? (showError(prenom, "Le prénom est requis."), (hasError = true))
                : (showError(prenom, "Le prénom doit contenir entre 2 et 50 caractères (lettres, espaces, traits d'union)."), (hasError = true));
        } else {
            clearError(prenom);
        }

        // EMAIL
        if(email.checkValidity() === false) {
            email.value.trim() === ""
                ? (showError(email, "L'adresse email est requise."), (hasError = true))
                : (showError(email, "L'adresse email est invalide."), (hasError = true));
        } else {
            clearError(email);
        }
        
        // MOT DE PASSE
        const passwordValue = password.value.trim();
        let passwordErrorMessage = "";
        if (passwordValue.length < 8) {
            passwordErrorMessage = "Minimum 8 caractères (1 Maj., 1 Min., 1 chiffre, 1 caractère spécial).";
        } else if (!/[A-Z]/.test(passwordValue)) {
            passwordErrorMessage = "Le mot de passe doit contenir au moins une lettre majuscule.";
        } else if (!/[a-z]/.test(passwordValue)) {
            passwordErrorMessage = "Le mot de passe doit contenir au moins une lettre minuscule.";
        } else if (!/[0-9]/.test(passwordValue)) {
            passwordErrorMessage = "Le mot de passe doit contenir au moins un chiffre.";
        } else if (!/[!@#$%^&*(),.?":{}|<>]/.test(passwordValue)) {
            passwordErrorMessage = "Le mot de passe doit contenir au moins un caractère spécial exemple : !@#$%^&*().";
        }
        passwordErrorMessage
            ? (showError(password, passwordErrorMessage), (hasError = true))
            : clearError(password);

        // CONFIRMATION MOT DE PASSE
        password.value !== confirmPassword.value
            ? (showError(confirmPassword, "Les mots de passe ne correspondent pas."), (hasError = true))
            : clearError(confirmPassword);


        // DATE DE NAISSANCE
        const today = new Date();
        const birthDate = new Date(dateNaissance.value);
        let age = today.getFullYear() - birthDate.getFullYear();
        const monthDiff = today.getMonth() - birthDate.getMonth();
        if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < birthDate.getDate())) {
            age--;
        }
        age < 15
            ? (showError(dateNaissance, "Vous avez " + age + " ans. Vous devez avoir au moins 15 ans."), (hasError = true))
            : clearError(dateNaissance);

        // TÉLÉPHONE (FACULTATIF)
        const telephoneValue = telephone.value.trim();
        const telephoneRegex = /^[0-9]{10}$/;
        telephoneValue !== "" && !telephoneRegex.test(telephoneValue)
            ? (showError(telephone, "Le numéro doit contenir 10 chiffres."), (hasError = true))
            : clearError(telephone);

        // Si des erreurs, empêche la soumission
        if (form.querySelectorAll(".is-invalid").length > 0 || hasError) {
            e.preventDefault();

            // Suppression de l'ancienne alerte s'il y en a une avant d'en afficher une nouvelle.
            const oldAlert = form.querySelector(".alert.alert-danger");
            if (oldAlert) oldAlert.remove();

            // Afficher un message d'erreur générique en haut du formulaire
            const errorMessage = document.createElement("div");
            errorMessage.classList.add("alert", "alert-danger");
            errorMessage.textContent = "Veuillez corriger les erreurs avant de soumettre le formulaire.";
            form.prepend(errorMessage);

            // Met le focus sur le premier champ invalide
            const firstErrorField = form.querySelector(".is-invalid");
            if (firstErrorField) firstErrorField.focus();

            // Scroll vers le haut du formulaire pour voir les erreurs
            form.scrollIntoView({ behavior: 'smooth' });
        }
    });
});

</script>