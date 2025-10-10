using AP3_AppliC.Entities;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BC = BCrypt.Net.BCrypt;


namespace AP3_AppliC.Modele
{
    public static class ModeleAdmin
    {
        

        public static bool AjoutAdmin(string nom, string prenom, string login, string password)
        {
            Admin admin;
            bool vretour = true;
            try
            {
                admin = new Admin();
                string mdpHash = BC.HashPassword(password);

                admin.NomAdmin = nom; 
                admin.PrenomAdmin = prenom;
                admin.LoginAdmin = login;
                admin.PasswordAdmin = mdpHash;
                // ajout de l’objet : correspond à un insert
                Modele.Connexion.MonModel.Admins.Add(admin); // correspond à un INSERT INTO
                Modele.Connexion.MonModel.SaveChanges();
            }
            catch (Exception ex)
            {
                vretour = false;
            }
            return vretour;
        }
        
        public static Admin? RecupAdmin(string login, string password)
        {
            // vérifie si le login et le password correspondent
            bool passwordHash = BC.Verify(password, Connexion.MonModel.Admins.First().PasswordAdmin.ToString());
            Admin admin = Connexion.MonModel.Admins.FirstOrDefault(u => u.LoginAdmin == login && passwordHash);
            return admin;
        }
       
    }
}
