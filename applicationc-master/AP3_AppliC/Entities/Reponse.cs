using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Reponse
{
    public int Idquestion { get; set; }

    public int Numreponse { get; set; }

    public string Libellereponse { get; set; } = null!;

    public bool? Valide { get; set; }

    public virtual Question IdquestionNavigation { get; set; } = null!;
}
