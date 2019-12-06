using Microsoft.Azure.Cosmos.Concerns;
using Microsoft.Azure.Cosmos.Repository.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Cosmos.Core
{
    /// <summary>
    /// Common repository with a specific type.
    /// </summary>
    /// <typeparam name="T">Resource type.</typeparam>
    public abstract class BaseCosmosRepository<T> : BaseRepository, IRepository<T> where T : class, IConcern
    {
        /// <summary>
        /// Creates new repository instance.
        /// </summary>
        /// <param name="cosmosAccessor">The <see cref="CosmosClient"/> accessor.</param>
        /// <param name="databaseName">The working database name.</param>
        /// <param name="collectionName">The working container name.</param>
        protected BaseCosmosRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        {

        }

        /// <summary>Initializes a new instance of the <see cref="BaseCosmosRepository{T}"/> class.</summary>
        /// <param name="account">The account.</param>
        /// <param name="key">The key.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="collectionName">Name of the collection.</param>
        protected BaseCosmosRepository(string account, string key, string databaseName, string collectionName) : base(account, key, databaseName, collectionName)
        {

        }

        /// <summary>Gets item by id from db.</summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<T> GetByIdAsync(string id)
        {
            try
            {
                var item = await Context.Container.ReadItemAsync<T>(id, ResolvePartitionKey(id));
                return item;
            }
            catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        /// <summary>Adds item into db.</summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Primary Key of an entity must be set.</exception>
        public virtual async Task<T> AddAsync(T entity)
        {
            if (entity.Id == null)
            {
                entity.Id = GenerateId(entity);
            }

            if (string.IsNullOrWhiteSpace(entity.Id))
            {
                throw new InvalidOperationException("Primary Key of an entity must be set.");
            }

            if (entity is IPartitionKeyConcern pke)
            {
                if (pke.PartitionKey == null)
                {
                    pke.PartitionKey = CreatePartitionKey(entity);
                }
            }
            try
            {
                var r = await Context.Container.CreateItemAsync<T>(entity);
                return r;
            }
            catch (CosmosException ex)
            {
                throw ex;
            }
        }

        public virtual async Task<T> UpdateAsync(T entity) => await Context.Container.ReplaceItemAsync(entity, entity.Id);

        public virtual Task DeleteAsync(T entity) => Context.Container.DeleteItemAsync<T>(entity.Id, ResolvePartitionKey(entity.Id));

        public virtual string GenerateId(T entity) => Guid.NewGuid().ToString();

        public virtual string CreatePartitionKey(T entity) => null;

        public virtual PartitionKey ResolvePartitionKey(string entityId) => PartitionKey.None;

        /// <summary>Query items from db.</summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public virtual async Task<IList<T>> GetItemsByQuery(string query)
        {
            try
            {
                FeedIterator<T> queryResult = Context.Container.GetItemQueryIterator<T>(new QueryDefinition(query));
                List<T> results = new List<T>();
                while (queryResult.HasMoreResults)
                {
                    FeedResponse<T> response = await queryResult.ReadNextAsync();

                    results.AddRange(response);
                }

                return results;
            }
            catch (CosmosException ce)
            {
                throw ce;
            }
        }
    }
}

