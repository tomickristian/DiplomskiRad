using DiplomskiRad.Models;
using MediatR;
using DiplomskiRad.Exceptions;
using DiplomskiRad.DapperRepository;

namespace DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisijuPoId
{
    public class DohvatiEmisijuPoIdHandlerDapper : IRequestHandler<DohvatiEmisijuPoIdRequestDapper, DohvatiEmisijuPoIdResponseDapper>
    {
        private readonly IDapperRepository<Emisija> _emisijeRepository;

        public DohvatiEmisijuPoIdHandlerDapper(IDapperRepository<Emisija> emisijeRepository)
        {
            _emisijeRepository = emisijeRepository;
        }
        public async Task<DohvatiEmisijuPoIdResponseDapper> Handle(DohvatiEmisijuPoIdRequestDapper request, CancellationToken cancellationToken)
        {
            string sql =
                "SELECT e.Id, e.Naziv, e.Opis, e.DatumIvrijemePrikazivanja, e.TvPostajaId, e.ZanrId, p.Naziv AS TvPostajaNaziv, z.Naziv AS ZanrNaziv FROM Emisija AS e " +
                "INNER JOIN TvPostaja AS p ON e.TvPostajaId = p.Id " +
                "INNER JOIN Zanr AS z ON e.ZanrId = z.Id " +
                $"WHERE e.Id = {request.Id}";
            DohvatiEmisijuPoIdResponseDapper? emisija = await _emisijeRepository.GetByIdAsync<DohvatiEmisijuPoIdResponseDapper>(sql, cancellationToken);

            return emisija ?? throw new EntityNotFoundException();
        }
    }
}
