using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Entity;

namespace LibraryManager.Infra.Repositores.Abstractions;

public interface IBookRepository
{
    public Task<IEnumerable<Book>> GetAllBooksAsync();
    public Task<Book?> GetBookByIdAsync(Guid id);
    public Task<Book?> AddBook (BookEntity book);
    public Task UpdateBook (BookEntity book);
    public Task DeleteBook (BookEntity book);
}