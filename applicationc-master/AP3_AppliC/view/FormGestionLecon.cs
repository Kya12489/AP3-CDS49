using AP3_AppliC.Modele;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP3_AppliC.view
{
    public partial class FormGestionLecon : Form
    {
        public FormGestionLecon()
        {
            InitializeComponent();

            cbMoniteur.ValueMember = "Idmoniteur";//permet de stocker l'identifiant
            cbMoniteur.DisplayMember = "nomComplet";
            bsMoniteur.DataSource = (Modele.ModeleMoniteur.listeMoniteurs()).Select(x => new { x.Idmoniteur, nomComplet = x.Nommoniteur + " " + x.Prenommoniteur }).OrderBy(x => x.nomComplet); ;
            cbMoniteur.DataSource = bsMoniteur;
            cbMoniteur.SelectedIndex = -1;

            cbEleve.ValueMember = "Ideleve";//permet de stocker l'identifiant
            cbEleve.DisplayMember = "nomComplet";
            bsEleve.DataSource = (Modele.ModeleEleve.listeEleves()).Select(x => new { x.Ideleve, nomComplet = x.Nomeleve + " " + x.Prenomeleve }).OrderBy(x => x.nomComplet); ;
            cbEleve.DataSource = bsEleve;
            cbEleve.SelectedIndex = -1;

            cbVehicule.ValueMember = "Idvehicule";
            cbVehicule.DisplayMember = "Immatriculation";
            bsVehicule.DataSource = Modele.ModeleVehicule.listeVehicules().OrderBy(v => v.Immatriculation);
            cbVehicule.DataSource = bsVehicule;
            cbVehicule.SelectedIndex = -1;

            var lieux = ModeleLecon.ObtenirLieuxDepuisConduire();
            cbLieu.DataSource = lieux;
            cbLieu.SelectedIndex = -1;
        }

        private void btAjout_Click(object sender, EventArgs e)
        {
            /*
            // Récupérer les valeurs sélectionnées
            int idEleve = (int)cbEleve.SelectedValue;
            int idMoniteur = (int)cbMoniteur.SelectedValue;
            int idVehicule = (int)cbVehicule.SelectedValue; // À adapter selon ton ComboBox
            DateTime dateHeure = dtpLecon.Value;
            //dateHeure = dateHeure.AddHours(double.Parse("14")); // Par défaut, ajoute 14h (à adapter selon ton interface)


            // Appeler la méthode pour ajouter la leçon
            bool succes = ModeleLecon.AjouterLecon(idEleve, idMoniteur, idVehicule, dateHeure, lieu);

            // Afficher un message à l'utilisateur
            if (succes)
                MessageBox.Show("Leçon ajoutée avec succès !");
            else
                MessageBox.Show("Erreur lors de l'ajout de la leçon.");
            */

            // Vérifier que tous les champs sont sélectionnés
            if (cbEleve.SelectedValue == null ||
                cbMoniteur.SelectedValue == null ||
                cbVehicule.SelectedValue == null ||
                cbLieu.SelectedItem == null ||
                cbLieu.SelectedItem.ToString() == "-- Sélectionnez un lieu --")
            {
                MessageBox.Show("Veuillez sélectionner un élève, un moniteur, un véhicule et un lieu.");
                return;
            }

            // Récupérer les valeurs sélectionnées
            int idEleve = (int)cbEleve.SelectedValue;
            int idMoniteur = (int)cbMoniteur.SelectedValue;
            int idVehicule = (int)cbVehicule.SelectedValue;
            DateTime dateHeure = dtpLecon.Value;

            // Récupérer le lieu sélectionné
            string lieu = cbLieu.SelectedItem.ToString();

            // Appeler la méthode pour ajouter la leçon
            bool succes = ModeleLecon.AjouterLecon(idEleve, idMoniteur, idVehicule, dateHeure, lieu);

            // Afficher un message à l'utilisateur
            if (succes)
                MessageBox.Show("Leçon ajoutée avec succès !");
            else
                MessageBox.Show("Erreur lors de l'ajout de la leçon.");
        }
    }
}
