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
    public enum EtatGestion
    {
        Read,
        Create,
        Update
    }
    public partial class FormMoniteurs : Form
    {
        private EtatGestion etat;
        public FormMoniteurs(EtatGestion etat)
        {
            InitializeComponent();
            this.etat = etat;
        }

        public void RemplirListeMoniteurs()
        {

            cbListeMoniteurs.ValueMember = "Idmoniteur";//permet de stocker l'identifiant
            cbListeMoniteurs.DisplayMember = "nomComplet";
            bsMoniteurs.DataSource = (Modele.ModeleMoniteur.listeMoniteurs()).Select(x => new { x.Idmoniteur, nomComplet = x.Nommoniteur + " " + x.Prenommoniteur }).OrderBy(x => x.nomComplet); ;
            cbListeMoniteurs.DataSource = bsMoniteurs;
            cbListeMoniteurs.SelectedIndex = -1;
        }
        private void FormMoniteurs_Load(object sender, EventArgs e)
        {

            if (etat == EtatGestion.Read) // cas etat en lecture
            {
                label1.Text = "Gestion des Moniteurs : Liste en consultation";
                RemplirListeMoniteurs();
                cbListeMoniteurs.Visible = true;
                gbInfos.Visible = false;
                btnAction.Visible = false;
            }
            if (etat == EtatGestion.Create) // cas etat create
            {
                label1.Text = "Gestion des Moniteurs : Ajout";
                btnAction.Text = "AJOUTER";
                tbNom.Clear();
                tbPrenom.Clear();
                tbEmail.Clear();
                gbInfos.Visible = true;
                cbListeMoniteurs.Visible = false;
                btnAction.Visible = true;

            }
            if (etat == EtatGestion.Update) // cas etat update
            {
                label1.Text = "Gestion des Moniteurs : Modification";
                btnAction.Text = "MODIFIER";
                gbInfos.Visible = false;
                cbListeMoniteurs.Visible = true;
                btnAction.Visible = false;
                RemplirListeMoniteurs();
            }

        }

        private void bsMoniteurs_CurrentChanged(object sender, EventArgs e)
        {
            // si un moniteur est sélectionné dans la liste
            if (cbListeMoniteurs.SelectedIndex != -1)
            {
                // récupération du moniteur sélectionné
                int idmoniteur = Convert.ToInt32(cbListeMoniteurs.SelectedValue);

                Moniteur M = Modele.ModeleMoniteur.RecupererMoniteur(idmoniteur);

                // mise à jour des infos du moniteur dans les différents champs
                tbNom.Text = M.Nommoniteur;
                tbPrenom.Text = M.Prenommoniteur;
                tbEmail.Text = M.Emailmoniteur;

                gbInfos.Visible = true;

                if (etat == EtatGestion.Read)
                {
                    tbNom.ReadOnly = true;
                    tbPrenom.ReadOnly = true;
                    tbEmail.ReadOnly = true;
                }
                if (etat == EtatGestion.Update)
                {
                    btnAction.Visible = true;
                }
            }
            else
                gbInfos.Visible = false;
        }

        private void cbListeMoniteurs_SelectedIndexChanged(object sender, EventArgs e)
        {
            bsMoniteurs_CurrentChanged(sender, e);
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
         
            if (tbNom.Text != "" && tbPrenom.Text != "" && tbEmail.Text != "")
                {
                if (!Controleur.ValidMail(tbEmail.Text))
                {
                    MessageBox.Show("Erreur dans le format de l'adresse mail", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // etat en ajout
                    if (etat == EtatGestion.Create)
                    {
                        if (Modele.ModeleMoniteur.AjoutMoniteur(tbNom.Text, tbPrenom.Text, tbEmail.Text))
                        {
                            MessageBox.Show("Moniteur ajouté, un email lui a été envoyé pour valider son inscription.");
                            Controleur.CreationEmail(tbEmail.Text, tbNom.Text, tbPrenom.Text);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Erreur dans l'ajout d'un moniteur", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }

                    if (etat == EtatGestion.Update) // cas de la mise à jour
                    {
                        int idmoniteur = Convert.ToInt32(cbListeMoniteurs.SelectedValue);
                                            
                        if (Modele.ModeleMoniteur.ModificationMoniteur(idmoniteur, tbNom.Text, tbPrenom.Text, tbEmail.Text))
                        {
                            MessageBox.Show("Moniteur modifié");
                            gbInfos.Visible = false;
                            btnAction.Visible = false;
                            cbListeMoniteurs.SelectedIndex = -1;
                            // Annuler();
                        }
                        else
                        {
                            MessageBox.Show("Erreur dans la mise à jour d'un moniteur", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                    MessageBox.Show("Enregistrement impossible : Il faut saisir tous les champs", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }  
        
    }
}
