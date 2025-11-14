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
            return Modele.Connexion.MonModel.Questions.ToList();
        }
    }
}
