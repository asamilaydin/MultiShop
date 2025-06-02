using System.Linq.Expressions;
using MongoDB.Driver;
using MultiShop.Catalog.Entities.Common;

namespace MultiShop.Catalog.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        // MongoDB Specific Operations
        Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter);
        Task<T> FindOneAsync(FilterDefinition<T> filter);
        Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter, FindOptions<T> options);
        Task<IEnumerable<TResult>> Aggregate<TResult>(PipelineDefinition<T, TResult> pipeline);
        
        // Additional MongoDB Operations
        Task<T> InsertOneAsync(T document);
        Task InsertManyAsync(IEnumerable<T> documents);
        Task<T> FindOneAndUpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update);
        Task<T> FindOneAndReplaceAsync(FilterDefinition<T> filter, T replacement);
        Task<T> FindOneAndDeleteAsync(FilterDefinition<T> filter);
        Task<bool> UpdateOneAsync(FilterDefinition<T> filter, UpdateDefinition<T> update);
        Task<bool> DeleteOneAsync(FilterDefinition<T> filter);
        
    }
} 