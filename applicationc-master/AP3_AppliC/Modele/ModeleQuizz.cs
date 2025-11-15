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
    }
}
