using AP3_AppliC.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return Modele.Connexion.MonModel.Eleves.ToList();
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
    }
}
