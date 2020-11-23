using System;
using System.Threading.Tasks;
using FunkyDeploy.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace FunkyDeploy.Functions
{
    public class GetCustomerFunction
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<GetCustomerFunction> _logger;

        public GetCustomerFunction(ICustomerService customerService, ILogger<GetCustomerFunction> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [FunctionName(nameof(GetCustomerFunction))]
        public async Task<IActionResult> GetCustomerAsync([HttpTrigger(AuthorizationLevel.Function, "get", Route = "customers/{customerId}")]
            HttpRequest request,
            string customerId)
        {
            var operation = await _customerService.GetCustomerAsync(customerId);
            if (!operation.Status)
            {
                _logger.LogError("Error occured {functionName}", nameof(GetCustomerFunction));
                return new BadRequestObjectResult(operation.ErrorMessage);
            }

            var responseModel = new
            {
                data = operation.Data,
                message = Environment.GetEnvironmentVariable("CustomerApiKey")
            };

            return new OkObjectResult(responseModel);
        }
    }
}