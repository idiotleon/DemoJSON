using Newtonsoft.Json;
using System.Collections.Generic;

namespace DemoJSON.Model
{
    /**
     * This is class is for one single item/operation in the batch operations
     */
    public class BatchOperationsItem
    {
        [JsonProperty("method")]
        public string Method { get; set; }
        [JsonProperty("uri")]
        public string URI { get; set; }
        [JsonProperty("headers")]
        public Headers Headers { get; set; }
        [JsonProperty("body")]
        public List<UpdateOperation> Body;

        public BatchOperationsItem(string method, string uri, Headers headers, List<UpdateOperation> body)
        {
            this.Method = method;
            this.URI = uri;
            this.Headers = headers;
            this.Body = body;
        }
    }
}
