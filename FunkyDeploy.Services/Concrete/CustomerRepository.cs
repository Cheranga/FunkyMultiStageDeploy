using System;
using System.Collections.Concurrent;
using System.Linq;
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

        private ConcurrentBag<Customer> _customers;

        public CustomerRepository(ILogger<CustomerRepository> logger)
        {
            _logger = logger;

            _customers = new ConcurrentBag<Customer>();
        }

        public Task<Result<Customer>> CreateAsync(Customer customer)
        {
            _customers.Add(customer);
            return Task.FromResult(Result<Customer>.Success(customer));
        }

        public Task<Result<Customer>> GetCustomerAsync(string customerId)
        {
            var customer = _customers.FirstOrDefault(x => string.Equals(x.Id, customerId, StringComparison.OrdinalIgnoreCase));
            if (customer == null)
            {
                return Task.FromResult(Result<Customer>.Failure("Customer not found."));
            }

            return Task.FromResult(Result<Customer>.Success(customer));
        }
    }
}