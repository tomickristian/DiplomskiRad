using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Queries.TvPostaje.DohvatiTvPostajuPoId
{
    public record DohvatiTvPostajuPoIdRequest(int Id) : IRequest<TvPostaja>;
}
