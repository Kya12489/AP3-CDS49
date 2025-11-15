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
    }
}
