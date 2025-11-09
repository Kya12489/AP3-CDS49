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
    public partial class FormInscriptionEleve : Form
    {
        public FormInscriptionEleve()
        {
            InitializeComponent();
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            string nom = tbNom.Text;
            string prenom = tbPrenom.Text;
            string mail = tbEmail.Text;
            string mdp = tbMdp.Text;
            DateOnly date = DateOnly.FromDateTime(dtpNaissance.Value);
            string tel = tbNumTel.Text;

            bool ajout = Modele.ModeleEleve.AjoutEleve(nom, prenom, mail, mdp, date, tel);

            if (ajout)
            {
                MessageBox.Show("Eleve ajoutée");
            }
            else
            {
                MessageBox.Show("Erreur lors de l'inscription");
            }
        }
    }
}
