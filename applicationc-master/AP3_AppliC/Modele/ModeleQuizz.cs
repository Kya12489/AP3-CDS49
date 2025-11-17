using AP3_AppliC.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_AppliC.Modele
{
    public static class ModeleQuizz
    {
        public static List<Entities.Question> listeTousQuestions()
        {
            return Modele.Connexion.MonModel.Questions
                .Include(q => q.IdCategorieNavigation)
                .ToList();
        }
        public static List<Category> listeTypes()
        {
            try
            {
                return Connexion.MonModel.Categories.ToList();
            }
            catch
            {
                return new List<Category>();
            }
        }

        public static List<Reponse> listeReponses()
        {
            try
            {
                return Connexion.MonModel.Reponses.ToList();
            }
            catch
            {
                return new List<Reponse>();
            }
        }

        public static List<Reponse> listeReponsesParQuestion(int idQ)
        {
            try
            {
                return Connexion.MonModel.Reponses
                    .Where(r => r.Idquestion == idQ)
                    .ToList();
            }
            catch
            {
                return new List<Reponse>();
            }
        }

        public static List<Question> RechercherQuestionsParCategorie(string categorie = null)
        {
            List<Question> toutesLesQuestions = Modele.Connexion.MonModel.Questions
                .Include(q => q.IdCategorieNavigation)
                .ToList();

            if (string.IsNullOrEmpty(categorie) || categorie == "Toutes les catégories")
            {
                return toutesLesQuestions;
            }

            string categorieRecherche = categorie.Trim().ToLower();
            return toutesLesQuestions
                .Where(q => q.IdCategorieNavigation.LibelleCategorie.ToLower() == categorieRecherche)
                .ToList();
        }

        public static Question AjoutQuestion(string libelle, int idCategorie)
        {
            try
            {
                // ajout dans la table Question
                Question uneQ = new Question();

                uneQ.Libellequestion = libelle;
                uneQ.IdCategorie = idCategorie;

                Modele.Connexion.MonModel.Questions.Add(uneQ);
                Modele.Connexion.MonModel.SaveChanges();

                return uneQ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de la question : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static Category AjoutCategorie(string libelle)
        {
            try
            {
                // ajout dans la table Category
                Category uneC = new Category();
                uneC.LibelleCategorie = libelle;
                Modele.Connexion.MonModel.Categories.Add(uneC);
                Modele.Connexion.MonModel.SaveChanges();
                return uneC;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
                return null;
            }
        }

        public static Question AjoutQuestionAvecReponse(string libelleQuestion, int idCategorie, List<(string libelle, bool estCorrecte)> reponses)
        {
            try
            {
                // 1. Créer la question
                Question uneQ = new Question();
                uneQ.Libellequestion = libelleQuestion;
                uneQ.IdCategorie = idCategorie;

                Connexion.MonModel.Questions.Add(uneQ);
                Connexion.MonModel.SaveChanges();

                // 2. Créer les réponses associées
                foreach (var reponse in reponses)
                {
                    Reponse uneR = new Reponse();
                    uneR.Idquestion = uneQ.Idquestion;
                    uneR.Libellereponse = reponse.libelle;
                    uneR.Valide = reponse.estCorrecte;

                    Connexion.MonModel.Reponses.Add(uneR);
                }

                Connexion.MonModel.SaveChanges();
                return uneQ;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de la question avec réponses : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        public static bool AjoutReponse(int idQuestion, string libelleReponse, bool estCorrecte)
        {
            try
            {
                Reponse uneR = new Reponse();
                uneR.Idquestion = idQuestion;
                uneR.Libellereponse = libelleReponse;
                uneR.Valide = estCorrecte;

                Connexion.MonModel.Reponses.Add(uneR);
                Connexion.MonModel.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ajout de la réponse : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static bool SupprimerQuestion(int idQuestion)
        {
            try
            {
                Question question = Connexion.MonModel.Questions
                    .FirstOrDefault(q => q.Idquestion == idQuestion);

                if (question == null)
                {
                    MessageBox.Show("Question introuvable.", "Erreur",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                // Supprimer les réponses associées
                var reponsesAssociees = Connexion.MonModel.Reponses
                    .Where(r => r.Idquestion == idQuestion)
                    .ToList();

                Connexion.MonModel.Reponses.RemoveRange(reponsesAssociees);

                // Supprimer la question
                Connexion.MonModel.Questions.Remove(question);
                Connexion.MonModel.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la suppression : {ex.Message}",
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
