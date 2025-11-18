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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AP3_AppliC.view
{
    public partial class FormChangementMdp : Form
    {
        private int idE;

        public FormChangementMdp(int idE)
        {
            InitializeComponent();
            this.idE = idE;

        }

        private void FormChangementMdp_Load(object sender, EventArgs e)
        {
            Eleve unE = Modele.ModeleEleve.RecupererEleve(idE);
            labelNomEleve.Text = unE.Nomeleve + " " + unE.Prenomeleve;
        }

        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAttribuer_Click(object sender, EventArgs e)
        {
            string mdp = tbMdp.Text;
            if (string.IsNullOrEmpty(mdp))
            {
                MessageBox.Show("Le mot de passe est obligatoire.",
                            "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (!Controleur.MdpValide(mdp, out string messageErreur))
            {
                MessageBox.Show(messageErreur,
                            "Mot de passe invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbMdp.Focus();
                return;
            }

            Eleve mdpModifie = Modele.ModeleEleve.ModifierMdp(idE, mdp);
            if (mdpModifie != null)
            {
                MessageBox.Show("Mot de passe modifié avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                int idE = mdpModifie.Ideleve;
                
            }
            else
            {
                MessageBox.Show("Erreur lors de la modification");
            }
        }
    }
    
}
