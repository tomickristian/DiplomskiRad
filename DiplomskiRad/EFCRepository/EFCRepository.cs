using DiplomskiRad.Exceptions;
using DiplomskiRad.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace DiplomskiRad.EFCRepository
{
    public class EFCRepository<T> : IEFCRepository<T> where T : class
    {
        private readonly TvProgramContext _context;

        public EFCRepository(TvProgramContext context)
        {
            _context = context;
        }
        public DbSet<T> Table()
        {
            return _context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await Table().AddAsync(entity);
        }
        public async Task AddListAsync(IEnumerable<T> entities)
        {
            await Table().AddRangeAsync(entities);
        }
        public async Task UpdateAsync(T entity)
        {
            await Task.Run(() => Table().Update(entity));
        }
        public async Task UpdateListAsync(IEnumerable<T> entities)
        {
            await Task.Run(() => Table().UpdateRange(entities));
        }
        public async Task RemoveByIdAsync(int id)
        {
            var entity = await Table().FindAsync(id);
            if (entity == null) throw new EntityNotFoundException();
            await Task.Run(() => Table().Remove(entity));
        }
        public async Task RemoveListByIdsAsync(List<int> ids)
        {
            var entitiesToRemove = Table().Where(e => ids.Contains((int)e.GetType().GetProperty("Id")!.GetValue(e)!));
            if (entitiesToRemove.Count() > 0) throw new EntityNotFoundException("Entiteti nisu pronađeni.");
            await Task.Run(() => Table().RemoveRange(entitiesToRemove));
        }
        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
