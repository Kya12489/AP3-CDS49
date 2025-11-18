using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Justificatifs
{
    public int IdDoc { get; set; }

    public int IdEleve { get; set; }

    public string? LienDoc { get; set; }

    public int IdStatut { get; set; }

    public int IdType { get; set; }

    public virtual Eleve IdEleveNavigation { get; set; } = null!;

    public virtual Statut IdStatutNavigation { get; set; } = null!;

    public virtual TypeDoculent IdTypeNavigation { get; set; } = null!;
}
