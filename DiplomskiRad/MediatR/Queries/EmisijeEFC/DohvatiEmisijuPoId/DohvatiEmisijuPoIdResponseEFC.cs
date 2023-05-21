namespace DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisijuPoId
{
    public record DohvatiEmisijuPoIdResponseEFC(int Id, string Naziv, string? Opis, DateTime? DatumIvrijemePrikazivanja, int TvPostajaId, int ZanrId, string TvPostajaNaziv, string ZanrNaziv);
}
