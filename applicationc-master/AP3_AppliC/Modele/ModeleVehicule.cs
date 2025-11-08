using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP3_AppliC.Modele
{
    public class ModeleVehicule
    {
        public static List<Entities.Vehicule> listeVehicules()
        {
            return Modele.Connexion.MonModel.Vehicules.ToList();
        }
    }
}
