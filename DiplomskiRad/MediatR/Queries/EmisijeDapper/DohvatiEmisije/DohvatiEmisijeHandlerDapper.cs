using DiplomskiRad.DapperRepository;
using DiplomskiRad.Models;
using MediatR;
using Microsoft.IdentityModel.Tokens;
using static System.Net.Mime.MediaTypeNames;

namespace DiplomskiRad.MediatR.Queries.EmisijeDapper.DohvatiEmisije
{
    public class DohvatiEmisijeHandlerDapper : IRequestHandler<DohvatiEmisijeRequestDapper, List<DohvatiEmisijeResponseDapper>?>
    {
        private readonly IDapperRepository<Emisija> _emisijeRepository;

        public DohvatiEmisijeHandlerDapper(IDapperRepository<Emisija> emisijeRepository)
        {
            _emisijeRepository = emisijeRepository;
        }

        public async Task<List<DohvatiEmisijeResponseDapper>?> Handle(DohvatiEmisijeRequestDapper request, CancellationToken cancellationToken)
        {
            string sql = "SELECT e.Id, e.Naziv, e.Opis, e.DatumIvrijemePrikazivanja FROM Emisija AS e";
            sql = !request.NazivPart.IsNullOrEmpty() ? sql + $" WHERE LOWER(e.Naziv) LIKE '%{request.NazivPart!.ToLower()}%'" : sql;

            var results = await _emisijeRepository.QueryAllAsync<DohvatiEmisijeResponseDapper>(sql, cancellationToken);
            return results.ToList();
        }
    }
}
