using Microsoft.Azure.Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Cosmos.Repository.Core
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.Azure.Cosmos.Core.IRepository" />
    public abstract class BaseRepository:IRepository
    {
        /// <summary>Gets or sets the context.</summary>
        /// <value>The context.</value>
        public CosmosRepositoryContext Context { get; set; }

        /// <summary>Initializes a new instance of the <see cref="BaseRepository"/> class.</summary>
        /// <param name="connectionString">The connection string.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="collectionName">Name of the collection.</param>
        public BaseRepository(string connectionString, string databaseName, string collectionName)
        {

            this.Context = new CosmosRepositoryContext(new CosmosClient(connectionString), databaseName, collectionName);
        }

        /// <summary>Initializes a new instance of the <see cref="BaseRepository"/> class.</summary>
        /// <param name="account">The account.</param>
        /// <param name="key">The key.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="collectionName">Name of the collection.</param>
        public BaseRepository(string account, string key, string databaseName, string collectionName)
        {
            this.Context = new CosmosRepositoryContext(new CosmosClient(account, key), databaseName, collectionName);
        }
    }
}
