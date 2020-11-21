using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FunkyDeploy.DTO;
using FunkyDeploy.Services;
using FunkyDeploy.Services.Abstractions;
using FunkyDeploy.Services.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FunkyDeploy.Functions
{
    public class CreateCustomerFunction
    {
        private readonly IDtoService _dtoService;
        private readonly ICustomerService _customerService;
        private readonly ILogger<CreateCustomerFunction> _logger;

        public CreateCustomerFunction(IDtoService dtoService, ICustomerService customerService, ILogger<CreateCustomerFunction> logger)
        {
            _dtoService = dtoService;
            _customerService = customerService;
            _logger = logger;
        }

        [FunctionName(nameof(CreateCustomerFunction))]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "customers")] HttpRequest request)
        {

            var createCustomerRequest = await _dtoService.GetModelAsync<CreateCustomerRequest>(request);
            var operation = await _customerService.CreateAsync(new Customer
            {
                Id = Guid.NewGuid().ToString("N"),
                Name = createCustomerRequest.CustomerName,
                Address = createCustomerRequest.CustomerAddress
            });

            if (operation.Status)
            {
                return new StatusCodeResult((int)(HttpStatusCode.Created));
            }

            return new BadRequestObjectResult(operation.ErrorMessage);
        }
    }
}
