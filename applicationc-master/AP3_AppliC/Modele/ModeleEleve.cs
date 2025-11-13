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

        public static bool AjoutEleve(string nom, string prenom, string email, string mdp, DateOnly dateNaissance, string numTel)
        {
            Eleve unE;
            bool vretour = true;
            try
            {
                // ajout dans la table Eleve
                unE = new Eleve();
                string mdpHash = BC.HashPassword(mdp);

                unE.Nomeleve = nom;
                unE.Prenomeleve = prenom;
                unE.Emaileleve = email;
                unE.Motpasseeleve = mdpHash;
                unE.Datenaissanceeleve = dateNaissance;
                unE.Numeroteleleve = numTel;

                Modele.Connexion.MonModel.Eleves.Add(unE);
                Modele.Connexion.MonModel.SaveChanges();

            }
            catch (Exception ex)
            {
                vretour = false;
                MessageBox.Show(ex.Message.ToString());
            }
            return vretour;
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
                    .Any(e => e.Emaileleve == email);
            }
            catch 
            {
                return false;
            }
        }
    }
}
