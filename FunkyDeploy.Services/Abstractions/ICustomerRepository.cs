using System.Threading.Tasks;
using FunkyDeploy.Services.Core;
using FunkyDeploy.Services.Models;

namespace FunkyDeploy.Services.Abstractions
{
    public interface ICustomerRepository
    {
        Task<Result<Customer>> CreateAsync(Customer customer);
        Task<Result<Customer>> GetCustomerAsync(string customerId);
    }
}