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

namespace AP3_AppliC.view
{
    public enum EtatGestionE
    {
        Add,
        Update
    }
    public partial class FormInscriptionEleve : Form
    {
        private EtatGestionE etat;
        private int _idEleve = 0;

        // Constructeur pour AJOUT
        public FormInscriptionEleve(EtatGestionE etat)
        {
            InitializeComponent();
            this.etat = etat;

        }
        // Constructeur pour MODIFICATION (avec ID)
        public FormInscriptionEleve(EtatGestionE etat, int idEleve)
        {
            InitializeComponent();
            this.etat = etat;
            this._idEleve = idEleve;
        }



        public void RemplirListeForfaits()
        {

            cbForfait.ValueMember = "Idforfait";//permet de stocker l'identifiant
            cbForfait.DisplayMember = "Libelleforfait";
            bsForfait.DataSource = Modele.ModeleForfait.listeForfaits();
            cbForfait.DataSource = bsForfait;
            cbForfait.SelectedIndex = -1;
        }

        private void btAjouter_Click(object sender, EventArgs e)
        {
            string nom = tbNom.Text.Trim();
            if (string.IsNullOrEmpty(nom))
            {

                MessageBox.Show("Le nom est obligatoire.",
                            "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNom.Focus();
                return;
            }

            string prenom = tbPrenom.Text.Trim();
            if (string.IsNullOrEmpty(prenom))
            {
                MessageBox.Show("Le prénom est obligatoire.",
                            "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbPrenom.Focus();
                return;
            }

            #region email
            string mail = tbEmail.Text.Trim();
            if (string.IsNullOrEmpty(mail))
            {
                MessageBox.Show("L'email est obligatoire.",
                            "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }

            if (!Controleur.ValidMail(mail))
            {
                MessageBox.Show("L'adresse email n'est pas valide.\nFormat attendu : exemple@domaine.com",
                            "Email invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }

            if (etat == EtatGestionE.Add && Modele.ModeleEleve.EmailExiste(mail))
            {
                MessageBox.Show($"L'adresse email '{mail}' est déjà utilisée.",
                    "Email existant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }
            #endregion

            

            DateOnly date = DateOnly.FromDateTime(dtpNaissance.Value);
            if (date > DateOnly.FromDateTime(DateTime.Today))
            {
                MessageBox.Show("La date de naissance ne peut pas être dans le futur.",
                            "Date invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNaissance.Focus();
                return;
            }
            int age = DateOnly.FromDateTime(DateTime.Today).Year - date.Year;
            if (date > DateOnly.FromDateTime(DateTime.Today).AddYears(-age)) age--;

            if (age < 16)
            {
                MessageBox.Show("L'élève doit avoir au moins 16 ans pour s'inscrire.",
                    "Âge minimum requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                dtpNaissance.Focus();
                return;
            }

            string tel = tbNumTel.Text.Trim();
            if (string.IsNullOrEmpty(tel))
            {
                MessageBox.Show("Le numéro de téléphone est obligatoire.",
                            "Champ requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNumTel.Focus();
                return;
            }
            if (!Controleur.NumTelValide(tel))
            {
                MessageBox.Show("Le numéro de téléphone n'est pas valide.\nFormat attendu : 0X XX XX XX XX ou 0XXXXXXXXX",
                            "Numéro de téléphone invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbNumTel.Focus();
                return;
            }
            string telEnvoyer = Controleur.NettoyerNumeroTelephone(tel);

            if (etat == EtatGestionE.Add && !Modele.ModeleEleve.EmailExiste(mail))
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

                Eleve nouvelEleve = Modele.ModeleEleve.AjoutEleve(nom, prenom, mail, mdp, date, telEnvoyer);

                if (nouvelEleve != null)
                {
                    MessageBox.Show("Élève inscrit avec succès !",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (cbForfait.SelectedIndex != -1)
                    {
                        int idForfait = Convert.ToInt32(cbForfait.SelectedValue);
                        int idE = nouvelEleve.Ideleve;
                        if (Modele.ModeleEleve.AjoutInscrire(idE, idForfait))
                        {
                            MessageBox.Show("Le forfait a été ajouté à l'èlève");
                        }
                        else
                        {
                            MessageBox.Show("Erreur dans l'attribution d'un forfait", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    FormMenu.Instance.openChildForm(new FormListeEleves());
                }
                else
                {
                    MessageBox.Show("Erreur lors de l'inscription");
                }
            }
            if (etat == EtatGestionE.Update && !Modele.ModeleEleve.EmailExisteModif(mail, _idEleve))
            {
                Eleve eleveModifie = Modele.ModeleEleve.ModifierEleve(_idEleve, nom, prenom, mail, /*mdp,*/ date, telEnvoyer);
                if (eleveModifie != null)
                {
                    MessageBox.Show("Élève modifié avec succès !",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (cbForfait.SelectedIndex != -1)
                    {
                        int idForfait = Convert.ToInt32(cbForfait.SelectedValue);
                        int idE = eleveModifie.Ideleve;
                        if (Modele.ModeleEleve.AjoutInscrire(idE, idForfait))
                        {
                            MessageBox.Show("Le forfait a été ajouté à l'èlève");
                        }
                        else
                        {
                            MessageBox.Show("Erreur dans l'attribution d'un forfait", "ERREUR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    FormMenu.Instance.openChildForm(new FormListeEleves());
                }
                else
                {
                    MessageBox.Show("Erreur lors de la modification");
                }
            }


        }

        private void FormInscriptionEleve_Load(object sender, EventArgs e)
        {
            RemplirListeForfaits();
            if (etat == EtatGestionE.Add) // cas etat en ajout
            {
                btAction.Text = "AJOUTER";
            }

            if (etat == EtatGestionE.Update) // cas etat en modification 
            {
                btAction.Text = "MODIFIER";
                lblForfait.Visible = false;
                cbForfait.Visible = false;
                tbMdp.Visible = false;
                lblMdp.Visible = false;
                ChargerDonneesEleves();
            }
        }

        private void ChargerDonneesEleves()
        {
            // Récupérer les données de l'élève depuis la BDD
            Eleve eleve = Modele.ModeleEleve.ObtenirEleve(_idEleve);

            if (eleve != null)
            {
                tbNom.Text = eleve.Nomeleve;
                tbPrenom.Text = eleve.Prenomeleve;
                tbEmail.Text = eleve.Emaileleve;
                dtpNaissance.Value = eleve.Datenaissanceeleve.ToDateTime(new TimeOnly(0, 0));
                tbNumTel.Text = eleve.Numeroteleleve;
            }
            else
            {
                MessageBox.Show("Elève introuvable.", "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            FormMenu.Instance.openChildForm(new FormListeEleves());
        }
    }
}
