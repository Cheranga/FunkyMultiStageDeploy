using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FunkyDeploy.Services.Abstractions;
using FunkyDeploy.Services.Core;
using FunkyDeploy.Services.Models;
using Microsoft.Extensions.Logging;

namespace FunkyDeploy.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ILogger<CustomerService> logger)
        {
            _logger = logger;
        }

        public Task<Result> CreateAsync(Customer customer)
        {
            throw new NotImplementedException();
        }

        public Task<Result<Customer>> GetCustomerAsync(string customerId)
        {
            throw new NotImplementedException();
        }
    }
}
