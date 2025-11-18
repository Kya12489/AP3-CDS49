using AP3_AppliC.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_AppliC.Modele
{
    public class ModeleLecon
    {
        public static List<Conduire> RecupererLeconsPeriode(DateTime debut, DateTime fin)
        {
            try
            {
                return Connexion.MonModel.Conduires
                    .Where(l => l.Heuredebut >= debut && l.Heuredebut <= fin)
                    .ToList();
            }
            catch
            {
                return new List<Conduire>();
            }
        }

        public static List<object> RecupererDisponibilites(
            DateTime dateHeure,
            int? idEleve,
            int? idMoniteur,
            int? idVehicule)
        {
            var resultats = new List<object>();

            // Logique pour afficher les disponibilités selon ce qui est déjà sélectionné
            // À implémenter selon tes besoins

            return resultats;
        }

        /*
        public static bool AjouterLecon(int idEleve, int idMoniteur, int idVehicule, DateTime dateHeure, string lieu)
        {
            try
            {
                Conduire lecon = new Conduire()
                {
                    Ideleve = idEleve,
                    Idmoniteur = idMoniteur,
                    Idvehicule = idVehicule,
                    Heuredebut = dateHeure,
                    Lieurdv = string.IsNullOrWhiteSpace(lieu) ? null : lieu,
                };

                Connexion.MonModel.Conduires.Add(lecon);
                Connexion.MonModel.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }*/
        public static bool AjouterLecon(int idEleve, int idMoniteur, int idVehicule, DateTime dateHeure, string lieu)
        {
            try
            {
                using (var context = new Ap3LwsContext())
                {
                    // Vérifier que l'élève, le moniteur et le véhicule existent
                    bool eleveExiste = context.Eleves.Any(e => e.Ideleve == idEleve);
                    bool moniteurExiste = context.Moniteurs.Any(m => m.Idmoniteur == idMoniteur);
                    bool vehiculeExiste = context.Vehicules.Any(v => v.Idvehicule == idVehicule);

                    if (!eleveExiste || !moniteurExiste || !vehiculeExiste)
                    {
                        MessageBox.Show("L'élève, le moniteur ou le véhicule n'existe pas.");
                        return false;
                    }

                    // Créer une nouvelle leçon
                    Conduire lecon = new Conduire()
                    {
                        Ideleve = idEleve,
                        Idmoniteur = idMoniteur,
                        Idvehicule = idVehicule,
                        Heuredebut = dateHeure,
                        Lieurdv = string.IsNullOrWhiteSpace(lieu) ? null : lieu,
                        DureeMinutes = 60, // Durée par défaut
                        Archiver = false,
                    };

                    // Ajouter la leçon au contexte
                    context.Conduires.Add(lecon);

                    // Sauvegarder les modifications
                    context.SaveChanges();

                    return true;
                }
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // En cas de conflit de concurrency, afficher un message
                MessageBox.Show("Conflit de concurrency détecté. Les données ont été modifiées par un autre utilisateur. Veuillez réessayer.");
                return false;
            }
            catch (Exception ex)
            {
                // Gérer les autres exceptions
                MessageBox.Show($"Erreur lors de l'ajout de la leçon : {ex.Message}");
                return false;
            }
        }
        /*
        public static List<Conduire> ObtenirLecons(DateTime? dateDebut = null, DateTime? dateFin = null)
        {
            using (var context = new Ap3LwsContext())
            {
                var query = context.Conduires
                    .Include(c => c.IdeleveNavigation)
                    .Include(c => c.IdmoniteurNavigation)
                    .Include(c => c.IdvehiculeNavigation)
                    .AsQueryable();

                if (dateDebut != null)
                    query = query.Where(c => c.Heuredebut >= dateDebut.Value);

                if (dateFin != null)
                    query = query.Where(c => c.Heuredebut <= dateFin.Value);

                return query
                    .OrderBy(c => c.Heuredebut)
                    .ToList();
            }
        }*/

        public static List<dynamic> ObtenirMoniteursPourFiltre()
        {
            using (var context = new Ap3LwsContext())
            {
                var moniteurs = context.Moniteurs
                    .Select(m => new { m.Idmoniteur, Nom = m.Nommoniteur + " " + m.Prenommoniteur })
                    .OrderBy(m => m.Nom)
                    .ToList<dynamic>();

                // Ajouter l'option "Tous"
                moniteurs.Insert(0, new { Idmoniteur = 0, Nom = "-- Tous --" });

                return moniteurs;
            }
        }

        public static List<dynamic> ObtenirElevesPourFiltre()
        {
            using (var context = new Ap3LwsContext())
            {
                var eleves = context.Eleves
                    .Select(e => new { e.Ideleve, Nom = e.Nomeleve + " " + e.Prenomeleve })
                    .OrderBy(e => e.Nom)
                    .ToList<dynamic>();

                // Ajouter l'option "Tous"
                eleves.Insert(0, new { Ideleve = 0, Nom = "-- Tous --" });

                return eleves;
            }
        }
        /*
        public static bool SupprimerLecon(int idEleve, int idMoniteur, int idVehicule, DateTime heureDebut)
        {
            try
            {
                using (var context = new Ap3LwsContext())
                {
                    var lecon = context.Conduires.FirstOrDefault(c =>
                        c.Ideleve == idEleve &&
                        c.Idmoniteur == idMoniteur &&
                        c.Idvehicule == idVehicule &&
                        c.Heuredebut == heureDebut);

                    if (lecon != null)
                    {
                        context.Conduires.Remove(lecon);
                        context.SaveChanges();
                        return true;
                    }

                    return false;
                }
            }
            catch
            {
                return false;
            }
        }*/

        public static bool SupprimerLecon(int idEleve, int idMoniteur, int idVehicule, DateTime heureDebut)
        {
            try
            {
                using (var context = new Ap3LwsContext())
                {
                    // Récupérer la leçon à supprimer en utilisant la clé composite
                    var lecon = context.Conduires.FirstOrDefault(c =>
                        c.Ideleve == idEleve &&
                        c.Idmoniteur == idMoniteur &&
                        c.Idvehicule == idVehicule &&
                        c.Heuredebut == heureDebut);

                    if (lecon != null)
                    {
                        // Supprimer la leçon
                        context.Conduires.Remove(lecon);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                MessageBox.Show("Conflit de concurrency détecté. Les données ont été modifiées par un autre utilisateur. Veuillez réessayer.");
                return false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression de la leçon : {ex.Message}");
                return false;
            }
        }
        /*
        public static Conduire ObtenirLecon(int idEleve, int idMoniteur, int idVehicule, DateTime heureDebut)
        {
            using (var context = new Ap3LwsContext())
            {
                return context.Conduires.FirstOrDefault(c =>
                    c.Ideleve == idEleve &&
                    c.Idmoniteur == idMoniteur &&
                    c.Idvehicule == idVehicule &&
                    c.Heuredebut == heureDebut);
            }
        }*/
        public static List<Conduire> ObtenirLecons(DateTime? dateDebut = null,DateTime? dateFin = null,int? idMoniteur = null,int? idEleve = null)
        {
            using (var context = new Ap3LwsContext())
            {
                var query = context.Conduires
                    .Include(c => c.IdeleveNavigation)
                    .Include(c => c.IdmoniteurNavigation)
                    .Include(c => c.IdvehiculeNavigation)
                    .AsQueryable();

                if (dateDebut.HasValue)
                    query = query.Where(c => c.Heuredebut >= dateDebut.Value.Date);

                if (dateFin.HasValue)
                    query = query.Where(c => c.Heuredebut <= dateFin.Value.Date.AddDays(1).AddSeconds(-1));

                if (idMoniteur.HasValue && idMoniteur.Value > 0)
                    query = query.Where(c => c.Idmoniteur == idMoniteur.Value);

                if (idEleve.HasValue && idEleve.Value > 0)
                    query = query.Where(c => c.Ideleve == idEleve.Value);

                return query.ToList();
            }
        }
        public static List<string> ObtenirLieuxDepuisConduire()
        {
            try
            {
                using (var context = new Ap3LwsContext())
                {
                    // Récupère les lieux uniques, non vides, et triés par ordre alphabétique
                    var lieux = context.Conduires
                        .Where(c => !string.IsNullOrEmpty(c.Lieurdv))
                        .Select(c => c.Lieurdv)
                        .Distinct()
                        .OrderBy(l => l)
                        .ToList();

                    // Ajoute une option par défaut
                    lieux.Insert(0, "-- Sélectionnez un lieu --");

                    return lieux;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la récupération des lieux : {ex.Message}");
                return new List<string> { "-- Erreur --" };
            }


        }

    }
}
