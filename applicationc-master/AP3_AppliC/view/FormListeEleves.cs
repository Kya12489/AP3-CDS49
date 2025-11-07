using AP3_AppliC.Entities;
using AP3_AppliC.Modele;
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
    public partial class FormListeEleves : Form
    {
        public FormListeEleves()
        {
            InitializeComponent();

            tbNomEleve.TextChanged += RechercheTempsReel;
            tbPrenomEleve.TextChanged += RechercheTempsReel;

        }

        private void FormListeEleves_Load(object sender, EventArgs e)
        {
            bsEleves.DataSource = Modele.ModeleEleve.listeEleves().Select(static x => new
            {
                x.Ideleve,
                x.Nomeleve,
                x.Prenomeleve,
                x.Emaileleve,
                x.Datenaissanceeleve
            }).OrderBy(x => x.Ideleve);


            dgvEleves.DataSource = bsEleves;
            dgvEleves.Columns[0].HeaderText = "Identifiant";
            dgvEleves.Columns[1].HeaderText = "Nom";
            dgvEleves.Columns[2].HeaderText = "Prénom";
            dgvEleves.Columns[3].HeaderText = "Email";
            dgvEleves.Columns[4].HeaderText = "Date de Naissance";
            dgvForfaits.Visible = false;
        }

        private void voirSesForfaitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Type type = bsEleves.Current.GetType();
            int idE = (int)type.GetProperty("Ideleve").GetValue(bsEleves.Current, null);

            List<Inscrire> lesForfaits = Modele.ModeleEleve.listeForfaitsParEleve(idE);
            if (lesForfaits.Count != 0)
            {
                bsForfaitsparEleve.DataSource = (lesForfaits).Select(static x => new
                {
                    x.Idforfait,
                    x.IdforfaitNavigation.Libelleforfait,
                    x.Dateinscription,
                    x.IdforfaitNavigation.Prixforfait,
                    x.IdforfaitNavigation.Nbheures
                });

                dgvForfaits.DataSource = bsForfaitsparEleve;
                dgvForfaits.Columns[0].HeaderText = "Identifiant";
                dgvForfaits.Columns[1].HeaderText = "Libellé";
                dgvForfaits.Columns[2].HeaderText = "Date Inscription";
                dgvForfaits.Columns[3].HeaderText = "Prix";
                dgvForfaits.Columns[4].HeaderText = "Nb Heures";
                dgvForfaits.Visible = true;

            }
            else
            {
                dgvForfaits.Visible = false;
                MessageBox.Show("Pas d'inscription pour cet élève");
            }
        }

        private void dgvEleves_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvForfaits.Visible = false;
        }

        private void dgvEleves_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            dgvForfaits.Visible = false;
        }

        private void dgvEleves_Click(object sender, EventArgs e)
        {
            dgvForfaits.Visible = false;
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void attribuerUnForfaitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Type type = bsEleves.Current.GetType();
            int idE = (int)type.GetProperty("Ideleve").GetValue(bsEleves.Current, null);
            FormAttribuerForfait F = new FormAttribuerForfait(idE);
            F.Show();
        }

        private void RechercheTempsReel(object sender, EventArgs e)
        {
            try
            {
                string nomSaisi = tbNomEleve.Text;
                string prenomSaisi = tbPrenomEleve.Text;


                bsEleves.DataSource = Modele.ModeleEleve.RechercherEleves(nomSaisi, prenomSaisi).Select(static x => new
                {
                    x.Ideleve,
                    x.Nomeleve,
                    x.Prenomeleve,
                    x.Emaileleve,
                    x.Datenaissanceeleve
                }).OrderBy(x => x.Ideleve);

                dgvEleves.DataSource = bsEleves;
            }
            catch
            {

            }
        }

    }
}
