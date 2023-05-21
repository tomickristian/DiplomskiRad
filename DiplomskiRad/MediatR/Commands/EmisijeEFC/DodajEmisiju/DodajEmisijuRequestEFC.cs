using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.DodajEmisiju
{
    public record DodajEmisijuRequestEFC(string Naziv, string? Opis, DateTime? DatumIvrijemePrikazivanja, int TvPostajaId, int ZanrId) : IRequest<Unit>;
}