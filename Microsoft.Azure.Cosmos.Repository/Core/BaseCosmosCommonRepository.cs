using Microsoft.Azure.Cosmos.Concerns;
using Microsoft.Azure.Cosmos.Repository.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Cosmos.Core
{
    /// <summary>
    /// Common repository without specific type.
    /// </summary>
    public abstract class BaseCosmosCommonRepository : BaseRepository, ICosmosCommonRepository
    {
        
        /// <summary>
        /// Creates new repository instance.
        /// </summary>
        /// <param name="connectionString">The <see cref="connectionString"/> connection string.</param>
        /// <param name="databaseName">The working database name.</param>
        /// <param name="collectionName">The working container name.</param>
        protected BaseCosmosCommonRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        { }

        /// <summary>Initializes a new instance of the <see cref="BaseCosmosCommonRepository"/> class.</summary>
        /// <param name="account">The account.</param>
        /// <param name="key">The key.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="collectionName">Name of the collection.</param>
        protected BaseCosmosCommonRepository(string account, string key, string databaseName, string collectionName) : base(account, key, databaseName, collectionName)
        { }

        public virtual async Task<T> GetByIdAsync<T>(string id) where T : class, IConcern
        {
            try
            {
                var item = await Context.Container.ReadItemAsync<T>(id, ResolvePartitionKey(id));
                return item;
            }
            catch (CosmosException ex) when (ex.StatusCode == System.Net.HttpStatusCode.NotFound)
            {
                return null;
            }
        }

        public virtual async Task<T> AddAsync<T>(T entity) where T : class, IConcern
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
            var r = await Context.Container.CreateItemAsync(entity);
            return r;
        }

        public virtual async Task<T> UpdateAsync<T>(T entity) where T : class, IConcern => await Context.Container.ReplaceItemAsync(entity, entity.Id);

        public virtual Task DeleteAsync<T>(T entity) where T : class, IConcern => Context.Container.DeleteItemAsync<T>(entity.Id, ResolvePartitionKey(entity.Id));

        public virtual string GenerateId<T>(T entity) where T : class, IConcern => Guid.NewGuid().ToString();

        public virtual string CreatePartitionKey<T>(T entity) where T : class, IConcern => null;

        public virtual PartitionKey ResolvePartitionKey(string entityId) => PartitionKey.None;

        public virtual async Task<IList<T>> GetItemsByQuery<T>(string query) where T : class, IConcern
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
