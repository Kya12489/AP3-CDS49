using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
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
    }
}
