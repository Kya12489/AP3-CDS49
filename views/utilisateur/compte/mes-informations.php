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
                            <?= htmlspecialchars($error) ?>
                        </div>
                    <?php } ?>

                    <?php if (!empty($success)) { ?>
                        <div class="alert alert-success" role="alert">
                            <?= htmlspecialchars($success) ?>
                        </div>
                    <?php } ?>

                    <form method="POST" action="/mon-compte/profil.html">
                        <div class="mb-3">
                            <label for="nom" class="form-label">Nom</label>
                            <input type="text" class="form-control" id="nom" name="nom" value="<?= htmlspecialchars(isset($nomeleve) ? $nomeleve : ''); ?>">
                        </div>
                        <div class="mb-3">
                            <label for="prenom" class="form-label">Prénom</label>
                            <input type="text" class="form-control" id="prenom" name="prenom" value="<?= htmlspecialchars(isset($prenomeleve) ? $prenomeleve : ''); ?>">
                            <div class="mb-3">
                                <label for="email" class="form-label">Email</label>
                                <input type="email" class="form-control" id="email" name="email" value="<?= htmlspecialchars(isset($emaileleve) ? $emaileleve : ''); ?>">
                            </div>
                            <div class="mb-3">
                                <label for="datenaissance" class="form-label">Date de naissance</label>
                                <input type="date" class="form-control" id="datenaissance" name="datenaissance" value="<?= htmlspecialchars(isset($datenaissanceeleve) ? $datenaissanceeleve : ''); ?>">
                            </div>

                            <!-- AJOUT DU CHAMP TÉLÉPHONE DANS LE FORMULAIRE - MISE À JOUR FACULTATIVE DU NUMERO PAR L'ÉLÈVE -- LOT 1 -->
                            <div class="mb-3">
                                <label for="telephone" class="form-label">Téléphone</label>
                                <input type="text" class="form-control" id="telephone" name="telephone" value="<?= htmlspecialchars(isset($telephoneeleve) ? $telephoneeleve : ''); ?>">
                            </div>
                            <!-- FIN DU CHAMP TÉLÉPHONE LOT 1 -->

                            <!-- BONUS - CHANGEMENT DE MOT DE PASSE EN SACHANT QUE LE MOT DE PASSE ACTUEL N'EST PAS AFFICHÉ DANS LE FORMULAIRE ET EST REQUIS POUR LE CHANGEMENT
                             EN SECURISANT LES CHAMPS DE SAISIE (htmlspecialchars, pas d'injection, normes de sécurité de saisie) - LOT 1 -->
                            
                            <div class="mb-3">
                                <label for="current_password" class="form-label">Mot de passe actuel (requis si changement, pour des raisons de sécurité)</label>
                                <input type="password" class="form-control" id="current_password" name="current_password" >
                            </div>
                            
                            <!-- NOUVEAU MOT DE PASSE SI LE MOT DE PASSE EST MODIFIÉ, SINON IL RESTE LE MÊME (NON MODIFIÉ) -->
                            <div class="mb-3">
                                <label for="new_password" class="form-label">Nouveau mot de passe (laisser vide pour ne pas changer)</label>
                                <input type="password" class="form-control" id="new_password" name="new_password">
                            </div>
                            <div class="mb-3">
                                <label for="confirm_new_password" class="form-label">Confirmer le nouveau mot de passe</label>
                                <input type="password" class="form-control" id="confirm_new_password" name="confirm_new_password">
                            </div>
                            <!-- FIN DU NOUVEAU MOT DE PASSE -->
                            <!-- FIN DU BONUS CHANGEMENT DE MOT DE PASSE -->

                            <div class="text-center pt-3">
                                <button type="submit" class="btn btn-primary">Mettre à jour le profil</button>
                            </div>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    </section>
</main>