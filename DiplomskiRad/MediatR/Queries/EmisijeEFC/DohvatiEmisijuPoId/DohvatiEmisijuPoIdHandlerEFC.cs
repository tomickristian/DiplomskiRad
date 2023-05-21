using DiplomskiRad.Models;
using MediatR;
using DiplomskiRad.Exceptions;
using AutoMapper;
using DiplomskiRad.EFCRepository;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisijuPoId
{
    public class DohvatiEmisijuPoIdHandlerEFC : IRequestHandler<DohvatiEmisijuPoIdRequestEFC, DohvatiEmisijuPoIdResponseEFC>
    {
        private readonly IMapper _mapper;
        private readonly IEFCRepository<Emisija> _emisijeRepository;
        public DohvatiEmisijuPoIdHandlerEFC(IMapper mapper, IEFCRepository<Emisija> emisijeRepository)
        {
            _mapper = mapper;
            _emisijeRepository = emisijeRepository;
        }

        public async Task<DohvatiEmisijuPoIdResponseEFC> Handle(DohvatiEmisijuPoIdRequestEFC request, CancellationToken cancellationToken)
        {
            var emisija = _mapper.Map<DohvatiEmisijuPoIdResponseEFC>( await
                _emisijeRepository.Table()
                .Include(p => p.Zanr)
                .Include(p => p.TvPostaja)
                .AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken));

            return emisija ?? throw new EntityNotFoundException();
        }
    }
}
