using AutoMapper;
using DiplomskiRad.EFCRepository;
using DiplomskiRad.MediatR.Queries.TvPostaje.DohvatiTvPostajuPoId;
using DiplomskiRad.MediatR.Queries.Zanrovi.DohvatiZanrPoId;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.DodajEmisiju
{
    public class DodajEmisijuHandlerEFC : IRequestHandler<DodajEmisijuRequestEFC>
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly IEFCRepository<Emisija> _emisijeRepository;

        public DodajEmisijuHandlerEFC(IMapper mapper, IMediator mediator, IEFCRepository<Emisija> repository)
        {
            _mapper = mapper;
            _mediator = mediator;
            _emisijeRepository = repository;
        }

        public async Task Handle(DodajEmisijuRequestEFC request, CancellationToken cancellationToken)
        {
            await _emisijeRepository.AddAsync(_mapper.Map<Emisija>(request));
            await _emisijeRepository.SaveAsync();
        }
    }
}
