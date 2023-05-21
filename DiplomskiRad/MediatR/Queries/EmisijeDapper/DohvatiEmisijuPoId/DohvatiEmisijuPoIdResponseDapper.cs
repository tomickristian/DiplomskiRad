namespace DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisijuPoId
{
    public record DohvatiEmisijuPoIdResponseDapper(int Id, string Naziv, string? Opis, DateTime? DatumIvrijemePrikazivanja, int TvPostajaId, int ZanrId, string TvPostajaNaziv, string ZanrNaziv);
}
