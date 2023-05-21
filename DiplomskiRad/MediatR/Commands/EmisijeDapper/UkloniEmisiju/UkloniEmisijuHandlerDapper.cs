using DiplomskiRad.DapperRepository;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper.UkloniEmisiju
{
    public class UkloniEmisijuHandlerDapper : IRequestHandler<UkloniEmisijuRequestDapper, Unit>
    {
        private readonly IDapperRepository<Emisija> _emisijeRepository;

        public UkloniEmisijuHandlerDapper(IDapperRepository<Emisija> dapperRepository)
        {
            _emisijeRepository = dapperRepository;
        }

        public async Task<Unit> Handle(UkloniEmisijuRequestDapper request, CancellationToken cancellationToken)
        {
            await _emisijeRepository.DeleteByIdAsync(request.Id);
            return Unit.Value;
        }
    }
}
