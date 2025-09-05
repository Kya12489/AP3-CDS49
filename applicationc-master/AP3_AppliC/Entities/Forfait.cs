using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Forfait
{
    public int Idforfait { get; set; }

    public string Libelleforfait { get; set; } = null!;

    public string Descriptionforfait { get; set; } = null!;

    public string Contenuforfait { get; set; } = null!;

    public decimal? Prixforfait { get; set; }

    public long? Nbheures { get; set; }

    public decimal? Prixhoraire { get; set; }

    public virtual ICollection<Inscrire> Inscrires { get; set; } = new List<Inscrire>();
}
