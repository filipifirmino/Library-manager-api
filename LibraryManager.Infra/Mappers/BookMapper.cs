using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Entity;

namespace LibraryManager.Infra.Mappers;

public static class BookMapper
{
    public static Book ToDomain(this BookEntity entity)
        => new Book
        {
            AuthorId = entity.AuthorId,
            Category = entity.Category,
            Id = entity.Id,
            PublicationDate = entity.PublicationDate,
            Status = entity.Status,
            Title = entity.Title,
            ISBN = entity.ISBN
        };

    public static BookEntity ToEntity(this Book domain)
        => new BookEntity
        {
            AuthorId = domain.AuthorId,
            Category = domain.Category,
            Id = domain.Id,
            PublicationDate = domain.PublicationDate,
            Status = domain.Status,
            Title = domain.Title,
            ISBN = domain.ISBN
        };
}