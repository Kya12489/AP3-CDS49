using AP3_AppliC.Entities;
using AP3_AppliC.Modele;
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
    public partial class FormListeLecon : Form
    {
        public FormListeLecon()
        {
            InitializeComponent();
            ChargerDonnees();
        }

        

        private void ChargerDonnees()
        {
            var lecons = ModeleLecon.ObtenirLecons();
            var affichage = lecons.Select(c => new
            {
                Date = c.Heuredebut.Date,
                Début = c.Heuredebut,
                Fin = c.Heuredebut.AddMinutes(c.DureeMinutes),
                Durée = c.DureeMinutes + " min",
                Élève = c.IdeleveNavigation.Nomeleve + " " + c.IdeleveNavigation.Prenomeleve,
                Moniteur = c.IdmoniteurNavigation.Nommoniteur + " " + c.IdmoniteurNavigation.Prenommoniteur,
                Véhicule = c.IdvehiculeNavigation.Designation,
                Immatriculation = c.IdvehiculeNavigation.Immatriculation,
                Lieu = c.Lieurdv,

                // IDs cachés mais utiles
                IdEleve = c.Ideleve,
                IdMoniteur = c.Idmoniteur,
                IdVehicule = c.Idvehicule,
                HeureDebut = c.Heuredebut
            }).ToList();

            dgvLecon.DataSource = affichage;

            ConfigurerColonnes();
        }

        private void ConfigurerColonnes()
        {
            // Cacher les IDs
            dgvLecon.Columns["IdEleve"].Visible = false;
            dgvLecon.Columns["IdMoniteur"].Visible = false;
            dgvLecon.Columns["IdVehicule"].Visible = false;
            dgvLecon.Columns["HeureDebut"].Visible = false;

            dgvLecon.Columns["Date"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvLecon.Columns["Début"].DefaultCellStyle.Format = "HH:mm";
            dgvLecon.Columns["Fin"].DefaultCellStyle.Format = "HH:mm";
        }
    }
}