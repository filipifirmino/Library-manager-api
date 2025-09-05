using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Config;
using LibraryManager.Infra.Mappers;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infra.Repositores;

public class RentRepository : IRentRepository
{
    private readonly DataContext _context;
    public RentRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Rent>> GetAllRentsAsync()
    {
        try
        {
            var result = _context.Rent.AsNoTracking().ToList();
            return result.Count != 0 ? result.Select(x => x.ToDomain()) : new List<Rent>();
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<Rent> GetRentsByUserIdAsync(Guid customerId)
    {
        try
        {
            var result =  _context.Rent.AsNoTracking()
                .FirstOrDefault(x => x.CustomerId == customerId);
            return result != null ? result.ToDomain() : null;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<IEnumerable<Rent>> GetAllRentsByDateAsync(DateTime date)
    {
        try
        {
            var result = _context.Rent.AsNoTracking().Where(x => x.RentalDate == date).ToList();
            if (result.Any())
                return result.Select(x => x.ToDomain());
            return new List<Rent>();
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage; 
        }
    }

    public async Task<Rent> CreateRentAsync(Rent rent)
    {
        try
        {
            var result = await _context.Rent.AddAsync(rent.ToEntity());
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

    public Task UpdateRentAsync(Rent rent)
    {
        try
        {
            var rentUpdate = _context.Rent.Update(rent.ToEntity());
            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<Rent> GetRentById(long rentId)
    {
        try
        {
            var rent = _context.Rent.AsNoTracking().FirstOrDefault( x=> x.RentId == rentId);
            return rent.ToDomain();
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }
}