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

namespace AP3_AppliC
{
    public partial class FormAjoutForfaits : Form
    {
        public FormAjoutForfaits()
        {
            InitializeComponent();
        }

        private void btnAjouterForfait_Click(object sender, EventArgs e)
        {
            if (tbLibelleForfait.Text.Trim() != "" && tbDescrForfait.Text.Trim() != "" && tbContenueForfait.Text.Trim() != "" && Convert.ToDouble(tbPrixForfait.Text.Trim()) != 0 && Convert.ToInt32(tbNbheures.Text.Trim()) != 0)
            {

                if (Modele.ModeleForfait.AjoutForfait(tbLibelleForfait.Text, tbDescrForfait.Text, tbContenueForfait.Text, Convert.ToDouble(tbPrixForfait.Text), Convert.ToInt32(tbNbheures.Text), Convert.ToDouble(tbPrixhoraireForfait.Text)))
                {
                    MessageBox.Show("Forfait ajouté");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur dans l'ajout d'un forfait", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("Enregistrement impossible : Il faut saisir tous les champs", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFermerAjoutForfait_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

}
