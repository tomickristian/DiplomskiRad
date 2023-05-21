using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper.DodajEmisiju
{
    public record DodajEmisijuRequestDapper(string Naziv, string? Opis, DateTime? DatumIvrijemePrikazivanja, int TvPostajaId, int ZanrId) : IRequest<Unit>;
}