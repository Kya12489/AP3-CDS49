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
        public FormMenu()
        {
            InitializeComponent();
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }
        public Form activeForm = null;
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

        private void qUITTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
            throw new ArgumentException("Cette fonctionnalité n'est pas encore opérationnelle");
        }

        private void gestionDesForfaitsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
