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
    public partial class FormAjoutVehicules : Form
    {
        public FormAjoutVehicules()
        {
            InitializeComponent();

            cbType.Items.Add("Manuel");
            cbType.Items.Add("Automatique");
            cbType.SelectedIndex = 0;
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            int? nbPassagers = null;  // Nullable car optionnel

            // Si le champ n'est pas vide essaie de le convertir
            if (!string.IsNullOrWhiteSpace(tbNbPassagers.Text))
            {
                if (int.TryParse(tbNbPassagers.Text, out int valeur))
                {
                    nbPassagers = valeur;  // Conversion réussie
                }
                else
                {
                    MessageBox.Show("Le nombre de passagers doit être un nombre entier valide.");
                    return;  // Arrête l'exécution si erreur
                }
            }
            string immatriculation = tbImmatriculation.Text;
            string designation = string.IsNullOrWhiteSpace(tbDesignation.Text) ? null : tbDesignation.Text;
            string mode = cbType.SelectedItem.ToString();

            bool ajout = Modele.ModeleVehicule.AjoutVehicule(nbPassagers, immatriculation, designation, mode);

            if (ajout)
            {
                MessageBox.Show("Véhicule ajoutée");
                tbImmatriculation.Clear(); //remet à zéro l'immatriculation
            }
            else
            {
                MessageBox.Show("Erreur lors de l'ajout");
            }
        }

        private void tbImmatriculation_TextChanged(object sender, EventArgs e)
        {
            string immatriculation = tbImmatriculation.Text.Trim();

            // Ne vérifier que si le champ n'est pas vide
            if (!string.IsNullOrWhiteSpace(immatriculation))
            {
                bool existe = Modele.ModeleVehicule.ImmatriculationExiste(immatriculation);

                if (existe)
                {
                    MessageBox.Show($"L'immatriculation '{immatriculation}' existe déjà !",
                        "Doublon", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    tbImmatriculation.Clear();  // Vider automatiquement
                    tbImmatriculation.Focus();  // Remettre le focus sur le champ
                }
            }
        }
    }
}
