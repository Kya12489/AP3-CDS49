using AP3_AppliC.view;
using System.Reflection.Metadata;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AP3_AppliC.Modele;
namespace AP3_AppliC
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            // Connexion à la BD
            Modele.Connexion.init();
            Application.Run(new FormConnexion());

            
        }

    }
}