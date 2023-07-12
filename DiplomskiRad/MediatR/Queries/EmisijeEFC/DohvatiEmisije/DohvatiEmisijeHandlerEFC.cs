using AutoMapper;
using AutoMapper.QueryableExtensions;
using DiplomskiRad.EFCRepository;
using DiplomskiRad.Exceptions;
using DiplomskiRad.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisije
{
    public class DohvatiEmisijeHandlerEFC : IRequestHandler<DohvatiEmisijeRequestEFC, List<DohvatiEmisijeResponseEFC>>
    {
        private readonly IMapper _mapper;
        private readonly IEFCRepository<Emisija> _emisijeRepository;

        public DohvatiEmisijeHandlerEFC(IMapper mapper, IEFCRepository<Emisija> repository)
        {
            _mapper = mapper;
            _emisijeRepository = repository;
        }

        public async Task<List<DohvatiEmisijeResponseEFC>> Handle(DohvatiEmisijeRequestEFC request, CancellationToken cancellationToken)
        {
            List<DohvatiEmisijeResponseEFC> result;
            if (request.NazivPart.IsNullOrEmpty())
            {
                result = await _emisijeRepository.Table()
                    .ProjectTo<DohvatiEmisijeResponseEFC>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            else
            {
                result = await _emisijeRepository.Table()
                    .Where(e => e.Naziv.Contains(request.NazivPart))
                    .ProjectTo<DohvatiEmisijeResponseEFC>(_mapper.ConfigurationProvider)
                    .AsNoTracking()
                    .ToListAsync(cancellationToken);
            }
            return result ?? throw new EntityNotFoundException();
        }
    }
}
