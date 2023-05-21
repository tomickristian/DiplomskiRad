using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper.UkloniEmisiju
{
    public record UkloniEmisijuRequestDapper(int Id) : IRequest<Unit>;
}
