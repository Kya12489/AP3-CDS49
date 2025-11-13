using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AP3_AppliC.Entities;

namespace AP3_AppliC.view
{
    public partial class FormListeLecon : Form
    {
        private DateTime dateActuelle = DateTime.Today;
        private List<Conduire> lesLecons;
        private Dictionary<DateTime, List<Conduire>> leconsParJour;
        public FormListeLecon()
        {
            InitializeComponent();
            pnlCalendrier.Paint += PanelCalendrier_Paint;
            pnlCalendrier.MouseClick += PanelCalendrier_MouseClick;
        }
        private void FormCalendrierLecons_Load(object sender, EventArgs e)
        {
            ChargerLeconsDuMois();
            AfficherCalendrier();
        }

        private void ChargerLeconsDuMois()
        {
            DateTime debutMois = new DateTime(dateActuelle.Year, dateActuelle.Month, 1);
            DateTime finMois = debutMois.AddMonths(1).AddDays(-1);

            lesLecons = Modele.ModeleLecon.RecupererLeconsPeriode(debutMois, finMois);

            // Grouper par jour
            leconsParJour = lesLecons
                .GroupBy(l => l.Heuredebut.Date)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        private void AfficherCalendrier()
        {
            lblMoisAnnee.Text = dateActuelle.ToString("MMMM yyyy").ToUpper();
            pnlCalendrier.Invalidate(); // Redessiner
        }

        private void PanelCalendrier_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int largeurCase = pnlCalendrier.Width / 7;
            int hauteurCase = (pnlCalendrier.Height - 30) / 6;

            // En-têtes des jours
            string[] jours = { "Lun", "Mar", "Mer", "Jeu", "Ven", "Sam", "Dim" };
            Font fontHeader = new Font("Arial", 10, FontStyle.Bold);
            Brush brushHeader = Brushes.DarkGray;

            for (int i = 0; i < 7; i++)
            {
                g.DrawString(jours[i], fontHeader, brushHeader, i * largeurCase + 10, 5);
            }

            // Calculer le premier jour du mois
            DateTime premierJour = new DateTime(dateActuelle.Year, dateActuelle.Month, 1);
            int jourSemaine = (int)premierJour.DayOfWeek;
            if (jourSemaine == 0) jourSemaine = 7; // Dimanche = 7
            jourSemaine--; // Lundi = 0

            int joursTotal = DateTime.DaysInMonth(dateActuelle.Year, dateActuelle.Month);
            int ligne = 0;
            int colonne = jourSemaine;

            Font fontJour = new Font("Arial", 12);
            Font fontLecon = new Font("Arial", 8);

            for (int jour = 1; jour <= joursTotal; jour++)
            {
                DateTime date = new DateTime(dateActuelle.Year, dateActuelle.Month, jour);

                int x = colonne * largeurCase;
                int y = 30 + ligne * hauteurCase;

                // Couleur de fond
                Brush brushFond;
                if (date == DateTime.Today)
                {
                    brushFond = new SolidBrush(Color.LightBlue); // Aujourd'hui
                }
                else if (leconsParJour.ContainsKey(date))
                {
                    brushFond = new SolidBrush(Color.LightGreen); // Jour avec leçon(s)
                }
                else
                {
                    brushFond = Brushes.White; // Jour libre
                }

                g.FillRectangle(brushFond, x, y, largeurCase, hauteurCase);
                g.DrawRectangle(Pens.Gray, x, y, largeurCase, hauteurCase);

                // Numéro du jour
                g.DrawString(jour.ToString(), fontJour, Brushes.Black, x + 5, y + 5);

                // Nombre de leçons
                if (leconsParJour.ContainsKey(date))
                {
                    int nbLecons = leconsParJour[date].Count;
                    string texte = $"{nbLecons} leçon(s)";
                    g.DrawString(texte, fontLecon, Brushes.DarkGreen, x + 5, y + 25);
                }

                colonne++;
                if (colonne == 7)
                {
                    colonne = 0;
                    ligne++;
                }
            }
        }

        private void PanelCalendrier_MouseClick(object sender, MouseEventArgs e)
        {
            int largeurCase = pnlCalendrier.Width / 7;
            int hauteurCase = (pnlCalendrier.Height - 30) / 6;

            int colonne = e.X / largeurCase;
            int ligne = (e.Y - 30) / hauteurCase;

            if (ligne < 0) return;

            // Calculer la date cliquée
            DateTime premierJour = new DateTime(dateActuelle.Year, dateActuelle.Month, 1);
            int jourSemaine = (int)premierJour.DayOfWeek;
            if (jourSemaine == 0) jourSemaine = 7;
            jourSemaine--;

            int jourClique = ligne * 7 + colonne - jourSemaine + 1;

            if (jourClique >= 1 && jourClique <= DateTime.DaysInMonth(dateActuelle.Year, dateActuelle.Month))
            {
                DateTime dateCliquee = new DateTime(dateActuelle.Year, dateActuelle.Month, jourClique);

                // Ouvrir le formulaire de gestion pour ce jour
                //FormGestionLecon formGestion = new FormGestionLecon(dateCliquee);
                //formGestion.ShowDialog();

                // Recharger après modification
                ChargerLeconsDuMois();
                AfficherCalendrier();
            }
        }

        private void btPrecedent_Click(object sender, EventArgs e)
        {
            dateActuelle = dateActuelle.AddMonths(-1);
            ChargerLeconsDuMois();
            AfficherCalendrier();
        }

        private void btSuivant_Click(object sender, EventArgs e)
        {
            dateActuelle = dateActuelle.AddMonths(1);
            ChargerLeconsDuMois();
            AfficherCalendrier();
        }

        private void btAujourdhui_Click(object sender, EventArgs e)
        {
            dateActuelle = DateTime.Today;
            ChargerLeconsDuMois();
            AfficherCalendrier();
        }
        /*
        private void btNouvelleLecon_Click(object sender, EventArgs e)
        {
            FormGestionLecon formGestion = new FormGestionLecon(DateTime.Today);
            formGestion.ShowDialog();

            ChargerLeconsDuMois();
            AfficherCalendrier();
        }*/
    }
}
