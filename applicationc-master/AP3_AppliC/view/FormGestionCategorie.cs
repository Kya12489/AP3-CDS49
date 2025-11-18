using AP3_AppliC.Entities;
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
    public partial class FormGestionCategorie : Form
    {
        public FormGestionCategorie()
        {
            InitializeComponent();
        }

        private void FormGestionCategorie_Load(object sender, EventArgs e)
        {
            bsCategorie.DataSource = Modele.ModeleQuizz.listeTypes().Select(static x => new
            {
                x.IdCategorie,
                x.LibelleCategorie
            }).OrderBy(x => x.IdCategorie);


            dgvCategorie.DataSource = bsCategorie;
            dgvCategorie.Columns["IdCategorie"].Visible = false;

            dgvCategorie.Columns[1].HeaderText = "Catégorie";
        }

        private void btSupprimer_Click(object sender, EventArgs e)
        {
            if (dgvCategorie.CurrentRow == null) return;

            var cellValue = dgvCategorie.CurrentRow.Cells[1]?.Value
                            ?? dgvCategorie.CurrentRow.Cells[0]?.Value;

            if (cellValue == null) return;

            string libelle = cellValue.ToString().Trim();

            // retrouver l'objet Category en interrogeant le modèle
            Category categorie = Modele.ModeleQuizz.listeTypes()
                            .FirstOrDefault(c => c.LibelleCategorie.Trim().Equals(libelle, StringComparison.OrdinalIgnoreCase));

            if (categorie == null)
            {
                MessageBox.Show("Catégorie introuvable en base.");
                return;
            }

            var rep = MessageBox.Show(
                $"Voulez-vous vraiment supprimer la catégorie '{categorie.LibelleCategorie}' ?\nToutes les questions liées perdront leur catégorie.",
                "Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (rep == DialogResult.Yes)
            {
                if (Modele.ModeleQuizz.SupprimerCategorie(categorie.IdCategorie))
                {
                    MessageBox.Show("Catégorie supprimée avec succès.");
                    bsCategorie.DataSource = Modele.ModeleQuizz.listeTypes().Select(static x => new
                    {
                        x.IdCategorie,
                        x.LibelleCategorie
                    }).OrderBy(x => x.IdCategorie);


                    dgvCategorie.DataSource = bsCategorie;
                    dgvCategorie.Refresh();
                }
            }
        }

        private void btModifier_Click(object sender, EventArgs e)
        {

        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            // Petite fenêtre de saisie
            string libelle = Microsoft.VisualBasic.Interaction.InputBox(
                "Entrez le libellé de la nouvelle catégorie :",
                "Ajouter une catégorie",
                ""
            ).Trim();

            // Si l'utilisateur annule ou laisse vide → on ne fait rien
            if (string.IsNullOrWhiteSpace(libelle))
                return;

            // Appel du modèle (qui vérifie déjà les doublons)
            Category nouvelle = Modele.ModeleQuizz.AjoutCategorie(libelle);

            if (nouvelle != null)
            {
                MessageBox.Show("Catégorie ajoutée avec succès.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Rafraîchissement du DataGridView
                //bsCategorie.DataSource = Modele.ModeleQuizz.listeTypes();
                //dgvCategorie.Refresh();
                //FormMenu.Instance.openChildForm(new FormListeQuizz());
                bsCategorie.DataSource = Modele.ModeleQuizz.listeTypes().Select(static x => new
                {
                    x.IdCategorie,
                    x.LibelleCategorie
                }).OrderBy(x => x.IdCategorie);


                dgvCategorie.DataSource = bsCategorie;
                dgvCategorie.Refresh();
            }
            else
            {
                // Ajout refusé ou doublon → message déjà géré dans AjoutCategorie
            }
        }

        private void btRetour_Click(object sender, EventArgs e)
        {
            FormMenu.Instance.openChildForm(new FormListeQuizz());
        }
    }
}
