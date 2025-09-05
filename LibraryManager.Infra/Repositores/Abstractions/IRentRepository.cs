using LibraryManager.ApplicationCore.Domain.Entities;

namespace LibraryManager.Infra.Repositores.Abstractions;

public interface IRentRepository
{
   public Task<IEnumerable<Rent>> GetAllRentsAsync();
   public Task<Rent> GetRentsByUserIdAsync(Guid customerId);
   public Task<IEnumerable<Rent>> GetAllRentsByDateAsync(DateTime date);
   public Task<Rent> CreateRentAsync(Rent rent);
   public Task UpdateRentAsync(Rent rent);
   public Task<Rent> GetRentById (long rentId);
}