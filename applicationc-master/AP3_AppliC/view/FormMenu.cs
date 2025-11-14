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
    }
}
