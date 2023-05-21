using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisije
{
    public record DohvatiEmisijeRequestDapper(string? NazivPart) : IRequest<List<DohvatiEmisijeResponseDapper>?>;
}
