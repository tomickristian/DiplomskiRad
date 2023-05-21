using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Queries.TvPostaje.DohvatiTvPostaje
{
    public record DohvatiTvPostajeRequest(string? Naziv) : IRequest<IEnumerable<TvPostaja>>;
}
