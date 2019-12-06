using System;

namespace Sample
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            RepositoryClient c = new RepositoryClient();
            await c.Initialize();
        }
    }
}
