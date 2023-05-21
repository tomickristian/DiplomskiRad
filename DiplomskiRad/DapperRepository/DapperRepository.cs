using Dapper;
using DiplomskiRad.Exceptions;
using DiplomskiRad.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DiplomskiRad.DapperRepository
{
    public class DapperRepository<T> : IDapperRepository<T> where T : class
    {
        private readonly string _connectionString;
        private readonly string _table = typeof(T).Name;

        public DapperRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("TVPROGRAM") ?? throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<IEnumerable<TResult>> QueryAllAsync<TResult>(string sql, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryAsync<TResult>(sql, cancellationToken);
                return result ?? throw new EntityNotFoundException();
            }
        }

        public async Task<TResult> GetByIdAsync<TResult>(string sql, CancellationToken cancellationToken)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var result = await connection.QueryFirstOrDefaultAsync<TResult>(sql, cancellationToken);
                return result ?? throw new EntityNotFoundException();
            }
        }

        public async Task AddAsync<TRequest>(TRequest entity)
        {
            var propertyNames = typeof(TRequest).GetProperties().Select(p => p.Name).Where(p => p != "Id").ToList();
            var columns = String.Join(", ", propertyNames);
            var values = String.Join(", ", propertyNames.Select(p => $"@{p}"));
            var sql = $"INSERT INTO {_table} ({columns}) VALUES({values})";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int numOfChanges = await connection.ExecuteAsync(sql, entity);
                if (numOfChanges == 0) throw new EntityNotFoundException();
            }
        }

        public async Task UpdateAsync<TRequest>(TRequest entity)
        {
            var propertyNames = typeof(TRequest).GetProperties().Select(p => p.Name).Where(p => p != "Id").ToList();
            var columnValuePairts = String.Join(", ", propertyNames.Select(p => $"{p} = @{p}"));
            string sql = $"UPDATE {_table} SET {columnValuePairts} WHERE Id = @Id";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int numOfChanges = await connection.ExecuteAsync(sql, entity);
                if (numOfChanges == 0) throw new EntityNotFoundException();
            }
        }

        public async Task DeleteByIdAsync(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int numOfChanges = await connection.ExecuteAsync($"DELETE FROM {_table} WHERE Id = {id}");
                if (numOfChanges == 0) throw new EntityNotFoundException();
            }
        }

        public async Task DeleteListByIdsAsync(List<int> ids)
        {
            var values = String.Join(", ", ids);
            var sql = $"DELETE FROM {_table} WHERE Id IN ({values})";
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                int numOfChanges = await connection.ExecuteAsync(sql);
                if (numOfChanges == 0) throw new EntityNotFoundException();
            }
        }
    }
}
