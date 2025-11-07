using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using BC = BCrypt.Net.BCrypt;
using AP3_AppliC.Modele;
using AP3_AppliC.Entities;

namespace AP3_AppliC.view
{
    public partial class FormConnexion : Form
    {
        public FormConnexion()
        {
            InitializeComponent();
        }

        private void btConnexion_Click(object sender, EventArgs e)
        {

            //this.Hide();
            //new FormMenu().Show();

            string identifiant = tbLogin.Text.Trim();
            string motDePasse = tbPassword.Text;
            Admin admin = ModeleAdmin.AuthentificationAdmin(identifiant, motDePasse);

            if (string.IsNullOrEmpty(identifiant) || string.IsNullOrEmpty(motDePasse))
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }


            if (admin != null)
            {
                MessageBox.Show("Connexion réussie !");
                // Redirection ou affichage de la fenêtre principale
                this.Hide();
                new FormMenu().Show();
            }
            else
            {
                MessageBox.Show("Identifiant ou mot de passe incorrect.");
            }

            #region Ajout admin
            /*
             bool ajout = Modele.ModeleAdmin.AjoutAdmin("Lhermite", "Bernard", "BernardLhermite64", "123546sdkofJI?");

             if (ajout)
             {
                 MessageBox.Show("Admin ajoutée");
             }
             else
             {
                 MessageBox.Show("Erreur lors de l'ajout");
             }
            */
            #endregion
        }

    }
}
