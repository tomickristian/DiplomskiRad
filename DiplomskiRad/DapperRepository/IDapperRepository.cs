namespace DiplomskiRad.DapperRepository
{
    public interface IDapperRepository<T> where T : class
    {
        Task<IEnumerable<TResult>> QueryAllAsync<TResult>(string sql, CancellationToken cancellationToken);
        Task<TResult> GetByIdAsync<TResult>(string sql, CancellationToken cancellationToken);
        Task AddAsync<TRequest>(TRequest entity);
        Task UpdateAsync<TRequest>(TRequest entity);
        Task DeleteByIdAsync(int id);
        Task DeleteListByIdsAsync(List<int> ids);
    }
}