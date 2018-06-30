using Newtonsoft.Json;

namespace DemoJSON.Model
{
    public class UpdateOperation
    {
        public static readonly string OPERATION_NAME_ADD = "add";

        [JsonProperty("op")]
        private string Operation { get; set; }
        [JsonProperty("path")]
        private string Path { get; set; }
        [JsonProperty("value")]
        private string Value { get; set; }

        public UpdateOperation(string operation, string keyOfFieldToUpdate, string valueOfFieldToUpdate)
        {
            Operation = operation;
            Path = keyOfFieldToUpdate;
            Value = valueOfFieldToUpdate;
        }
    }
}
