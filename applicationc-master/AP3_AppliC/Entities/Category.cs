using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Category
{
    public int IdCategorie { get; set; }

    public string LibelleCategorie { get; set; } = null!;

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();
}
