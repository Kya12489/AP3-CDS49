using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class TypeDoculent
{
    public int IdType { get; set; }

    public string LibelleType { get; set; } = null!;

    public virtual ICollection<Justificatifs> Documents { get; set; } = new List<Justificatifs>();
}
