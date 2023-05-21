using DiplomskiRad.EFCRepository;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeEFC.UkloniListuEmisija
{
    public class UkloniListuEmisijaHandlerEFC : IRequestHandler<UkloniListuEmisijaRequestEFC, Unit>
    {
        private readonly IEFCRepository<Emisija> _EmisijeRepository;

        public UkloniListuEmisijaHandlerEFC(IEFCRepository<Emisija> emisijeRepository)
        {
            _EmisijeRepository = emisijeRepository;
        }

        public async Task<Unit> Handle(UkloniListuEmisijaRequestEFC request, CancellationToken cancellationToken)
        {
            await _EmisijeRepository.RemoveListByIdsAsync(request.Ids);
            await _EmisijeRepository.SaveAsync();
            return Unit.Value;
        }
    }
}
