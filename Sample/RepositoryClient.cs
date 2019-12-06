using Microsoft.Azure.Cosmos.Concerns;
using Microsoft.Azure.Cosmos.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sample
{
   public class RepositoryClient
    {
        public async Task Initialize()
        {
            //string connectionString = "AccountEndpoint=https://comsmosdb.documents.azure.com:443/;AccountKey=WtgxLQWOdaZn9tj80y46OSrJENFtYywxzZuzUZzHqCgXbJRiWLpXbABLbjVlkKSg8MmbPkyNo92BHLY43hDBUQ==;";
            string connectionString = "AccountEndpoint=https://tech.documents.azure.com:443/;AccountKey=jhD2gAMawoWCmWm8LoDfqwpik3B1J3Bj1HbL1slqzdrlAsNFfMqkUy7B4GzistLhtAqtA5RxCdhj104y3JMh3Q==;";
            string account = "https://tech.documents.azure.com:443/";
            string key = "jhD2gAMawoWCmWm8LoDfqwpik3B1J3Bj1HbL1slqzdrlAsNFfMqkUy7B4GzistLhtAqtA5RxCdhj104y3JMh3Q==";
            //CosmosRepository<Employee> employeeRepository = new CosmosRepository<Employee>(connectionString, "ToDoList", "Items");
            CosmosRepository<Item> repo = new CosmosRepository<Item>(account, key, "ToDoList", "Items");

            var items = await repo.GetItemsByQuery("SELECT * FROM c");
        }
    }


    public class Item : IPartitionKeyConcern
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }
        public string PartitionKey { get; set; }
    }


    public class Employee : IPartitionKeyConcern
    {
        public string PartitionKey { get; set; }
        public string Id { get; set; }
    }
}
