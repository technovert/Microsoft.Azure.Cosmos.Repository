using Microsoft.Azure.Cosmos.Concerns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Sample.Models
{
    public class Employee : IPartitionKeyConcern
    {
        public string PartitionKey { get; set; }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Department { get; set; }
    }
}
