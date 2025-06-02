using System.Linq.Expressions;
using MongoDB.Driver;
using MultiShop.Catalog.Context;
using MultiShop.Catalog.Entities.Common;

namespace MultiShop.Catalog.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly IMongoCollection<T> _collection;

        public Repository(CatalogContext context)
        {
            // Entity tipine göre doğru collection'ı al
            if (typeof(T).Name == "Category")
                _collection = (IMongoCollection<T>)context.Categories;
            else if (typeof(T).Name == "Product")
                _collection = (IMongoCollection<T>)context.Products;
            else if (typeof(T).Name == "ProductDetail")
                _collection = (IMongoCollection<T>)context.ProductDetails;
            else if (typeof(T).Name == "ProductImage")
                _collection = (IMongoCollection<T>)context.ProductImages;
            else
                throw new ArgumentException($"Unknown entity type: {typeof(T).Name}");
        }

        public async Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter)
        {
            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<T> FindOneAsync(FilterDefinition<T> filter)
        {
            return await _collection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> FindAsync(FilterDefinition<T> filter, FindOptions<T> options)
        {
            return await _collection.FindAsync(filter, options).Result.ToListAsync();
        }

        public async Task<IEnumerable<TResult>> Aggregate<TResult>(PipelineDefinition<T, TResult> pipeline)
        {
            return await _collection.Aggregate(pipeline).ToListAsync();
        }

        public async Task<T> InsertOneAsync(T document)
        {
            document.CreatedDate = DateTime.Now;
            await _collection.InsertOneAsync(document);
            return document;
        }

        public async Task InsertManyAsync(IEnumerable<T> documents)
        {
            foreach (var doc in documents)
            {
                doc.CreatedDate = DateTime.Now;
            }
            await _collection.InsertManyAsync(documents);
        }

        public async Task<T> FindOneAndUpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            update = update.Set(x => x.UpdatedDate, DateTime.Now);
            return await _collection.FindOneAndUpdateAsync(filter, update);
        }

        public async Task<T> FindOneAndReplaceAsync(FilterDefinition<T> filter, T replacement)
        {
            replacement.UpdatedDate = DateTime.Now;
            return await _collection.FindOneAndReplaceAsync(filter, replacement);
        }

        public async Task<T> FindOneAndDeleteAsync(FilterDefinition<T> filter)
        {
            return await _collection.FindOneAndDeleteAsync(filter);
        }

        public async Task<bool> UpdateOneAsync(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            update = update.Set(x => x.UpdatedDate, DateTime.Now);
            var result = await _collection.UpdateOneAsync(filter, update);
            return result.ModifiedCount > 0;
        }

        public async Task<bool> DeleteOneAsync(FilterDefinition<T> filter)
        {
            var result = await _collection.DeleteOneAsync(filter);
            return result.DeletedCount > 0;
        }
    }
}