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
        private static Ap320252026Context monModel;

        public static Ap320252026Context MonModel { get => monModel; set => monModel = value; }

        /// <summary>
        /// Initialisation de la connexion avec la BD (à appeler dans Program.cs)
        /// </summary>
        public static void init()
        {
            monModel = new Ap320252026Context();
        }



    }
}
