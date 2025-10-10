using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AP3_AppliC.Entities;

namespace AP3_AppliC.Modele
{
    public static class Connexion
    {
        /// <summary>
        /// créé l'objet de lien (le CONTEXT) avec la BD
        /// </summary>
        private static Ap3LwsContext monModel;

        public static Ap3LwsContext MonModel { get => monModel; set => monModel = value; }

        /// <summary>
        /// Initialisation de la connexion avec la BD (à appeler dans Program.cs)
        /// </summary>
        public static void init()
        {
            monModel = new Ap3LwsContext();
        }
        /*
        public static bool VerifierAdmin()
        {
            Admin admin;
            bool vretour = true;
            try
            {
                admin.LoginAdmin = montant;
                admin.PasswordAdmin = ;


                monModel.SaveChanges();
            }
            catch (Exception ex)
            {
                vretour = false;
            }
            return vretour;
        }*/



    }
}
