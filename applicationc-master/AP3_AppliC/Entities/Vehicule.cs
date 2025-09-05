using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Vehicule
{
    public int Idvehicule { get; set; }

    public int? Nbpassagers { get; set; }

    public string Immatriculation { get; set; } = null!;

    public string? Designation { get; set; }

    public bool? Manuel { get; set; }

    public virtual ICollection<Conduire> Conduires { get; set; } = new List<Conduire>();
}
