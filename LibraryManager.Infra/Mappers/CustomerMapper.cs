using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Entity;

namespace LibraryManager.Infra.Mappers;

public static class CustomerMapper
{
    public static Customer ToDomain(this CustomerEntity entity)
        => new Customer
        {
            Name = entity.Name,
            Address = entity.Address,
            Phone = entity.Phone,
            Score = entity.Score,
            Id = entity.Id
        };

    public static CustomerEntity ToEntity(this Customer domain)
        => new CustomerEntity
        {
            Name = domain.Name,
            Address = domain.Address,
            Phone = domain.Phone,
            Score = domain.Score,
            Id = domain.Id
        };
}