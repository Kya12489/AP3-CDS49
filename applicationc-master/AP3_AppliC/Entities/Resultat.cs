using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Resultat
{
    public int Idresultat { get; set; }

    public int Ideleve { get; set; }

    public DateTime Dateresultat { get; set; }

    public long Score { get; set; }

    public int Nbquestions { get; set; }

    public virtual Eleve IdeleveNavigation { get; set; } = null!;
}
