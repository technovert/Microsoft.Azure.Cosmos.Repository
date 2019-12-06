using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.Cosmos.Core;
using Microsoft.Azure.Cosmos.Concerns;
using Microsoft.Azure.Cosmos.Repository;
namespace Sample
{
    public class CommonRepositoryClient
    {
        public CommonRepositoryClient()
        {
            string connectionString = "AccountEndpoint=https://comsmosdb.documents.azure.com:443/;AccountKey=WtgxLQWOdaZn9tj80y46OSrJENFtYywxzZuzUZzHqCgXbJRiWLpXbABLbjVlkKSg8MmbPkyNo92BHLY43hDBUQ==;";
            ICosmosCommonRepository commonRepository = new CosmosCommonRepository(connectionString, "devdb", "appstore");
        }
    }
    public class City : IPartitionKeyConcern
    {
        public string PartitionKey { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
    }
    public class Country : IPartitionKeyConcern
    {
        public string PartitionKey { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }

    }
}
