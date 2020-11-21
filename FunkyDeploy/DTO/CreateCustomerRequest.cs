using Newtonsoft.Json;

namespace FunkyDeploy.DTO
{
    public class CreateCustomerRequest
    {
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
    }
}