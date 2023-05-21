using MediatR;

namespace DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisijuPoId
{
    public record DohvatiEmisijuPoIdRequestDapper(int Id) : IRequest<DohvatiEmisijuPoIdResponseDapper>;
}
