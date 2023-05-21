using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper.UkloniListuEmisija
{
    public record UkloniListuEmisijaRequestDapper(List<int> Ids) : IRequest<Unit>;
}
