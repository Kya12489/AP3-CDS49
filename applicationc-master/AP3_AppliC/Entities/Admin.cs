using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Admin
{
    public int IdAdmin { get; set; }

    public string NomAdmin { get; set; } = null!;

    public string PrenomAdmin { get; set; } = null!;

    public string LoginAdmin { get; set; } = null!;

    public string PasswordAdmin { get; set; } = null!;
}
