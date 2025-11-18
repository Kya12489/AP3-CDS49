using AP3_AppliC.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.ComponentModel.Design.ObjectSelectorEditor;
using BC = BCrypt.Net.BCrypt;


namespace AP3_AppliC.Modele
{
    public static class ModeleEleve
    {
        /// <summary>
        /// Retourne la liste des élèves
        /// </summary>
        /// <returns></returns>
        public static List<Entities.Eleve> listeEleves()
        {
            return Modele.Connexion.MonModel.Eleves
                .Where(e => e.Archiver == false)  // Filtrer les non-archivés
                .ToList();
        }

        /// <summary>
        /// Récupère l'objet entier de l'élève dont l'identifiant est passé en paramètre
        /// </summary>
        /// <param name="idE"></param>
        /// <returns></returns>
        public static Eleve RecupererEleve(int idE)
        {
            Eleve unE = new Eleve();
            try
            {
                unE = Modele.Connexion.MonModel.Eleves.First(x => x.Ideleve == idE);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return unE;
        }

        /// <summary>
        /// Liste les forfaits de l'élève passé en paramètre 
        /// </summary>
        /// <param name="idE"></param>
        /// <returns></returns>
        public static List<Inscrire> listeForfaitsParEleve(int idE)
        {
            // récupère les inscriptions de cet élève passé en paramètre
            Eleve E = Modele.Connexion.MonModel.Eleves.Include(p => p.Inscrires).ThenInclude(p => p.IdforfaitNavigation).First(x => x.Ideleve == idE);

            List<Inscrire> lesI = E.Inscrires.ToList();

            return lesI;
        }

        /// <summary>
        /// Permet d'ajouter une attribution de forfait à un élève
        /// </summary>
        /// <param name="idEeleve"></param>
        /// <param name="idForfait"></param>
        /// <returns></returns>
        public static bool AjoutInscrire(int idEeleve, int idForfait)
        {
            Inscrire uneInscr;
            bool vretour = true;
            try
            {
                // ajout dans la table Inscrire
                uneInscr = new Inscrire();
                uneInscr.Ideleve = idEeleve;
                uneInscr.Idforfait = idForfait;
                // date du jour ajoutée
                uneInscr.Dateinscription = DateOnly.FromDateTime(DateTime.Today.Date);

                Modele.Connexion.MonModel.Inscrires.Add(uneInscr);
                Modele.Connexion.MonModel.SaveChanges();

            }
            catch (Exception ex)
            {
                vretour = false;
                // MessageBox.Show(ex.Message.ToString());
            }
            return vretour;
        }

        public static List<Eleve> RechercherEleves(string nom = null, string prenom = null)
        {
            List<Eleve> tousLesEleves = Modele.Connexion.MonModel.Eleves.Where(e => e.Archiver == false).ToList();
            List<Eleve> elevesCorrespondants = tousLesEleves;

            if (!string.IsNullOrEmpty(nom))
            {
                string nomRecherche = nom.Trim().ToLower();

                elevesCorrespondants = elevesCorrespondants
                    .Where(eleve => eleve.Nomeleve.ToLower().Contains(nomRecherche))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(prenom))
            {
                string prenomRecherche = prenom.Trim().ToLower();

                elevesCorrespondants = elevesCorrespondants
                    .Where(eleve => eleve.Prenomeleve.ToLower().Contains(prenomRecherche))
                    .ToList();
            }

            return elevesCorrespondants;
        }

        public static Eleve AjoutEleve(string nom, string prenom, string email, string mdp, DateOnly dateNaissance, string numTel)
        {
            //bool vretour = true;
            try
            {
                // ajout dans la table Eleve
                Eleve unE = new Eleve();
                string mdpHash = BC.HashPassword(mdp);

                unE.Nomeleve = nom;
                unE.Prenomeleve = prenom;
                unE.Emaileleve = email;
                unE.Motpasseeleve = mdpHash;
                unE.Datenaissanceeleve = dateNaissance;
                unE.Numeroteleleve = numTel;

                Modele.Connexion.MonModel.Eleves.Add(unE);
                Modele.Connexion.MonModel.SaveChanges();

                return unE;
            }
            catch (Exception ex)
            {
                // vretour = false;
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
           // return vretour;
        }

        #region recherche global
        public static List<Eleve> RechercherElevesGlobal(string recherche)
        {
            if (string.IsNullOrEmpty(recherche))
            {
                return listeEleves();
            }

            List<Eleve> tousLesEleves = Modele.Connexion.MonModel.Eleves.ToList();

            string texteRecherche = recherche.Trim().ToLower();

            List<Eleve> elevesCorrespondants = tousLesEleves
                .Where(eleve => eleve.Nomeleve.ToLower().Contains(texteRecherche) || eleve.Prenomeleve.ToLower().Contains(texteRecherche))
                .ToList();

            return elevesCorrespondants;
        }
        #endregion

        //public static List<Inscrire> listeInscri()
        //{
        //    return Modele.Connexion.MonModel.Inscrires.ToList();
        //}

        //public static List<(string, int)> nbEleveParMois()
        //{
        //    List<string> lesMois = new List<string> {
        //        "Janvier","Fevrier","Mars","Avril","Mai","Juin","Juillet","Août","Septembre","Octobre","Novembre","Decembre"
        //    };
        //    // SELECT MONTHNAME(dateinscription), COUNT(ideleve) FROM inscrire GROUP BY MONTHNAME(dateinscription);
        //    List<(string, int)> nbEleveMois = new List<(string, int)>();
        //    foreach (string mois in lesMois) {
        //        nbEleveMois.Add((mois, 0));
        //    }
        //    foreach (Inscrire insc in listeInscri()) 
        //    { 
        //        int numMois = Convert.ToInt32(insc.Dateinscription.ToString().Split("-")[1])-1;
        //        nbEleveMois[lesMois[numMois]] ++;
        //    }


        //    return nbEleveMois;
        //}

        public static bool EmailExiste(string email)
        {
            try
            {
                return Modele.Connexion.MonModel.Eleves
                    .Any(e => e.Emaileleve == email
                            && e.Archiver == false);
            }
            catch 
            {
                return false;
            }
        }
        public static bool EmailExisteModif(string email, int idEleveAExclure)
        {
            try
            {
                return Modele.Connexion.MonModel.Eleves
                    .Any(e => e.Emaileleve == email
                           && e.Archiver == false
                           && e.Ideleve != idEleveAExclure);  
            }
            catch
            {
                return false;
            }
        }
       

        public static Eleve ModifierEleve(int idEleves, string nom, string prenom, string email, string mdp, DateOnly dateNaissance, string numTel)
        {
            try
            {
                Eleve eleve = Modele.Connexion.MonModel.Eleves
                    .FirstOrDefault(v => v.Ideleve == idEleves);
                if (eleve == null)
                {
                    MessageBox.Show("Eleve introuvable");
                    return null;
                }

                eleve.Nomeleve = nom;
                eleve.Prenomeleve = prenom;
                eleve.Emaileleve = email;
                eleve.Motpasseeleve = BC.HashPassword(mdp);
                eleve.Datenaissanceeleve = dateNaissance;
                eleve.Numeroteleleve = numTel;

                Modele.Connexion.MonModel.SaveChanges();
                return eleve;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }
        public static Eleve ObtenirEleve(int idEleve)
        {
            try
            {
                return Modele.Connexion.MonModel.Eleves
                    .FirstOrDefault(e => e.Ideleve == idEleve && e.Archiver == false);
            }

            catch
            {
                return null;
            }
        }

        public static bool ArchiverEleve(int idEleve)
        {
            try
            {
                Eleve eleve = Modele.Connexion.MonModel.Eleves
                    .FirstOrDefault(e => e.Ideleve == idEleve);

                if (eleve != null)
                {
                    eleve.Archiver = true;  // Archiver (1)
                    Modele.Connexion.MonModel.SaveChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }

        public static List<(DateOnly, int)> nbEleveParMois()
        {
            using (var context = new Ap3LwsContext())
            {
                // Date de début : il y a 12 mois
                DateOnly dateDebut = DateOnly.FromDateTime(DateTime.Now.AddMonths(-12));

                // Requête pour compter les inscriptions par mois
                var resultats = context.Inscrires
                    .AsEnumerable() // Passage en mémoire d'abord
                    .Where(i => i.Dateinscription >= dateDebut)
                    .GroupBy(i => new
                    {
                        Annee = i.Dateinscription.Year,
                        Mois = i.Dateinscription.Month
                    })
                    .Select(g => new
                    {
                        Date = new DateOnly(g.Key.Annee, g.Key.Mois, 1),
                        Nombre = g.Count()
                    })
                    .OrderBy(x => x.Date)
                    .Select(x => (x.Date, x.Nombre))
                    .ToList();

                // Remplir les mois manquants avec 0
                return RemplirMoisManquants(resultats);
            }
        }



        private static List<(DateOnly, int)> RemplirMoisManquants(List<(DateOnly, int)> donnees)
        {
            List<(DateOnly, int)> resultatComplet = new List<(DateOnly, int)>();
            DateTime dateActuelle = DateTime.Now;

            // Parcourir les 12 derniers mois
            for (int i = 11; i >= 0; i--)
            {
                DateTime mois = dateActuelle.AddMonths(-i);
                DateOnly dateMois = new DateOnly(mois.Year, mois.Month, 1);

                // Chercher si ce mois existe dans les données
                var trouve = donnees.FirstOrDefault(d => d.Item1 == dateMois);

                if (trouve != default)
                {
                    resultatComplet.Add(trouve);
                }
                else
                {
                    // Mois sans inscription : ajouter avec 0
                    resultatComplet.Add((dateMois, 0));
                }
            }

            return resultatComplet;
        }

        public static List<(int, string)> proportionForfait()
        {
            using (var context = new Ap3LwsContext())
            {
                // Requête pour compter le nombre d'inscriptions par forfait
                var resultats = context.Inscrires
                    .GroupBy(i => i.IdforfaitNavigation.Libelleforfait)
                    .Select(g => new
                    {
                        NomForfait = g.Key,
                        Nombre = g.Count()
                    })
                    .OrderByDescending(x => x.Nombre) // Trier du plus populaire au moins populaire
                    .ToList() // Exécution de la requête SQL ici
                    .Select(x => (x.Nombre, x.NomForfait)) // Conversion en tuple en C#
                    .ToList();

                return resultats;
            }
        }
    }
}
