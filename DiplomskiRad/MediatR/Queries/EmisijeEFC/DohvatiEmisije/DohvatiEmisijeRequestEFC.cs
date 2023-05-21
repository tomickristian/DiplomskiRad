using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisije
{
    public record DohvatiEmisijeRequestEFC(string? NazivPart) : IRequest<List<Emisija>>;
}
