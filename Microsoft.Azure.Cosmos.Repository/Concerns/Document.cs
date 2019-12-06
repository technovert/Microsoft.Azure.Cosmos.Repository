using Microsoft.Azure.Cosmos.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Cosmos.Concerns
{
    /// <summary>
    /// Represents the basic CosmosDb object.
    /// </summary>
    public class Document : IConcern
    {
        /// <summary>
        /// The resourse id.
        /// </summary>
        [JsonProperty("id")]
        public virtual string Id { get; set; }
        /// <summary>
        /// The type of the current object. Can be used as a filter.
        /// </summary>
        [JsonProperty("documentType")]
        public virtual string DocumentType => GetType().Name;
    }
}
