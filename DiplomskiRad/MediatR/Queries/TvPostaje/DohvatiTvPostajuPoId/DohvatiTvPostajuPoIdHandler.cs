using DiplomskiRad.EFCRepository;
using DiplomskiRad.Exceptions;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Queries.TvPostaje.DohvatiTvPostajuPoId
{
    public class DohvatiTvPostajuPoIdHandler : IRequestHandler<DohvatiTvPostajuPoIdRequest, TvPostaja>
    {
        private readonly IEFCRepository<TvPostaja> _tvPostajeRepository;

        public DohvatiTvPostajuPoIdHandler(IEFCRepository<TvPostaja> tvPostajeRepository)
        {
            _tvPostajeRepository = tvPostajeRepository;
        }

        public async Task<TvPostaja> Handle(DohvatiTvPostajuPoIdRequest request, CancellationToken cancellationToken)
        {
            TvPostaja? tvPostaja = await _tvPostajeRepository.Table().FindAsync(request.Id, cancellationToken);
            return tvPostaja ?? throw new EntityNotFoundException();
        }
    }
}
