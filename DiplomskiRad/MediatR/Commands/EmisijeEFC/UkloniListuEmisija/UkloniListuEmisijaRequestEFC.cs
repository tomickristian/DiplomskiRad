using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.UkloniListuEmisija
{
    public record UkloniListuEmisijaRequestEFC(List<int> Ids) : IRequest;
}
