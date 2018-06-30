using Newtonsoft.Json;

namespace DemoJSON.Model
{
    public class Headers
    {
        [JsonProperty("Content-Type")]
        public string contentType;
        public Headers(string contentType)
        {
            this.contentType = contentType;
        }
    }
}
