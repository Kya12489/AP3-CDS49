<main class="container mt-5 pt-5 mb-5">
    <section id="connexion-form" class="py-5">
        <div class="row justify-content-center">
            <div class="col-lg-5">
                <div class="text-center mb-4">
                    <img src="/public/images/logo_cds49.jpeg" alt="Logo CDS 49" style="max-width: 150px; border-radius: 10px;">
                </div>
                <h2 class="display-5 fw-light text-center mb-4">Connexion</h2>

                <!--

                <?php if (!empty($error)) { ?>
                    <div class="alert alert-danger" role="alert">
                        <?= htmlspecialchars($error, ENT_QUOTES | ENT_HTML5, 'UTF-8') ?>
                    </div>
                <?php } ?>

                <?php if (!empty($success)) { ?>
                    <div class="alert alert-success" role="alert">
                        <?= htmlspecialchars($success, ENT_QUOTES | ENT_HTML5, 'UTF-8') ?>
                    </div>
                <?php } ?>
                -->


                

                
                <?php if (!empty($expiredMessage)) { ?>
                    <div class="alert alert-warning alert-dismissible fade show" role="alert">
                        <strong>Attention :</strong> <?= htmlspecialchars($expiredMessage, ENT_QUOTES | ENT_HTML5, 'UTF-8') ?>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Fermer"></button>
                    </div>
                <?php } ?>

                <?php if (!empty($error)) { ?>
                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                        <?= htmlspecialchars($error, ENT_QUOTES | ENT_HTML5, 'UTF-8') ?>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Fermer"></button>
                    </div>
                <?php } ?>

                <?php if (!empty($success)) { ?>
                    <div class="alert alert-success alert-dismissible fade show" role="alert">
                        <?= htmlspecialchars($success, ENT_QUOTES | ENT_HTML5, 'UTF-8') ?>
                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Fermer"></button>
                    </div>
                <?php } ?>
                

                <form method="POST" action="connexion.html">
                    <div class="mb-3">
                        <label for="email" class="form-label">Adresse Email</label>
                        <input type="email" class="form-control" id="email" name="email" maxlength="100" pattern="^[^\s@]+@[^\s@]+\.[^\s@]+$"
                        autocomplete="email" inputmode="email" required>
                    </div>
                    <div class="mb-3">
                        <label for="password" class="form-label">Mot de passe</label>
                        <input type="password" class="form-control" id="password" name="password" maxlength="128" required>
                    </div>
                    <div class="mb-3 form-check">
                        <input type="checkbox" class="form-check-input" id="remember-me" name="remember_me">
                        <label class="form-check-label" for="remember-me">Se souvenir de moi</label>
                    </div>
                    <div class="d-grid">
                        <input type="hidden" name="csrf_token" value="<?= htmlspecialchars($_SESSION['csrf_token'] ?? '', ENT_QUOTES | ENT_HTML5, 'UTF-8') ?>">
                        <button type="submit" class="btn btn-primary btn-lg">Se connecter</button>
                    </div>
                </form>
                <p class="text-center mt-4">
                    Pas encore de compte ? <a href="creer-compte.html">Créez-en un ici</a>.
                </p>
                <p class="text-center mt-2">
                    <a href="mot-de-passe-oublie.html">Mot de passe oublié ?</a>
                </p>
            </div>
        </div>
    </section>
</main>

<!-- Script de validation côté client pour le formulaire d'inscription à adapter ici pour la connexion-->

<script>
document.addEventListener("DOMContentLoaded", function() {
    const form = document.querySelector("form");
    const email = document.getElementById("email");
    const password = document.getElementById("password");

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
        input.classList.remove("is-invalid");
    }

    // Vérifications en live
    
    email.addEventListener("input", () => {
        if(email.checkValidity() === false) {
            if(email.value.trim() === "") {
                showError(email, "L'adresse email est requise.");
            } else {
                showError(email, "L'adresse email est invalide.");
            }
        } else {
            clearError(email);
        }
    });

    password.addEventListener("input", () => {
        password.value.trim() === "" ? showError(password, "Le mot de passe est requis.") : clearError(password);
    });


    // Vérification avant soumission
    form.addEventListener("submit", (e) => {
        let hasError = false;

        // Vérification de l'email
        email.checkValidity() === false
            ? (showError(email, "L'adresse email est invalide."), (hasError = true))
            : clearError(email);

        // Vérification du mot de passe
        password.value.trim() === ""
            ? (showError(password, "Le mot de passe est requis."), (hasError = true))
            : clearError(password);
        
        // Si des erreurs, empêche la soumission
        if (hasError) {
            e.preventDefault();

            // Afficher un message d'erreur générique
            const errorMessage = document.createElement("div");
            errorMessage.classList.add("error-message", "text-danger", "mt-3");
            errorMessage.textContent = "Veuillez corriger les erreurs dans le formulaire.";
            form.prepend(errorMessage);

            // Focus sur le premier champ avec erreur
            const firstErrorInput = form.querySelector(".is-invalid");
            if (firstErrorInput) {
                firstErrorInput.focus();
            }

            // Scroll vers le haut du formulaire pour voir les erreurs
            form.scrollIntoView({ behavior: 'smooth' });
        }
    });
});
</script>