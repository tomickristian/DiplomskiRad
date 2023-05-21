using DiplomskiRad.Models;

namespace DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisije
{
    public record DohvatiEmisijeResponseDapper(int Id, string Naziv, string? Opis, DateTime? DatumIvrijemePrikazivanja);
}
