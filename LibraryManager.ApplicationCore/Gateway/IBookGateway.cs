using LibraryManager.ApplicationCore.Domain.Entities;

namespace LibraryManager.ApplicationCore.Gateway;

public interface IBookGateway
{
    public Task<IEnumerable<Book>> GetAllBooksAsync();
    public Task<Book> GetBookByIdAsync(Guid bookId);
    public Task<Book> CreateBookAsync(Book book);
    public Task<Task> UpdateBookAsync(Book book);
    public Task DeleteBookAsync(Book book);
}