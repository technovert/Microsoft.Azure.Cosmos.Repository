using Microsoft.Azure.Cosmos.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Cosmos.Concerns
{
    /// <summary>
    /// Represents the entity with explicit defined property for partition key.
    /// </summary>
    public interface IPartitionKeyConcern : IConcern
    {
        /// <summary>
        /// The resourse partition key.
        /// </summary>
        string PartitionKey { get; set; }
    }
}
