using LibraryManager.ApplicationCore.Domain.Entities;

namespace LibraryManager.ApplicationCore.Gateway;

public interface ICustomerGateway
{
    public Task<IEnumerable<Customer>> GetAllCustomersAsync();
    public Task<Customer> GetCustomerByIdAsync(Guid customerId);
    public Task<Customer> CreateCustomerAsync(Customer customer);
    public Task<Task> UpdateCustomerAsync(Customer customer);
    public Task DeleteCustomerAsync(Customer customer);
}