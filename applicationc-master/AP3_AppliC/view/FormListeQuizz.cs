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
    public partial class FormListeQuizz : Form
    {
        public FormListeQuizz()
        {
            InitializeComponent();
        }

        private void FormListeQuizz_Load(object sender, EventArgs e)
        {
            bsQuestion.DataSource = Modele.ModeleQuizz.listeTousQuestions().Select(static x => new
            {
                x.Idquestion,
                x.Libellequestion,
                x.IdCategorieNavigation.LibelleCategorie
            }).OrderBy(x => x.Idquestion);


            dgvQuestion.DataSource = bsQuestion;
            dgvQuestion.Columns["Idquestion"].Visible = false;

            dgvQuestion.Columns[1].HeaderText = "Question";
            dgvQuestion.Columns[2].HeaderText = "Catégorie";

            dgvQuestion.Columns[2].Width = 10;
            dgvQuestion.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None; ;

            dgvReponse.Visible = false;


            List<Category> types = Modele.ModeleQuizz.listeTypes();

            cbRechercheCategorie.Items.Clear();
            cbRechercheCategorie.Items.Add("Toutes les catégories");

            foreach (var type in types)
            {
                cbRechercheCategorie.Items.Add(type.LibelleCategorie);
            }

            cbRechercheCategorie.SelectedIndex = 0;
        }

        private void voirSesReponseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvQuestion.CurrentRow != null)
            {
                int idQ = (int)dgvQuestion.CurrentRow.Cells["Idquestion"].Value;

                List<Reponse> lesReponses = Modele.ModeleQuizz.listeReponsesParQuestion(idQ);

                if (lesReponses.Count > 0)
                {
                    bsReponse.DataSource = lesReponses.Select(static x => new
                    {
                        x.Idquestion,
                        x.Numreponse,
                        x.Libellereponse,
                        Valide = x.Valide == true ? "Oui" : "Non",

                    }).OrderBy(x => x.Idquestion);

                    dgvReponse.DataSource = bsReponse;
                    dgvReponse.Columns["Idquestion"].Visible = false;
                    dgvReponse.Columns["Numreponse"].Visible = false;
                    dgvReponse.Columns[2].HeaderText = "Réponse";
                    dgvReponse.Columns[3].HeaderText = "Est correcte";

                    dgvReponse.Visible = true;
                }
                else
                {
                    MessageBox.Show("Cette question n'a pas de réponses associées.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvReponse.Visible = false;
                }
            }
        }

        private void cbRechercheCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbRechercheCategorie.SelectedItem == null)
                return;

            string categorieSelectionnee = cbRechercheCategorie.SelectedItem.ToString();

            // Rechercher les questions par catégorie
            var questionsRecherchees = Modele.ModeleQuizz.RechercherQuestionsParCategorie(categorieSelectionnee);

            // Afficher les résultats
            bsQuestion.DataSource = questionsRecherchees.Select(q => new
            {
                q.Idquestion,
                q.Libellequestion,
                Categorie = q.IdCategorieNavigation.LibelleCategorie
            }).OrderBy(q => q.Idquestion).ToList();

            dgvQuestion.DataSource = bsQuestion;

            // Masquer les réponses lors du changement de filtre
            dgvReponse.Visible = false;
        }

        private void dgvQuestion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvReponse.Visible = false;
        }

        private void dgvQuestion_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvReponse.Visible = false;
        }

        private void dgvQuestion_Click(object sender, EventArgs e)
        {
            dgvReponse.Visible = false;
        }

        private void btGestionCat_Click(object sender, EventArgs e)
        {

        }
    }
}
