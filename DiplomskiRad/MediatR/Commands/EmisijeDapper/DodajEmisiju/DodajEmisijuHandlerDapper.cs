using DiplomskiRad.DapperRepository;
using DiplomskiRad.Models;
using MediatR;

namespace DiplomskiRad.MediatR.Commands.EmisijeDapper.DodajEmisiju
{
    public class DodajEmisijuHandlerDapper : IRequestHandler<DodajEmisijuRequestDapper, Unit>
    {
        private readonly IDapperRepository<Emisija> _emisijeRepository;

        public DodajEmisijuHandlerDapper(IDapperRepository<Emisija> emisijeRepository)
        {
            _emisijeRepository = emisijeRepository;
        }

        public async Task<Unit> Handle(DodajEmisijuRequestDapper request, CancellationToken cancellationToken)
        {
            await _emisijeRepository.AddAsync(request);
            return Unit.Value;
        }
    }
}
