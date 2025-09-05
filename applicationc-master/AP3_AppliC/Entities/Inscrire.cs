using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Inscrire
{
    public int Ideleve { get; set; }

    public int Idforfait { get; set; }

    public DateOnly Dateinscription { get; set; }

    public virtual Eleve IdeleveNavigation { get; set; } = null!;

    public virtual Forfait IdforfaitNavigation { get; set; } = null!;
}
