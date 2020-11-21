using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FunkyDeploy.Services.Core;
using FunkyDeploy.Services.Models;

namespace FunkyDeploy.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<Result> CreateAsync(Customer customer);
        Task<Result<Customer>> GetCustomerAsync(string customerId);
    }
}
