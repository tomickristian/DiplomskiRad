using DiplomskiRad.DapperRepository;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper.UrediEmisiju
{
    public class UrediEmisijuHandlerDapper : IRequestHandler<UrediEmisijuRequestDapper, Unit>
    {
        private readonly IDapperRepository<Emisija> _emisijeRepository;

        public UrediEmisijuHandlerDapper(IDapperRepository<Emisija> emisijeRepository)
        {
            _emisijeRepository = emisijeRepository;
        }

        public async Task<Unit> Handle(UrediEmisijuRequestDapper request, CancellationToken cancellationToken)
        {
            await _emisijeRepository.UpdateAsync(request);
            return Unit.Value;
        }
    }
}
