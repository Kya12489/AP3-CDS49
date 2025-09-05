using AP3_AppliC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_AppliC.Modele
{
    public static class ModeleForfait
    {
        /// <summary>
        /// Liste tous les forfaits
        /// </summary>
        /// <returns></returns>
        public static List<Forfait> listeForfaits()
        {
            return Modele.Connexion.MonModel.Forfaits.ToList();
        }

        /// <summary>
        /// Récupère l'objet FORFAIT correspondant à l'identifiant passé en paramètre
        /// </summary>
        /// <param name="idForfait"></param>
        /// <returns></returns>
        public static Forfait RecupererForfait(int idForfait)
        {
            Forfait unF = new Forfait();
            try
            {
                unF = Modele.Connexion.MonModel.Forfaits.First(x => x.Idforfait == idForfait);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return unF;
        }
        /// <summary>
        /// Supprime un forfait dont l'identifiant est passé en paramètre
        /// </summary>
        /// <param name="idForfait"></param>
        /// <returns></returns>
        public static bool SupprimerForfait(int idForfait)
        {
            bool vretour = true;
            try
            {
                Forfait monF = RecupererForfait(idForfait);
                Modele.Connexion.MonModel.Forfaits.Remove(monF); // correspond au DELETE
                Modele.Connexion.MonModel.SaveChanges();
            }
            catch (Exception ex)
            {
               // System.Windows.Forms.MessageBox.Show(ex.Message);
                vretour = false;
            }
            return vretour;
        }

    }
}
