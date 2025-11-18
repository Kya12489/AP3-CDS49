using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Statut
{
    public int IdStatut { get; set; }

    public string LibelleStatut { get; set; } = null!;

    public virtual ICollection<Justificatifs> Documents { get; set; } = new List<Justificatifs>();
}
