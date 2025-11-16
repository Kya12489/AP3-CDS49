<main class="container pt-4">
    <section id="espace-connecte">
        <h1 class="mb-4">Mon Espace</h1>

        <div class="row">
            <?php
            // Inclusion de la sidebar pour l'espace compte utilisateur (menu de navigation)
            $page_active = 'profil';
            include '_sidebar_compte.php';
            ?>

            <div class="col-md-9">
                <div class="tab-content">

                    <?php if (!empty($error)) { ?>
                        <div class="alert alert-danger" role="alert">
                            <?= htmlspecialchars($error ?? '', ENT_QUOTES, 'UTF-8') ?>
                        </div>
                    <?php } ?>

                    <?php if (!empty($success)) { ?>
                        <div class="alert alert-success" role="alert">
                            <?= htmlspecialchars($success ?? '', ENT_QUOTES, 'UTF-8') ?>
                        </div>
                    <?php } ?>

                    <form method="POST" action="/mon-compte/profil.html">
                        <div class="mb-3">
                            <label for="nom" class="form-label">Nom</label>
                            <input type="text" class="form-control" id="nom" name="nom" maxlength="50" pattern="[A-Za-zÀ-ÿ\s\-]{2,50}"
                            value="<?= htmlspecialchars($nomeleve ?? '', ENT_QUOTES, 'UTF-8'); ?>">
                        </div>
                        <div class="mb-3">
                            <label for="prenom" class="form-label">Prénom</label>
                            <input type="text" class="form-control" id="prenom" name="prenom" maxlength="50" pattern="[A-Za-zÀ-ÿ\s\-]{2,50}"
                            value="<?= htmlspecialchars($prenomeleve ?? '', ENT_QUOTES, 'UTF-8'); ?>">
                        </div>
                        <div class="mb-3">
                            <label for="email" class="form-label">Email</label>
                            <input type="email" class="form-control" id="email" name="email" pattern="^[^\s@]+@[^\s@]+\.[^\s@]+$" autocomplete="email"
                            inputmode="email" value="<?= htmlspecialchars($emaileleve ?? '', ENT_QUOTES, 'UTF-8'); ?>">
                        </div>
                        <div class="mb-3">
                            <label for="datenaissance" class="form-label">Date de naissance</label>
                            <input type="date" class="form-control" id="datenaissance" name="datenaissance" min="1900-01-01" max="<?= date('Y-m-d') ?>"  value="<?= htmlspecialchars($datenaissanceeleve ?? '', ENT_QUOTES, 'UTF-8'); ?>">
                            <div class="form-text">Minimum 15 ans pour s'inscrire.</div>
                        </div>

                        <!-- AJOUT DU CHAMP TÉLÉPHONE DANS LE FORMULAIRE - MISE À JOUR FACULTATIVE DU NUMERO PAR L'ÉLÈVE -- LOT 1 -->
                        <div class="mb-3">
                            <label for="telephone" class="form-label">Téléphone</label>
                            <input type="tel" class="form-control" id="telephone" name="telephone" pattern="[0-9]{10}" value="<?= htmlspecialchars($telephoneeleve ?? '', ENT_QUOTES, 'UTF-8'); ?>">
                            <div class="form-text">Format attendu : 10 chiffres (ex: 0612345678)</div>

                        </div>
                        <!-- FIN DU CHAMP TÉLÉPHONE LOT 1 -->

                        <!-- BONUS - CHANGEMENT DE MOT DE PASSE EN SACHANT QUE LE MOT DE PASSE ACTUEL N'EST PAS AFFICHÉ DANS LE FORMULAIRE ET EST REQUIS POUR LE CHANGEMENT
                            EN SECURISANT LES CHAMPS DE SAISIE (htmlspecialchars, pas d'injection, normes de sécurité de saisie) - LOT 1 -->
                        
                        <div class="mb-3">
                            <label for="current_password" class="form-label">Mot de passe actuel (requis si changement, pour des raisons de sécurité)</label>
                            <input type="password" class="form-control" id="current_password" name="current_password" maxlength="128"
                            pattern='^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?\":{}|<>])[A-Za-z\d!@#$%^&*(),.?\":{}|<>]{8,}$' value="">
                        </div>
                        
                        <!-- NOUVEAU MOT DE PASSE SI LE MOT DE PASSE EST MODIFIÉ, SINON IL RESTE LE MÊME (NON MODIFIÉ) -->
                        <div class="mb-3">
                            <div class="group-password">
                                <label for="new_password" class="form-label">Nouveau mot de passe (laisser vide pour ne pas changer)</label>

                                <!-- Affichage de la force du mot de passe -->
                                <div id="password-strength" style="width: 42%;" >
                                    <div class="progress" style="height: 8px;">
                                        <div id="strength-bar" class="progress-bar" role="progressbar" style="width: 0%;"></div>
                                    </div>
                                    <div id="strength-text"></div>
                                </div>
                            </div>

                            <!-- CHAMP NOUVEAU MOT DE PASSE AVEC PATTERN POUR VALIDATION CÔTÉ CLIENT -->
                            <input type="password" class="form-control" id="new_password" name="new_password" maxlength="128"
                            pattern='^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?\":{}|<>])[A-Za-z\d!@#$%^&*(),.?\":{}|<>]{8,}$' value="">
                        </div>

                        <!-- CONFIRMATION DU NOUVEAU MOT DE PASSE -->
                        <div class="mb-3">
                            <label for="confirm_new_password" class="form-label">Confirmer le nouveau mot de passe</label>
                            <input type="password" class="form-control" id="confirm_new_password" name="confirm_new_password" maxlength="128" value="">
                        </div>

                        <!-- BLOC DIV POUR LE BOUTON DE SOUMISSION -->
                        <div class="text-center pt-3">
                            <input type="hidden" name="csrf_token" value="<?= htmlspecialchars($_SESSION['csrf_token'] ?? '', ENT_QUOTES, 'UTF-8') ?>">
                            <button type="submit" class="btn btn-primary">Mettre à jour le profil</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
</main>


<script>
document.addEventListener("DOMContentLoaded", function() {
    const form = document.querySelector("form");
    const nom = document.getElementById("nom");
    const prenom = document.getElementById("prenom");
    const email = document.getElementById("email");
    const dateNaissance = document.getElementById("datenaissance");
    const telephone = document.getElementById("telephone");
    const newPassword = document.getElementById("new_password");
    const confirmNewPassword = document.getElementById("confirm_new_password");
    const currentPassword = document.getElementById("current_password");

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

        // Sinon, affichage normal
        bar.style.width = level.width;
        bar.style.backgroundColor = level.color;
        
        text.textContent = `Sécurité : ${level.text}`;
        text.style.color = level.color;
        text.style.fontSize = "0.7rem"; // Taille de police par défaut
    }

    // Ajoute un ✔ vert à côté du champ input

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

    // Fonction pour retirer la coche verte présente

    function removeSuccessMark(input) {
        const mark = input.closest(".mb-3")?.querySelector(".success-mark");
        if (mark) mark.remove();
    }

    // VERIFICATION EN LIVE DES CHAMPS DU FORMULAIRE
    nom.addEventListener("input", () => {
        if (nom.value.trim() === "") {
            showError(nom, "Le nom est requis.");
            removeSuccessMark(nom);
        } else if(nom.checkValidity() === false) {
            showError(nom, "Le nom doit contenir entre 2 et 50 caractères (lettres, espaces, traits d'union).");
            removeSuccessMark(nom);
        } else {
            clearError(nom);
            addSuccessMark(nom);
        }
    });

    prenom.addEventListener("input", () => {
        if (prenom.value.trim() === "") {
            showError(prenom, "Le prénom est requis.");
            removeSuccessMark(prenom);
        } else if(prenom.checkValidity() === false) {
            showError(prenom, "Le prénom doit contenir entre 2 et 50 caractères (lettres, espaces, traits d'union).");
            removeSuccessMark(prenom);
        } else {
            clearError(prenom);
            addSuccessMark(prenom);
        }
    });

    email.addEventListener("input", () => {
        if (email.value.trim() === "") {
            showError(email, "L'adresse email est requise.");
            removeSuccessMark(email);
        } else if(email.checkValidity() === false) {
            showError(email, "L'adresse email est invalide.");
            removeSuccessMark(email);
        } else {
            clearError(email);
            addSuccessMark(email);
        }
    });

    telephone.addEventListener("input", () => {
        const regex = /^[0-9]{10}$/;
        if (telephone.value.trim() !== "") {
            if (!regex.test(telephone.value) || telephone.checkValidity() === false) {
                showError(telephone, "Le numéro doit contenir 10 chiffres.");
                removeSuccessMark(telephone);
            } else {
                clearError(telephone); addSuccessMark(telephone);
            }
        } else {
            clearError(telephone); removeSuccessMark(telephone);
        }
    });

    dateNaissance.addEventListener("input", () => {
        const today = new Date();
        const birthDate = new Date(dateNaissance.value);
        const year = birthDate.getFullYear();
        const currentYear = today.getFullYear();

        if (year < 1900 || year > currentYear) {
            showError(dateNaissance, `L'année doit être comprise entre 1900 et ${currentYear}.`);
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
            clearError(dateNaissance); addSuccessMark(dateNaissance);
        }
    });

    newPassword.addEventListener("input", () => {
        const value = newPassword.value.trim();
        const score = getPasswordStrength(value);
        updateStrengthDisplay(score);

        const regexMaj = /[A-Z]/;
        const regexMini = /[a-z]/;
        const regexChiffre = /[0-9]/;
        const regexSpecial = /[!@#$%^&*(),.?":{}|<>]/;

        if (newPassword.value.length > 0) {
            if (newPassword.value.length < 8) {
                showError(newPassword, "Minimum 8 caractères (1 Maj., 1 Min., 1 chiffre, 1 caractère spécial).");
                removeSuccessMark(newPassword);
            } else if (!regexMaj.test(newPassword.value)) {
                showError(newPassword, "Le mot de passe doit contenir au moins une lettre majuscule.");
                removeSuccessMark(newPassword);
            } else if (!regexMini.test(newPassword.value)) {
                showError(newPassword, "Le mot de passe doit contenir au moins une lettre minuscule.");
                removeSuccessMark(newPassword);
            } else if (!regexChiffre.test(newPassword.value)) {
                showError(newPassword, "Le mot de passe doit contenir au moins un chiffre.");
                removeSuccessMark(newPassword);
            } else if (!regexSpecial.test(newPassword.value)) {
                showError(newPassword, "Le mot de passe doit contenir au moins un caractère spécial exemple : !@#$%^&*().");
                removeSuccessMark(newPassword);
            } else {
                clearError(newPassword);
                addSuccessMark(newPassword);
            }
        } else {
            clearError(newPassword);
        }
    });

    currentPassword.addEventListener("input", () => {
        if (currentPassword.value.trim() === "") {
            clearError(currentPassword);
            removeSuccessMark(currentPassword);
        } else {
            const regexMaj = /[A-Z]/;
            const regexMini = /[a-z]/;
            const regexChiffre = /[0-9]/;
            const regexSpecial = /[!@#$%^&*(),.?":{}|<>]/;
            if (currentPassword.value.length > 0) {
                if (currentPassword.value.length < 8) {
                    showError(currentPassword, "Minimum 8 caractères (1 Maj., 1 Min., 1 chiffre, 1 caractère spécial).");
                    removeSuccessMark(currentPassword);
                } else if (!regexMaj.test(currentPassword.value)) {
                    showError(currentPassword, "Le mot de passe doit contenir au moins une lettre majuscule.");
                    removeSuccessMark(currentPassword);
                } else if (!regexMini.test(currentPassword.value)) {
                    showError(currentPassword, "Le mot de passe doit contenir au moins une lettre minuscule.");
                    removeSuccessMark(currentPassword);
                } else if (!regexChiffre.test(currentPassword.value)) {
                    showError(currentPassword, "Le mot de passe doit contenir au moins un chiffre.");
                    removeSuccessMark(currentPassword);
                } else if (!regexSpecial.test(currentPassword.value)) {
                    showError(currentPassword, "Le mot de passe doit contenir au moins un caractère spécial exemple : !@#$%^&*().");
                    removeSuccessMark(currentPassword);
                } else {
                    clearError(currentPassword);
                    addSuccessMark(currentPassword);
                }
            }
        }
    });

    // 1- VERIFICATION DE L'ANCIEN MOT DE PASSE SI LE NOUVEAU MOT DE PASSE EST REMPLI
    newPassword.addEventListener("input", () => {
        if ( newPassword.value.length > 0) {
            if (currentPassword.value === "") {
                showError(currentPassword, "Le mot de passe actuel est requis pour changer le mot de passe.");
                removeSuccessMark(currentPassword);
            } else {
                if(currentPassword !== "" && newPassword.value===currentPassword.value) {
                    showError(newPassword, "Le nouveau mot de passe ne peut pas être le même que l'ancien actuel.");
                    removeSuccessMark(newPassword); removeSuccessMark(currentPassword);
                } else {
                    clearError(newPassword); clearError(currentPassword);
                    addSuccessMark(newPassword); addSuccessMark(currentPassword);
                }
            }
        } else {
            clearError(newPassword);
            removeSuccessMark(newPassword);
        }
    });

    // 3- CONFIRMATION NOUVEAU MOT DE PASSE
    confirmNewPassword.addEventListener("input", () => {
        if (newPassword.value === "") {
            removeSuccessMark(confirmNewPassword);
            clearError(confirmNewPassword);
            return;
        }

        if (newPassword.value !== confirmNewPassword.value) {
            showError(confirmNewPassword, "Les mots de passe ne correspondent pas.");
            removeSuccessMark(confirmNewPassword);
        } else {
            clearError(confirmNewPassword);
            addSuccessMark(confirmNewPassword);
        }
    });

    const checkPasswords = () => {
        if (newPassword.value === "" && confirmNewPassword.value === "") {
            removeSuccessMark(confirmNewPassword);
            clearError(confirmNewPassword);
            return;
        }

        if(newPassword.value === currentPassword.value && newPassword.value !== "") {
            showError(newPassword, "Le nouveau mot de passe ne peut pas être le même que l'ancien actuel.");
            removeSuccessMark(newPassword);
        } else {
            clearError(newPassword);
            addSuccessMark(newPassword);
        }

        if (newPassword.value !== confirmNewPassword.value) {
            showError(confirmNewPassword, "Les mots de passe ne correspondent pas.");
            removeSuccessMark(confirmNewPassword);
        } else {
            clearError(confirmNewPassword);
            addSuccessMark(confirmNewPassword);
        };
    };

newPassword.addEventListener("input", checkPasswords);
confirmNewPassword.addEventListener("input", checkPasswords);
currentPassword.addEventListener("input", checkPasswords);


    // VALIDATION FINALE AVANT ENVOI

    form.addEventListener("submit", (e) => {
        // On empêche l'envoi  du formulaire si des champs sont invalides
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

        // PRENOM
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

        // TELEPHONE
        const regex = /^[0-9]{10}$/;
        telephone.value.trim() !== "" && !regex.test(telephone.value)
            ? (showError(telephone, "Le numéro doit contenir 10 chiffres."), (hasError = true))
            : clearError(telephone);

        // DATE DE NAISSANCE
        const selectedDate = new Date(dateNaissance.value);
        const today = new Date();
        const age = today.getFullYear() - selectedDate.getFullYear();
        const monthDiff = today.getMonth() - selectedDate.getMonth();
        if (monthDiff < 0 || (monthDiff === 0 && today.getDate() < selectedDate.getDate())) {
            age--;
        }
        age < 15
        ? (showError(dateNaissance, "Vous avez " + age + " ans. Vous devez avoir au moins 15 ans."), (hasError = true))
        : clearError(dateNaissance);
        
        // NOUVEAU MOT DE PASSE

        const regexMaj = /[A-Z]/;
        const regexMini = /[a-z]/;
        const regexChiffre = /[0-9]/;
        const regexSpecial = /[!@#$%^&*(),.?":{}|<>]/;
        if (newPassword.value.length > 0) {
            if (newPassword.value.length < 8) {
                showError(newPassword, "Minimum 8 caractères (1 Maj., 1 Min., 1 chiffre, 1 caractère spécial).");
                hasError = true;
            } else if (!regexMaj.test(newPassword.value)) {
                showError(newPassword, "Le mot de passe doit contenir au moins une lettre majuscule.");
                hasError = true;
            } else if (!regexMini.test(newPassword.value)) {
                showError(newPassword, "Le mot de passe doit contenir au moins une lettre minuscule.");
                hasError = true;
            } else if (!regexChiffre.test(newPassword.value)) {
                showError(newPassword, "Le mot de passe doit contenir au moins un chiffre.");
                hasError = true;
            } else if (!regexSpecial.test(newPassword.value)) {
                showError(newPassword, "Le mot de passe doit contenir au moins un caractère spécial exemple : !@#$%^&*().");
                hasError = true;
            } else {
                clearError(newPassword);
            }
        } else {
            clearError(newPassword);
        }

        // 1- VERIFICATION DE L'ANCIEN MOT DE PASSE SI LE NOUVEAU MOT DE PASSE EST REMPLI
        newPassword.value.length > 0 && currentPassword.value === ""
            ? (showError(currentPassword, "Le mot de passe actuel est requis pour changer le mot de passe."), (hasError = true))
            : clearError(currentPassword);

        // 2- VERIFICATION DU NOUVEAU MOT DE PASSE DIFFÉRENT DE L'ANCIEN MOT DE PASSE
        const currentPassword = document.getElementById("current_password");
        newPassword.value.length > 0 && currentPassword.value === newPassword.value
            ? (showError(newPassword, "Le nouveau mot de passe doit être différent de l'ancien actuel."), (hasError = true))
            : clearError(newPassword);

        // 3- CONFIRMATION NOUVEAU MOT DE PASSE
        newPassword.value !== confirmNewPassword.value
            ? (showError(confirmNewPassword, "Les mots de passe ne correspondent pas."), (hasError = true))
            : clearError(confirmNewPassword);

        // Si des erreurs, empêche la soumission
        if (hasError) {
            e.preventDefault();

            // Afficher un message d'erreur générique
            const oldAlert = form.querySelector(".alert.alert-danger");
            if (oldAlert) oldAlert.remove();

            const errorMessage = document.createElement("div");
            errorMessage.classList.add("alert", "alert-danger");
            errorMessage.textContent = "Veuillez corriger les erreurs avant de soumettre le formulaire.";
            form.prepend(errorMessage);

            // Suppression du message après 10 secondes
            setTimeout(() => {
                const alert = form.querySelector(".alert.alert-danger");
                if (alert) alert.remove();
            }, 10000); // 10 secondes
            

            // Mettre le focus sur le premier champ invalide
            const firstInvalidField = form.querySelector(".is-invalid");
            if (firstInvalidField) firstInvalidField.focus();

            // Scroll vers le haut du formulaire pour voir les erreurs
            form.scrollIntoView({ behavior: 'smooth' });
        }
    });
});
</script>