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

            if (Modele.ModeleEleve.EmailExiste(mail))
            {
                MessageBox.Show($"L'adresse email '{mail}' est déjà utilisée.",
                    "Email existant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbEmail.Focus();
                return;
            }
            #endregion

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

            bool ajout = Modele.ModeleEleve.AjoutEleve(nom, prenom, mail, mdp, date, telEnvoyer);

            if (ajout)
            {
                MessageBox.Show("Élève inscrit avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (cbForfait.SelectedIndex != -1)
                {
                    int idForfait = Convert.ToInt32(cbForfait.SelectedValue);
                    int idE = Modele.ModeleEleve.
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

        private void FormInscriptionEleve_Load(object sender, EventArgs e)
        {
            RemplirListeForfaits();
        }
    }
}
