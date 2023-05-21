using AutoMapper;
using DiplomskiRad.EFCRepository;
using DiplomskiRad.MediatR.Queries.TvPostaje.DohvatiTvPostajuPoId;
using DiplomskiRad.MediatR.Queries.Zanrovi.DohvatiZanrPoId;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.DodajEmisiju
{
    public class DodajEmisijuHandlerEFC : IRequestHandler<DodajEmisijuRequestEFC, Unit>
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

        public async Task<Unit> Handle(DodajEmisijuRequestEFC request, CancellationToken cancellationToken)
        {
            Emisija emisija = _mapper.Map<Emisija>(request);
            emisija.TvPostaja = await _mediator.Send(new DohvatiTvPostajuPoIdRequest(request.TvPostajaId));
            emisija.Zanr = await _mediator.Send(new DohvatiZanrPoIdRequest(request.TvPostajaId));
            await _emisijeRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
