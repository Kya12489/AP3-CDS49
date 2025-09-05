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
using System.Windows.Input;

namespace AP3_AppliC
{
    public partial class FormForfaits : Form
    {
        public FormForfaits()
        {
            InitializeComponent();
        }
        public void RemplirListeForfaits()
        {

            cbForfaits.ValueMember = "Idforfait";//permet de stocker l'identifiant
            cbForfaits.DisplayMember = "Libelleforfait";
            bsForfaits.DataSource = Modele.ModeleForfait.listeForfaits();
            cbForfaits.DataSource = bsForfaits;
            cbForfaits.SelectedIndex = -1;
        }
        private void FormForfaits_Load(object sender, EventArgs e)
        {
            RemplirListeForfaits();
            lbDetails.Visible = false;
            btnSupprimer.Visible = false;
        }

        private void cbForfaits_SelectedIndexChanged(object sender, EventArgs e)
        {
            bsForfaits_CurrentChanged(sender, e);
        }

        private void bsForfaits_CurrentChanged(object sender, EventArgs e)
        {
            // si un forfait est sélectionné dans la liste
            if (cbForfaits.SelectedIndex != -1)
            {
                lbDetails.Items.Clear();
                // récupération du forfait sélectionné
                Forfait F = (Forfait)bsForfaits.Current;

                // mise à jour des infos du forfait dans la listBox
                lbDetails.Items.Add("Identifiant : " + F.Idforfait);
                lbDetails.Items.Add("Libellé : " + F.Libelleforfait);
                lbDetails.Items.Add("Description : " + F.Descriptionforfait);
                lbDetails.Items.Add("Contenu : " + F.Contenuforfait);
                lbDetails.Items.Add("Prix du forfait : " + F.Prixforfait);

                lbDetails.Visible = true;
                btnSupprimer.Visible = true;
            }
            else
                lbDetails.Visible = false;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            // si un forfait est sélectionné dans la liste
            if (cbForfaits.SelectedIndex != -1)
            {
                Forfait F = (Forfait)bsForfaits.Current;
                if (MessageBox.Show("Etes vous sur de vouloir supprimer ce forfait :" + F.Idforfait, "Suppression", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    if (Modele.ModeleForfait.SupprimerForfait(F.Idforfait))
                    {
                        FormForfaits_Load(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("Erreur dans la suppression du forfait : \nimpossible de le supprimer, des élèves sont inscrits", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
