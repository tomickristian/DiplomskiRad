using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.UrediEmisiju
{
    public record UrediEmisijuRequestEFC(int Id, string Naziv, string? Opis, DateTime? DatumIvrijemePrikazivanja, int TvPostajaId, int ZanrId) : IRequest;
}
