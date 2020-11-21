using Newtonsoft.Json;

namespace FunkyDeploy.DTO
{
    public class CreateCustomerRequest
    {
        [JsonIgnore]
        public string CustomerId { get; set; }

        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}