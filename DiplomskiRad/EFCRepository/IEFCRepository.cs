using DiplomskiRad.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DiplomskiRad.EFCRepository
{
    public interface IEFCRepository<T> : IDisposable where T : class
    {
        DbSet<T> Table();
        List<Emisija> GetAll();
        Task AddAsync(T entity);
        Task AddListAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task UpdateListAsync(IEnumerable<T> entities);
        Task RemoveByIdAsync(int id);
        Task RemoveListByIdsAsync(List<int> ids);
        Task SaveAsync();
    }
}
