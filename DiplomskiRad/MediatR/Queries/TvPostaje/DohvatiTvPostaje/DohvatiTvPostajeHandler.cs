using AutoMapper;
using DiplomskiRad.EFCRepository;
using DiplomskiRad.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace DiplomskiRad.MediatR.Queries.TvPostaje.DohvatiTvPostaje
{
    //public class DohvatiTvPostajeHandler : IRequestHandler<DohvatiTvPostajeRequest, IEnumerable<TvPostaja>>
    //{
    //    private readonly IEFCRepository<TvPostaja> _tvPostajeRepository;

    //    public DohvatiTvPostajeHandler(IEFCRepository<TvPostaja> tvPostajeRepository)
    //    {
    //        _tvPostajeRepository = tvPostajeRepository;
    //    }

    //    public async Task<IEnumerable<TvPostaja>> Handle(DohvatiTvPostajeRequest request, CancellationToken cancellationToken)
    //    {
    //        var result = request.Naziv.IsNullOrEmpty() ? 
    //            await _tvPostajeRepository.Table().AsNoTracking().ToListAsync(cancellationToken) 
    //            : await _tvPostajeRepository.Table().Where(t => t.Naziv.ToLower().Contains(request.Naziv!.ToLower())).AsNoTracking().ToListAsync(cancellationToken);
    //        return result;
    //    }
    //}
}