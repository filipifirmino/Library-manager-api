using LibraryManager.ApplicationCore.Domain.Entities;

namespace LibraryManager.ApplicationCore.Gateway;

public interface IAuthorGateway
{
    public Task<IEnumerable<Author>> GetAllAuthorsAsync();
    public Task<Author> GetAuthorByIdAsync(Guid authorId);
    public Task<Author> CreateAuthorAsync(Author author);
    public Task<Task> UpdateAuthorAsync(Author author);
    public Task DeleteAuthorAsync(Author author);
}