using LibraryManager.ApplicationCore.Domain.Entities;

namespace LibraryManager.Infra.Repositores.Abstractions;

public interface IAuthorRepository
{
    public Task<IEnumerable<Author>> GetAllAuthorAsync();
    public Task<Author?> GetAuthorByIdAsync(Guid id);
    public Task<Author?>  AddAuthor(Author author);
    public Task UpdateAuthor (Author author);
    public Task DeleteAuthor (Author author);
}