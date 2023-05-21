using System;
using System.Collections.Generic;

namespace DiplomskiRad.Models;

public partial class Zanr
{
    public int Id { get; set; }

    public string Naziv { get; set; } = null!;

    public virtual ICollection<Emisija> Emisije { get; } = new List<Emisija>();
}
