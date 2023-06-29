using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper
{
    public record UrediEmisijuRequestDapper(int Id, string Naziv, string? Opis, DateTime? DatumIvrijemePrikazivanja, int TvPostajaId, int ZanrId) : IRequest;
}
