using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Config;
using LibraryManager.Infra.Mappers;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infra.Repositores;

public class CustomerRepository:ICustomerRepository
{
    private readonly DataContext _context;
    public CustomerRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Customer>> GetAllCustomerAsync()
    {
        try
        {
            var result = _context.Customer.AsNoTracking().ToList();

            if (result.Any())
            {
                var customers = result.Select(x => x.ToDomain());
                return customers;
            }
                
            return new List<Customer>();
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<Customer> GetByIdAsync(Guid id)
    {
        try
        {
            var result = _context.Customer.AsNoTracking().Single(x => x.Id == id);
            if (result != null)
                return result.ToDomain();
            return null;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<Customer> AddAsync(Customer customer)
    {
        try
        {
            var result = await _context.Customer.AddAsync(customer.ToEntity());
            _context.SaveChanges();
            if (result != null)
                return result.Entity.ToDomain();
            return null;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<Customer> UpdateAsync(Customer customer)
    {
        try
        {
            var bookUpdated = _context.Customer.Update(customer.ToEntity());
            _context.SaveChanges();
            return bookUpdated.Entity.ToDomain();
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<bool> DeleteAsync(Customer customer)
    {
        try
        {
            var bookUpdated = _context.Customer.Remove(customer.ToEntity());
            _context.SaveChanges();
            //Todo: Ajustar para validar a deleção
            return true;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }
}