using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.Logging;

namespace LibraryManager.Infra.Gateways;

public class CustomerGateway : ICustomerGateway
{
    private readonly ICustomerRepository _customerRepository;
    private ILogger<CustomerGateway> _logger;
    public CustomerGateway(ICustomerRepository customerRepository, ILogger<CustomerGateway> logger)
    {
        _customerRepository = customerRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        try
        {
            var customers  = await _customerRepository.GetAllCustomerAsync();
            if (customers.Any())
            {
                return customers;
            }
            return new List<Customer>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
    {
        try
        {
            var customer  = await _customerRepository.GetByIdAsync(customerId);
            return customer;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task<Customer> CreateCustomerAsync(Customer customer)
    {
        try
        {
            var result = await _customerRepository.AddAsync(customer);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task<Task> UpdateCustomerAsync(Customer customer)
    {
        try
        {
            await _customerRepository.UpdateAsync(customer);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task DeleteCustomerAsync(Customer customer)
    {
        try
        {
            await _customerRepository.DeleteAsync(customer);
            return ;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }
}