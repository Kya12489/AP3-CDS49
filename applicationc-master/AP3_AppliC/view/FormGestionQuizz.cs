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
    public partial class FormGestionQuizz : Form
    {
        public FormGestionQuizz()
        {
            InitializeComponent();
        }

        private void FormGestionQuizz_Load(object sender, EventArgs e)
        {
            List<Category> types = Modele.ModeleQuizz.listeTypes();

            if (types.Count == 0)
            {
                MessageBox.Show("Aucune catégorie disponible. Veuillez d'abord créer des catégories.",
                    "Aucune catégorie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            cbCategory.DisplayMember = "LibelleCategorie";
            cbCategory.ValueMember = "IdCategorie";
            cbCategory.DataSource = types;
            cbCategory.SelectedIndex = -1;

            checkBoxRep3.Enabled = false;
            checkBoxRep4.Enabled = false;
        }

        private void btAction_Click(object sender, EventArgs e)
        {
            string libelleQuestion = tbQuestion.Text.Trim();

            if (string.IsNullOrEmpty(libelleQuestion))
            {
                MessageBox.Show("Le libellé de la question est obligatoire.",
                            "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbQuestion.Focus();
                return;
            }

            if (cbCategory.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une catégorie.",
                            "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cbCategory.Focus();
                return;
            }

            Category categorieSelectionnee = (Category)cbCategory.SelectedItem;
            int idCategorie = categorieSelectionnee.IdCategorie;

            string reponse1 = tbReponse1.Text.Trim();
            string reponse2 = tbReponse2.Text.Trim();
            string reponse3 = tbReponse3.Text.Trim();
            string reponse4 = tbReponse4.Text.Trim();

            if (string.IsNullOrEmpty(reponse1) || string.IsNullOrEmpty(reponse2))
            {
                MessageBox.Show("Au moins deux réponses sont requises.",
                            "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            List<(string libelle, bool estCorrecte)> reponses = new List<(string, bool)>();
            
            reponses.Add((reponse1, checkBoxRep1.Checked)); 
            reponses.Add((reponse2, checkBoxRep2.Checked));
            if (!string.IsNullOrEmpty(reponse3))
            {
                reponses.Add((reponse3, checkBoxRep3.Checked));
            }
            if (!string.IsNullOrEmpty(reponse4))
            {
                reponses.Add((reponse4, checkBoxRep4.Checked));
            }

            if (!reponses.Any(r => r.estCorrecte))
            {
                MessageBox.Show("Au moins une réponse doit être cochée comme correcte.",
                    "Réponse correcte requise", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (reponses.All(r => r.estCorrecte))
            {
                MessageBox.Show("Il doit y avoir au moins une réponse incorrecte.\nToutes les réponses ne peuvent pas être correctes.",
                    "Réponses incorrectes requises", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Question nouvelleQuestion = Modele.ModeleQuizz.AjoutQuestionAvecReponse(libelleQuestion, idCategorie, reponses);
            if(nouvelleQuestion != null)
            {
                MessageBox.Show("La question et ses réponses ont été ajoutées avec succès.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                                MessageBox.Show("Une erreur est survenue lors de l'ajout de la question.",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void tbReponse3_TextChanged(object sender, EventArgs e)
        {
            // Activer la CheckBox seulement si la TextBox contient du texte
            if (string.IsNullOrWhiteSpace(tbReponse3.Text))
            {
                checkBoxRep3.Checked = false;
                checkBoxRep3.Enabled = false;
            }
            else
            {
                checkBoxRep3.Enabled = true;
            }
        }

        private void tbReponse4_TextChanged(object sender, EventArgs e)
        {
            // Activer la CheckBox seulement si la TextBox contient du texte
            if (string.IsNullOrWhiteSpace(tbReponse4.Text))
            {
                checkBoxRep4.Checked = false;
                checkBoxRep4.Enabled = false;
            }
            else
            {
                checkBoxRep4.Enabled = true;
            }
        }
    }
}
