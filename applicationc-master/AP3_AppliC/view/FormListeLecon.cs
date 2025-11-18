using AP3_AppliC.Entities;
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
    public partial class FormListeLecon : Form
    {
        public FormListeLecon()
        {
            InitializeComponent();
            ChargerDonnees();
        }



        private void ChargerDonnees()
        {
            var lecons = ModeleLecon.ObtenirLecons();
            var affichage = lecons.Select(c => new
            {
                Date = c.Heuredebut.Date,
                Début = c.Heuredebut,
                Fin = c.Heuredebut.AddMinutes(c.DureeMinutes),
                Durée = c.DureeMinutes + " min",
                Élève = c.IdeleveNavigation.Nomeleve + " " + c.IdeleveNavigation.Prenomeleve,
                Moniteur = c.IdmoniteurNavigation.Nommoniteur + " " + c.IdmoniteurNavigation.Prenommoniteur,
                Véhicule = c.IdvehiculeNavigation.Designation,
                Immatriculation = c.IdvehiculeNavigation.Immatriculation,
                Lieu = c.Lieurdv,

                // IDs cachés mais utiles
                IdEleve = c.Ideleve,
                IdMoniteur = c.Idmoniteur,
                IdVehicule = c.Idvehicule,
                HeureDebut = c.Heuredebut
            }).ToList();

            dgvLecon.DataSource = affichage;

            ConfigurerColonnes();
        }

        private void ConfigurerColonnes()
        {
            // Cacher les IDs
            dgvLecon.Columns["IdEleve"].Visible = false;
            dgvLecon.Columns["IdMoniteur"].Visible = false;
            dgvLecon.Columns["IdVehicule"].Visible = false;
            dgvLecon.Columns["HeureDebut"].Visible = false;

            dgvLecon.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvLecon.Columns["Début"].DefaultCellStyle.Format = "HH:mm";
            dgvLecon.Columns["Fin"].DefaultCellStyle.Format = "HH:mm";
        }

        private void btSupp_Click(object sender, EventArgs e)
        {
            // Vérifier qu'une ligne est sélectionnée dans la DataGridView
            if (dgvLecon.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une leçon à supprimer.");
                return;
            }

            // Récupérer la ligne sélectionnée
            DataGridViewRow selectedRow = dgvLecon.SelectedRows[0];

            try
            {
                // Récupérer les valeurs nécessaires pour identifier la leçon
                int idEleve = (int)selectedRow.Cells["Ideleve"].Value;
                int idMoniteur = (int)selectedRow.Cells["Idmoniteur"].Value;
                int idVehicule = (int)selectedRow.Cells["Idvehicule"].Value;
                DateTime heureDebut = (DateTime)selectedRow.Cells["Heuredebut"].Value;

                // Demander confirmation à l'utilisateur
                DialogResult result = MessageBox.Show("Voulez-vous vraiment supprimer cette leçon ?", "Confirmation", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    return;
                }

                // Appeler la méthode pour supprimer la leçon
                bool succes = ModeleLecon.SupprimerLecon(idEleve, idMoniteur, idVehicule, heureDebut);

                // Afficher un message à l'utilisateur
                if (succes)
                {
                    MessageBox.Show("Leçon supprimée avec succès !");
                    // Rafraîchir la DataGridView pour refléter les modifications
                    RafraichirListeLecons();
                }
                else
                {
                    MessageBox.Show("Erreur lors de la suppression de la leçon.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de la leçon : {ex.Message}");
            }
        }
        private void RafraichirListeLecons()
        {
            // Vider la source de données actuelle
            dgvLecon.DataSource = null;

            // Récupérer la liste des leçons
            var lecons = ModeleLecon.ObtenirLecons();

            // Mettre à jour la source de données de la DataGridView
            dgvLecon.DataSource = lecons;

            // Rafraîchir visuellement la DataGridView
            dgvLecon.Refresh();
        }
        
    }
}