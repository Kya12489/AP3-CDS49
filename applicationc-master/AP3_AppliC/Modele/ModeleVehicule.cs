using AP3_AppliC.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_AppliC.Modele
{
    public class ModeleVehicule
    {
        public static List<Entities.Vehicule> listeVehicules()
        {
            return Modele.Connexion.MonModel.Vehicules.ToList();
        }

        public static bool AjoutVehicule(int ?nbPassagers, string immatriculation, string ?designation, string mode)
        {
            Vehicule unV;
            bool vretour = true;
            try
            {
                // ajout dans la table Vehicule
                unV = new Vehicule();

                unV.Nbpassagers = nbPassagers;
                unV.Immatriculation = immatriculation;
                unV.Designation = designation;

                if (mode == "Manuel")
                {
                    unV.Manuel = false;
                }
                else
                {
                    unV.Manuel = true;
                }

                Modele.Connexion.MonModel.Vehicules.Add(unV);
                Modele.Connexion.MonModel.SaveChanges();

            }
            catch (Exception ex)
            {
                vretour = false;
                MessageBox.Show(ex.Message.ToString());
            }
            return vretour;
        }
        // vérifier si l'immatriculation existe
        public static bool ImmatriculationExiste(string immatriculation)
        {
            try
            {
                return Modele.Connexion.MonModel.Vehicules
                    .Any(v => v.Immatriculation == immatriculation);
            }
            catch
            {
                return false;
            }
        }
    }


}
