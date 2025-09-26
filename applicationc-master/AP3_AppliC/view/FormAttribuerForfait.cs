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
    public partial class FormAttribuerForfait : Form
    {
        private int idE;
        public FormAttribuerForfait(int idE)
        {
            InitializeComponent();
            // récupération de l'identifiant de l'élève pour lequel on souhaite attribuer le forfait
            this.idE = idE;
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void RemplirListeForfaits()
        {

            cbForfaits.ValueMember = "Idforfait";//permet de stocker l'identifiant
            cbForfaits.DisplayMember = "Libelleforfait";
            bsForfaits.DataSource = Modele.ModeleForfait.listeForfaits();
            cbForfaits.DataSource = bsForfaits;
            cbForfaits.SelectedIndex = -1;
        }
        private void FormAttribuerForfait_Load(object sender, EventArgs e)
        {
            RemplirListeForfaits();
            Eleve unE = Modele.ModeleEleve.RecupererEleve(idE);
            labelNomEleve.Text = unE.Nomeleve + " " + unE.Prenomeleve;

        }

        private void btnAttribuer_Click(object sender, EventArgs e)
        {
            if (cbForfaits.SelectedIndex != -1)
            {
                int idForfait = Convert.ToInt32(cbForfaits.SelectedValue);
                if (Modele.ModeleEleve.AjoutInscrire(idE, idForfait))
                {
                    MessageBox.Show("Le forfait a été ajouté à l'èlève");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erreur dans l'attribution d'un forfait", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else
            {
                MessageBox.Show("Enregistrement impossible : Il faut sélectionner un forfait", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
};
