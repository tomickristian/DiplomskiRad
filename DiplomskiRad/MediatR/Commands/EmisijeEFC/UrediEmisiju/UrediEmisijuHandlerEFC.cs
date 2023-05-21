using AutoMapper;
using DiplomskiRad.EFCRepository;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.UrediEmisiju
{
    public class UrediEmisijuHandlerEFC : IRequestHandler<UrediEmisijuRequestEFC, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEFCRepository<Emisija> _emisijeRepository;

        public UrediEmisijuHandlerEFC(IMapper mapper, IEFCRepository<Emisija> emisijeRepository)
        {
            _mapper = mapper;
            _emisijeRepository = emisijeRepository;
        }

        public async Task<Unit> Handle(UrediEmisijuRequestEFC request, CancellationToken cancellationToken)
        {
            await _emisijeRepository.UpdateAsync(_mapper.Map<Emisija>(request));
            await _emisijeRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
