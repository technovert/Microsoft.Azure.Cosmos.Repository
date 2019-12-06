using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Cosmos.Core
{
    /// <summary>
    /// Represents the repository context.
    /// </summary>
    public class CosmosRepositoryContext
    {
        /// <summary>
        /// Creates new context instance.
        /// </summary>
        /// <param name="cosmosAccessor">The <see cref="CosmosClient"/> accessor.</param>
        /// <param name="databaseName">The working database name.</param>
        /// <param name="collectionName">The working container name.</param>
        public CosmosRepositoryContext(CosmosClient cosmosClient, string databaseName, string collectionName)
        {
            Client = cosmosClient;
            Container = Client.GetContainer(databaseName, collectionName);
        }
        /// <summary>
        /// The <see cref="CosmosClient"/> client.
        /// </summary>
        public CosmosClient Client { get; }
        /// <summary>
        /// The working container.
        /// </summary>
        public Container Container { get; }
    }
}
