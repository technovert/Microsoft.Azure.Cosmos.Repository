using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Cosmos.Core
{
    /// <summary>
    /// Provides a base for the CosmosDb resource.
    /// </summary>
    public interface IConcern
    {
        /// <summary>
        /// The resource id.
        /// </summary>
        string Id { get; set; }
    }
}
