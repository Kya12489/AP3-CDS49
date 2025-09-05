using AP3_AppliC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_AppliC.Modele
{
    public static class ModeleMoniteur
    {
        /// <summary>
        /// Liste tous les moniteurs
        /// </summary>
        /// <returns></returns>
        public static List<Moniteur> listeMoniteurs()
        {
            return Modele.Connexion.MonModel.Moniteurs.ToList();
        }

        /// <summary>
        /// Récupère l'objet MONITEUR correspondant à l'identifiant passé en paramètre
        /// </summary>
        /// <param name="idMoniteur"></param>
        /// <returns></returns>
        public static Moniteur RecupererMoniteur(int idMoniteur)
        {
            Moniteur unM = new Moniteur();
            try
            {
                unM = Modele.Connexion.MonModel.Moniteurs.First(x => x.Idmoniteur == idMoniteur);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return unM;
        }

        /// <summary>
        /// Retourne vrai si l'ajout d'un moniteur a pu avoir lieu
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool AjoutMoniteur(string nom, string prenom, string email)
        {
            Moniteur unM;
            bool vretour = true;
            try
            {
                // ajout dans la table Moniteur
                unM = new Moniteur();
                unM.Nommoniteur = nom;
                unM.Prenommoniteur = prenom;
                unM.Emailmoniteur = email;

                Modele.Connexion.MonModel.Moniteurs.Add(unM);
                Modele.Connexion.MonModel.SaveChanges();

            }
            catch (Exception ex)
            {
                vretour = false;
                MessageBox.Show(ex.Message.ToString());
            }
            return vretour;
        }

        /// <summary>
        /// Retourne vrai si la modification d'un moniteur a pu avoir lieu (id passé en paramètre)
        /// </summary>
        /// <param name="idM"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="email"></param>
        /// <returns></returns>
        public static bool ModificationMoniteur(int idM, string nom, string prenom, string email)
        {
            Moniteur unM;
            bool vretour = true;
            try
            {
                // récupération de l'hackathon à modifier
                unM = RecupererMoniteur(idM);

                // mise à jour des champs de l'hackathon
                unM.Nommoniteur = nom;
                unM.Prenommoniteur = prenom;
                unM.Emailmoniteur = email;

                Modele.Connexion.MonModel.SaveChanges();
            }
            catch (Exception ex)
            {
                vretour = false;
                MessageBox.Show(ex.Message.ToString());
            }
            return vretour;
        }
    }
}
