using AP3_AppliC.view;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace AP3_AppliC
{
    public partial class FormMenu : Form
    {
        public static FormMenu Instance { get; private set; }
        private Form activeForm = null;
        public FormMenu()
        {
            InitializeComponent();
            Instance = this;
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {
            #region Chart Élèves inscrits par mois
            /*
            List<(DateOnly, int)> dataEleveInscription = Modele.ModeleEleve.nbEleveInscritParMois();

            chartInscritEleve.Series.Clear();
            chartInscritEleve.ChartAreas.Clear();

            // Configuration de la zone du graphique
            ChartArea area = new ChartArea("Main");

            // Désactivation de la grille de fond
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;

            // Bordure et fond transparent
            area.BorderWidth = 0;
            area.BorderColor = System.Drawing.Color.Transparent;
            area.BackColor = System.Drawing.Color.Transparent;

            // Configuration de l'axe Y (nombres entiers uniquement)
            area.AxisY.Interval = 1;
            area.AxisY.Minimum = 0;

            chartInscritEleve.ChartAreas.Add(area);

            // Configuration de la série
            Series serie = new Series("Élèves inscrits");
            serie.ChartType = SeriesChartType.Column;
            serie.XValueType = ChartValueType.String; // ⚠️ Changé en String pour les labels
            serie.YValueType = ChartValueType.Int32;
            serie.IsValueShownAsLabel = true;
            serie.ChartArea = "Main";

            // Optionnel : Personnalisation visuelle
            serie.Color = System.Drawing.Color.FromArgb(79, 129, 189); // Couleur bleue
            serie.BorderWidth = 0;

            // Ajout des données
            foreach (var (mois, nb) in dataEleveInscription)
            {
                string moisLabel = mois.ToString("MMM yyyy", new System.Globalization.CultureInfo("fr-FR"));
                serie.Points.AddXY(moisLabel, nb); // ⚠️ Utiliser le label directement
            }

            chartInscritEleve.Series.Add(serie);

            // Ajustement de l'angle des labels si nécessaire
            area.AxisX.LabelStyle.Angle = -45; // Labels en diagonale pour plus de lisibilité
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8);*/

            #endregion

            #region Chart Élèves inscrits par mois
            List<(DateOnly, int)> dataEleveInscription = Modele.ModeleEleve.nbEleveParMois();

            chartInscritEleve.Series.Clear();
            chartInscritEleve.ChartAreas.Clear();

            // Configuration de la zone du graphique
            ChartArea area = new ChartArea("Main");

            // Désactivation de la grille de fond
            area.AxisX.MajorGrid.Enabled = false;
            area.AxisY.MajorGrid.Enabled = false;
            area.AxisX.MinorGrid.Enabled = false;
            area.AxisY.MinorGrid.Enabled = false;

            // Bordure et fond
            area.BorderWidth = 0;
            area.BorderColor = System.Drawing.Color.Transparent;
            area.BackColor = System.Drawing.Color.Transparent;

            // Configuration de l'axe Y
            area.AxisY.Interval = 1;
            area.AxisY.Minimum = 0;

            // Configuration de l'axe X
            area.AxisX.Interval = 1; // Une colonne par mois
            area.AxisX.LabelStyle.Angle = -45; // Labels en diagonale
            area.AxisX.LabelStyle.Font = new System.Drawing.Font("Arial", 8);

            chartInscritEleve.ChartAreas.Add(area);

            // Configuration de la série
            Series serie = new Series("Élèves inscrits");
            serie.ChartType = SeriesChartType.Column;
            serie.IsValueShownAsLabel = true;
            serie.ChartArea = "Main";
            serie.Color = System.Drawing.Color.FromArgb(79, 129, 189);

            // IMPORTANT : Ajout des points avec index numérique et label personnalisé
            int index = 0;
            foreach (var (mois, nb) in dataEleveInscription)
            {
                string moisLabel = mois.ToString("MMM yyyy", new System.Globalization.CultureInfo("fr-FR"));

                // Créer le point
                DataPoint point = new DataPoint();
                point.SetValueXY(index, nb); // Index numérique pour l'espacement
                point.AxisLabel = moisLabel;  // Label personnalisé affiché

                serie.Points.Add(point);
                index++;
            }

            chartInscritEleve.Series.Add(serie);
            #endregion

            #region Chart Proportion des forfaits
            List<(int, string)> dataProportionForfait = Modele.ModeleEleve.proportionForfait();
            chartProportionForfait.Series.Clear();
            chartProportionForfait.ChartAreas.Clear();
            chartProportionForfait.ChartAreas.Add(new ChartArea("Main"));
            Series serieForfait = new Series("Forfaits");
            serieForfait.ChartType = SeriesChartType.Pie;
            serieForfait.XValueType = ChartValueType.String;
            serieForfait.YValueType = ChartValueType.Int32;
            serieForfait.IsValueShownAsLabel = true;
            serieForfait.ChartArea = "Main";
            foreach (var (nb, nomForfait) in dataProportionForfait)
            {
                serieForfait.Points.AddXY(nomForfait, nb);
            }
            chartProportionForfait.Series.Add(serieForfait);
            #endregion
        }
        // public Form activeForm = null;
        public void openChildForm(Form formEnfant)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = formEnfant;
            formEnfant.TopLevel = false;
            formEnfant.FormBorderStyle = FormBorderStyle.None;
            formEnfant.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(formEnfant);
            panelPrincipal.Tag = formEnfant;
            formEnfant.BringToFront();
            formEnfant.Show();
        }


        private void listeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FormListeEleves());
        }

        private void listeToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            openChildForm(new FormForfaits());
        }

        private void listeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm(new FormMoniteurs(AP3_AppliC.EtatGestion.Read));
        }


        private void ajoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FormMoniteurs(AP3_AppliC.EtatGestion.Create));
        }

        private void modificationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FormMoniteurs(AP3_AppliC.EtatGestion.Update));
        }

        private void inscriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new FormInscriptionEleve(AP3_AppliC.view.EtatGestionE.Add));
        }

        private void ajouterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm((new FormAjoutForfaits()));
        }

        private void quitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Hide();
            new FormConnexion().Show();
        }

        private void listeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openChildForm((new FormListeVehicules()));
        }

        private void ajouterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            openChildForm((new FormGestionVehicules(AP3_AppliC.view.EtatGestionV.Add)));
        }

        private void listeToolStripMenuItem4_Click(object sender, EventArgs e)
        {
            openChildForm((new FormListeLecon()));
        }

        private void ajouterToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            openChildForm((new FormGestionLecon()));
        }

        private void quitterToolStripMenuItem1quitterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listeToolStripMenuItem5_Click(object sender, EventArgs e)
        {
            openChildForm(new FormListeQuizz());
        }

        private void ajouterToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            openChildForm(new FormGestionQuizz());
        }
    }
}
