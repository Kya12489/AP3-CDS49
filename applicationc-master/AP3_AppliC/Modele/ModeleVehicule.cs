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
        public static List<Entities.Vehicule> listeTousVehicules()
        {
            return Modele.Connexion.MonModel.Vehicules.ToList();
        }

        public static List<Entities.Vehicule> listeVehicules()
        {
            return Modele.Connexion.MonModel.Vehicules
                .Where(v => v.Archiver == false)  // Filtrer les non-archivés
                .ToList();
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
                    unV.Manuel = true;
                }
                else
                {
                    unV.Manuel = false;
                }

                unV.Archiver = false;

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

        public static bool ArchiverVehicule(int idVehicule)
        {
            try
            {
                Vehicule vehicule = Modele.Connexion.MonModel.Vehicules
                    .FirstOrDefault(v => v.Idvehicule == idVehicule);

                if (vehicule != null)
                {
                    vehicule.Archiver = true;  // Archiver (1)
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

        public static Vehicule ObtenirVehicule(int idVehicule)
        {
            try
            {
                return Modele.Connexion.MonModel.Vehicules
                    .FirstOrDefault(v => v.Idvehicule == idVehicule && v.Archiver == false);
            }

            catch
            {
                return null;
            }
        }

        public static bool ModifierVehicule(int idVehicules, int? nbPassagers, string immatriculation, string? designation, string mode)
        {
            try
            {
                Vehicule vehicule = Modele.Connexion.MonModel.Vehicules
                    .FirstOrDefault(v => v.Idvehicule == idVehicules);
                if (vehicule == null)
                {
                    MessageBox.Show("Vehicule introuvable");
                    return false;
                }

                vehicule.Nbpassagers = nbPassagers;
                vehicule.Immatriculation = immatriculation;
                vehicule.Designation = string.IsNullOrWhiteSpace(designation) ? null : designation;
                vehicule.Manuel = mode == "Manuel";

                Modele.Connexion.MonModel.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return false;
            }
        }
    }


}
