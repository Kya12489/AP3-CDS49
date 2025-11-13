using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Moniteur
{
    public int Idmoniteur { get; set; }

    public string Nommoniteur { get; set; } = null!;

    public string Prenommoniteur { get; set; } = null!;

    public string Emailmoniteur { get; set; } = null!;

    public bool Archiver { get; set; }

    public virtual ICollection<Conduire> Conduires { get; set; } = new List<Conduire>();
}
