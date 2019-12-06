using Microsoft.Azure.Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Cosmos.Repository
{
    /// <summary></summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="Microsoft.Azure.Cosmos.Core.BaseCosmosRepository{T}" />
    /// <seealso cref="Microsoft.Azure.Cosmos.Core.IRepository{T}" />
    public class CosmosRepository<T> : BaseCosmosRepository<T>, IRepository<T> where T : class, IConcern
    {
        /// <summary>Initializes a new instance of the <see cref="CosmosRepository{T}"/> class.</summary>
        /// <param name="connectionString"></param>
        /// <param name="databaseName">The working database name.</param>
        /// <param name="collectionName">The working container name.</param>
        public CosmosRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        {

        }

        /// <summary>Initializes a new instance of the <see cref="CosmosRepository{T}"/> class.</summary>
        /// <param name="account">The account.</param>
        /// <param name="key">The key.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="collectionName">Name of the collection.</param>
        public CosmosRepository(string account, string key, string databaseName, string collectionName) : base(account, key, databaseName, collectionName)
        {

        }
    }
}
