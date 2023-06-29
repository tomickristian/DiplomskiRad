using DiplomskiRad.EFCRepository;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.UkloniEmisiju
{
    public class UkloniEmisijuHandlerEFC : IRequestHandler<UkloniEmisijuRequestEFC>
    {
        private readonly IEFCRepository<Emisija> _emisijeRepository;

        public UkloniEmisijuHandlerEFC(IEFCRepository<Emisija> tvProgramRepository)
        {
            _emisijeRepository = tvProgramRepository;
        }

        public async Task Handle(UkloniEmisijuRequestEFC request, CancellationToken cancellationToken)
        {
            await _emisijeRepository.RemoveByIdAsync(request.Id);
            await _emisijeRepository.SaveAsync();
            
        }
    }
}
