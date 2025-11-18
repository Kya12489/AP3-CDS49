using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AP3_AppliC
{
    public static class Controleur
    {
        /// <summary>
        /// méthode qui retourne vrai ou faux selon la validité du format d'un email passé en paramètres
        /// </summary>
        /// <param name="mail"></param>
        /// <returns></returns>
        public static bool ValidMail(string mail)
        {

            string pattern = @"^([a-zA-Z0-9_\.]+)@([a-zA-Z0-9_\-]+)\.([\w]{2,4})$";
            Regex r1 = new Regex(pattern);
            return r1.IsMatch(mail);
        }


        /// <summary>
        /// permet l'envoi d'un mail sur le serveur smtp mis en place pour l'AP
        /// </summary>
        /// <param name="dest"></param>
        public static void CreationEmail(string dest, string nom, string prenom)
        {
            string to = dest;
            string from = "admin.chevrollier.driving.school49@cds49.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "CDS 49 : AJOUT D'UN MONITEUR";
            message.Body = "Bonjour " + nom + " " + prenom + ",\n\nNous validons la création de votre compte en tant que nouveau moniteur du CDS 49.\n\nBien Cordialement,\n\nChevrollier Driving School49";
            SmtpClient client = new SmtpClient();

            client.Host = "mail.dombtsig.local";
            client.Port = 1025;

            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateEmail(): {0}", ex.ToString());
            }
        }
        public static void CreationEmailEleve(string dest, string nom, string prenom, string mdp)
        {
            string to = dest;
            string from = "admin.chevrollier.driving.school49@cds49.com";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "CDS 49 : AJOUT D'UN ELEVE";
            message.Body = "Bonjour " + nom + " " + prenom + ",\n\nNous validons la création de votre compte en tant que nouvelle élève du CDS 49.\n\nVoici votre mot de passe : " + mdp + "\n\nBien Cordialement,\n\nChevrollier Driving School49";
            SmtpClient client = new SmtpClient();

            client.Host = "mail.dombtsig.local";
            client.Port = 1025;

            // Credentials are necessary if the server requires the client
            // to authenticate before it will send email on the client's behalf.
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateEmail(): {0}", ex.ToString());
            }
        }
        public static bool KeyPressEntier(object sender, KeyPressEventArgs e)
        {
            bool valeurCorrect = true; 
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != Convert.ToChar(Keys.Back))
            {
                valeurCorrect = false;
            }
            if (valeurCorrect == false) {
                MessageBox.Show("Erreur, vous devez saisir des entiers", "Erreur", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return valeurCorrect;
        }
        public static bool KeyPressDouble(object sender, KeyPressEventArgs e)
        {
            bool valeurCorrect = true;
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != Convert.ToChar(Keys.Back) && e.KeyChar != ',')
            {
                valeurCorrect = false;
            }
            if (valeurCorrect == false)
            {
                MessageBox.Show("Erreur, vous devez saisir des entiers", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return valeurCorrect;
        }

        public static bool MdpValide(string mdp, out string messageErreur)
        {
            messageErreur = "";

            if (string.IsNullOrWhiteSpace(mdp))
            {
                messageErreur = "Le mot de passe est obligatoire.";
                return false;
            }

            if (mdp.Length < 12)
            {
                messageErreur = "Le mot de passe doit contenir au moins 12 caractères.";
                return false;
            }

            if (!Regex.IsMatch(mdp, @"[A-Z]"))
            {
                messageErreur = "Le mot de passe doit contenir au moins une lettre majuscule.";
                return false;
            }

            if (!Regex.IsMatch(mdp, @"[a-z]"))
            {
                messageErreur = "Le mot de passe doit contenir au moins une lettre minuscule.";
                return false;
            }

            if (!Regex.IsMatch(mdp, @"[0-9]"))
            {
                messageErreur = "Le mot de passe doit contenir au moins un chiffre.";
                return false;
            }

            if (!Regex.IsMatch(mdp, @"[^a-zA-Z0-9]"))
            {
                messageErreur = "Le mot de passe doit contenir au moins un caractère spécial (!@#$%^&*...).";
                return false;
            }

            return true;

        }
        public static string NettoyerNumeroTelephone(string numero)
        {
            if (string.IsNullOrWhiteSpace(numero))
                return "";

            return numero.Replace(" ", "")
                        .Replace(".", "")
                        .Replace("-", "")
                        .Replace("(", "")
                        .Replace(")", "");
        }
        public static bool NumTelValide(string numero)
        {
            string numeroNettoye = NettoyerNumeroTelephone(numero);

            // Vérifier format français : 10 chiffres commençant par 0
            return Regex.IsMatch(numeroNettoye, @"^0[1-9]\d{8}$");
        }
    }
}
