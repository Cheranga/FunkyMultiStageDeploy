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
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(ICustomerRepository customerRepository, ILogger<CustomerService> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task<Result<Customer>> CreateAsync(Customer customer)
        {
            var operation = await _customerRepository.CreateAsync(customer);
            return operation;
        }

        public async Task<Result<Customer>> GetCustomerAsync(string customerId)
        {
            var operation = await _customerRepository.GetCustomerAsync(customerId);
            return operation;
        }
    }
}
