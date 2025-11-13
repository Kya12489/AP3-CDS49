using AP3_AppliC.Entities;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_AppliC.Modele
{
    public class ModeleLecon
    {
        public static List<Conduire> RecupererLeconsPeriode(DateTime debut, DateTime fin)
        {
            try
            {
                return Connexion.MonModel.Conduires
                    .Where(l => l.Heuredebut >= debut && l.Heuredebut <= fin)
                    .ToList();
            }
            catch
            {
                return new List<Conduire>();
            }
        }

        public static List<object> RecupererDisponibilites(
            DateTime dateHeure,
            int? idEleve,
            int? idMoniteur,
            int? idVehicule)
        {
            var resultats = new List<object>();

            // Logique pour afficher les disponibilités selon ce qui est déjà sélectionné
            // À implémenter selon tes besoins

            return resultats;
        }

        public static bool AjouterLecon(int idEleve, int idMoniteur, int idVehicule, DateTime dateHeure, string lieu)
        {
            try
            {
                Conduire lecon = new Conduire()
                {
                    Ideleve = idEleve,
                    Idmoniteur = idMoniteur,
                    Idvehicule = idVehicule,
                    Heuredebut = dateHeure,
                    Lieurdv = string.IsNullOrWhiteSpace(lieu) ? null : lieu,
                };

                Connexion.MonModel.Conduires.Add(lecon);
                Connexion.MonModel.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
    }
}
