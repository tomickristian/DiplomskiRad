using AutoMapper;
using AutoMapper.QueryableExtensions;
using DiplomskiRad.EFCRepository;
using DiplomskiRad.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace DiplomskiRad.MediatR.Queries.EmisijeEFC.DohvatiEmisije
{
    public class DohvatiEmisijeHandlerEFC : IRequestHandler<DohvatiEmisijeRequestEFC, List<Emisija>>
    {

        private readonly Emisija text = new Emisija() { Id = 2006, Naziv = "string", Opis = "strin", DatumIvrijemePrikazivanja = DateTime.Now };
        private readonly IMapper _mapper;
        private readonly IEFCRepository<Emisija> _emisijeRepository;

        public DohvatiEmisijeHandlerEFC(IMapper mapper, IEFCRepository<Emisija> repository)
        {
            _mapper = mapper;
            _emisijeRepository = repository;
        }

        public async Task<List<Emisija>> Handle(DohvatiEmisijeRequestEFC request, CancellationToken cancellationToken)
        {
            List<Emisija> result = new();
            for (int i = 0; i < 1000; i++)
            {
                result.Add(text);
            }
            //var result = await _emisijeRepository.Table()
            //    .OrderByDescending(p => p.Naziv)
            //    .ProjectTo<DohvatiEmisijeResponseEFC>(_mapper.ConfigurationProvider)
            //    .AsNoTracking()
            //    .ToListAsync(cancellationToken);
            return result;
        }
    }
}
