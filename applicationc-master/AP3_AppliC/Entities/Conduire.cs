using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Conduire
{
    public int Ideleve { get; set; }

    public int Idvehicule { get; set; }

    public int Idmoniteur { get; set; }

    public DateTime Heuredebut { get; set; }

    public string? Lieurdv { get; set; }

    public virtual Eleve IdeleveNavigation { get; set; } = null!;

    public virtual Moniteur IdmoniteurNavigation { get; set; } = null!;

    public virtual Vehicule IdvehiculeNavigation { get; set; } = null!;
}
