using System;
using System.Threading.Tasks;
using FunkyDeploy.Services.Abstractions;
using FunkyDeploy.Services.Core;
using FunkyDeploy.Services.Models;
using Microsoft.Extensions.Logging;

namespace FunkyDeploy.Services.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(ILogger<CustomerRepository> logger)
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