using System;
using System.Collections.Generic;

namespace AP3_AppliC.Entities;

public partial class Eleve
{
    public int Ideleve { get; set; }

    public string Nomeleve { get; set; } = null!;

    public string Prenomeleve { get; set; } = null!;

    public string Emaileleve { get; set; } = null!;

    public string? Motpasseeleve { get; set; }

    public DateOnly Datenaissanceeleve { get; set; }

    public virtual ICollection<Conduire> Conduires { get; set; } = new List<Conduire>();

    public virtual ICollection<Inscrire> Inscrires { get; set; } = new List<Inscrire>();

    public virtual ICollection<Resultat> Resultats { get; set; } = new List<Resultat>();

    public virtual ICollection<Token> Tokens { get; set; } = new List<Token>();
}
