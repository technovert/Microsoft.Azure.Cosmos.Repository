using Microsoft.Azure.Cosmos.Repository;
using Sample.Models;
using System;
using System.Configuration;

namespace Sample
{
    public class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            //Connection for the cosomos db
            string connectionString = ConfigurationManager.ConnectionStrings["CosmosDb"].ConnectionString;

            //Using Account and key for the cosmos db
            string accountURL = ConfigurationManager.AppSettings["CosmosDBUri"];
            string accountKey = ConfigurationManager.AppSettings["CosmosDbKey"];


            string dbName = ConfigurationManager.AppSettings["CosmosDbName"];
            string collName = ConfigurationManager.AppSettings["CosmosCollectionName"];

            //For this sample we are using Item Model. You can replace it with yours
            CosmosRepository<Employee> client = new CosmosRepository<Employee>(connectionString, dbName, collName);

            //BaseCosmosCommonRepository client = new BaseCosmosCommonRepository(accountURL, accountKey, dbName, collName); // we can also use connection string, just like the above         

            //Creating New Item 
            Employee employee = new Employee
            {
                Name = "John",
                Department = "IT"                
            };

            //Adding item to Cosmosdb
            await client.AddAsync(employee);

            //Getting Item by ID
            await client.GetByIdAsync("XXX-XXXX-XXX");// you need to pass the Record Id, for Getting complete item

            //Updating Item
            await client.UpdateAsync(employee);

            //Deleting Item from the collection By ID
            await client.DeleteAsyncById("XXX-XXXX-XXX");// you need to pass the Record Id, to deelete the complete record form the collection.

            //Deleting Item from the collection By sending record
            await client.DeleteAsync(employee);
        }
    }
}
