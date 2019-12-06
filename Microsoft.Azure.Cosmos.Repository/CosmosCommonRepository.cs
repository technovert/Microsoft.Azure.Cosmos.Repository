using Microsoft.Azure.Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Cosmos.Repository
{
    /// <summary></summary>
    /// <seealso cref="Microsoft.Azure.Cosmos.Core.BaseCosmosCommonRepository" />
    /// <seealso cref="Microsoft.Azure.Cosmos.Core.ICosmosCommonRepository" />
    public class CosmosCommonRepository : BaseCosmosCommonRepository, ICosmosCommonRepository
    {
        /// <summary>Initializes a new instance of the <see cref="CosmosCommonRepository"/> class.</summary>
        /// <param name="connectionString">The <see cref="connectionString"/> connection string.</param>
        /// <param name="databaseName">The working database name.</param>
        /// <param name="collectionName">The working container name.</param>
        public CosmosCommonRepository(string connectionString, string databaseName, string collectionName) : base(connectionString, databaseName, collectionName)
        {

        }

        /// <summary>Initializes a new instance of the <see cref="CosmosCommonRepository"/> class.</summary>
        /// <param name="account">The account.</param>
        /// <param name="key">The key.</param>
        /// <param name="databaseName">Name of the database.</param>
        /// <param name="collectionName">Name of the collection.</param>
        public CosmosCommonRepository(string account, string key, string databaseName, string collectionName) : base(account, key, databaseName, collectionName)
        {

        }
    }
}
