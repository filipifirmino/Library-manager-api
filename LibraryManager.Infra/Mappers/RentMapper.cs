using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Entity;

namespace LibraryManager.Infra.Mappers;

public static class RentMapper
{
    public static Rent ToDomain(this RentEntity entity)
        => new Rent
        {
            RentalDate = entity.RentalDate,
            ReturnDate = entity.ReturnDate,
            CustomerId = entity.CustomerId,
            BookId = entity.BookId,
            Id = entity.RentId
        };
    
    
    public static RentEntity ToEntity(this Rent domain)
        => new RentEntity
        {
            RentalDate = domain.RentalDate,
            ReturnDate = domain.ReturnDate,
            CustomerId = domain.CustomerId,
            BookId = domain.BookId,
            RentId = domain.Id
        };
}