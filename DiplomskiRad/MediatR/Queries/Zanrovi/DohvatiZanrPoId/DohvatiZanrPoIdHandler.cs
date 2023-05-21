using DiplomskiRad.EFCRepository;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Queries.Zanrovi.DohvatiZanrPoId
{
    //public class DohvatiZanrPoIdHandler : IRequestHandler<DohvatiZanrPoIdRequest, Zanr?>
    //{
    //    private readonly IEFCRepository<Zanr> _zanroviRepository;

    //    public DohvatiZanrPoIdHandler(IEFCRepository<Zanr> zanroviRepository)
    //    {
    //        _zanroviRepository = zanroviRepository;
    //    }

    //    public async Task<Zanr?> Handle(DohvatiZanrPoIdRequest request, CancellationToken cancellationToken)
    //    {
    //        return await _zanroviRepository.Table().FindAsync(request.Id, cancellationToken);
    //    }
    //}
}
