using System;
using System.Collections.Generic;

namespace DiplomskiRad.Models;

public partial class Emisija
{
    public int Id { get; set; }
    public string Naziv { get; set; } = null!;
    public string? Opis { get; set; }
    public DateTime? DatumIvrijemePrikazivanja { get; set; }
    public int TvPostajaId { get; set; }
    public int ZanrId { get; set; }
    public virtual TvPostaja TvPostaja { get; set; } = null!;
    public virtual Zanr Zanr { get; set; } = null!;
}
