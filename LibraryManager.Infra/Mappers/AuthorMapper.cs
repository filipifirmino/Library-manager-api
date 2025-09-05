using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Entity;

namespace LibraryManager.Infra.Mappers;

public static class AuthorMapper
{
    public static Author ToDomain(this AuthorEntity entity)
        => new Author
        {
            Name = entity.Name,
            Biografi = entity.Biografi,
            Birth = entity.Birth,
            Id = entity.Id,
            
        };

    public static AuthorEntity ToEntity(this Author domain)
        => new AuthorEntity
        {
            Name = domain.Name,
            Biografi = domain.Biografi,
            Birth = domain.Birth,
            Id = domain.Id
        };
}