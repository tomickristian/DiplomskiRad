using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.UkloniEmisiju
{
    public record UkloniEmisijuRequestEFC(int Id) : IRequest;
}
