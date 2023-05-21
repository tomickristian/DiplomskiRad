using MediatR;

namespace DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisijuPoId
{
    public record DohvatiEmisijuPoIdRequestEFC(int Id) : IRequest<DohvatiEmisijuPoIdResponseEFC>;
}
