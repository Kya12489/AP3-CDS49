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
    public partial class FormListeVehicules : Form
    {
        public FormListeVehicules()
        {
            InitializeComponent();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormListeVehicules_Load(object sender, EventArgs e)
        {
            bsVehicules.DataSource = Modele.ModeleVehicule.listeVehicules().Select(static x => new
            {
                x.Idvehicule,
                x.Nbpassagers,
                x.Immatriculation,
                x.Designation,
                Boite = x.Manuel == true ? "Manuel" : "Automatique"
            }).OrderBy(x => x.Idvehicule);

            dgvVehicules.DataSource = bsVehicules;
            dgvVehicules.Columns["Idvehicule"].Visible = false;

            dgvVehicules.Columns["Boite"].HeaderText = "Boîte de vitesses";
            // Empêche toute sélection
            dgvVehicules.ClearSelection();

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dgvVehicules.CurrentRow != null)
            {
                int idVehicule = (int)dgvVehicules.CurrentRow.Cells["Idvehicule"].Value;

                // Ouvrir le formulaire en mode MODIFICATION avec l'ID
                // FormGestionVehicules formModif = new FormGestionVehicules(EtatGestionV.Update, idVehicule);
                FormMenu.Instance.openChildForm(new FormGestionVehicules(AP3_AppliC.view.EtatGestionV.Update, idVehicule));

                /*
                if (formModif.ShowDialog() == DialogResult.OK)
                {
                    // Rafraîchir la liste après modification
                    FormListeVehicules_Load(sender, e);
                }*/
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un véhicule à modifier.",
                    "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btArchiver_Click(object sender, EventArgs e)
        {
            if (dgvVehicules.CurrentRow != null)
            {
                int idVehicule = (int)dgvVehicules.CurrentRow.Cells["Idvehicule"].Value;
                
                DialogResult confirmation = MessageBox.Show(
                    "Voulez-vous vraiment supprimer ce véhicule ?",
                    "Confirmation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (confirmation == DialogResult.Yes)
                {
                    bool succes = Modele.ModeleVehicule.ArchiverVehicule(idVehicule);

                    if (succes)
                    {
                        MessageBox.Show("Véhicule supprimé avec succès.",
                            "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Rafraîchir la liste après archivage
                        FormListeVehicules_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Échec de la suppression du véhicule.",
                            "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un véhicule à supprimer.",
                    "Aucune sélection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
