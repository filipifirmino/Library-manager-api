using LibraryManager.ApplicationCore.Domain.Entities;

namespace LibraryManager.Infra.Repositores.Abstractions;

public interface ICustomerRepository
{
    public Task<IEnumerable<Customer>> GetAllCustomerAsync();
    public Task<Customer> GetByIdAsync(Guid id);
    public Task<Customer> AddAsync(Customer customer);
    public Task<Customer> UpdateAsync(Customer customer);
    public Task<bool> DeleteAsync(Customer customer);
}