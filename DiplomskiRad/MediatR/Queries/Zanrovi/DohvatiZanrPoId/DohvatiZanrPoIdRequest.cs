using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Queries.Zanrovi.DohvatiZanrPoId
{
    public record DohvatiZanrPoIdRequest(int Id) : IRequest<Zanr>;
}
