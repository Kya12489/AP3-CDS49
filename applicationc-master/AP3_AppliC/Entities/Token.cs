using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Token
{
    public string Token1 { get; set; } = null!;

    public int Ideleve { get; set; }

    public DateTime DateCreation { get; set; }

    public virtual Eleve IdeleveNavigation { get; set; } = null!;
}
