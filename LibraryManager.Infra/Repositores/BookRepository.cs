using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Config;
using LibraryManager.Infra.Entity;
using LibraryManager.Infra.Mappers;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infra.Repositores;

public class BookRepository: IBookRepository
{
    private readonly DataContext _context;
    public BookRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        try
        {
            var result = _context.Book.AsNoTracking().ToList();

            if (result.Any())
            {
                var bookList = result.Select(x => x.ToDomain());
                return bookList;
            }
                
            return new List<Book>();
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<Book?> GetBookByIdAsync(Guid id)
    {
        try
        {
            var result = _context.Book.AsNoTracking().Single(x => x.Id == id);
            if (result != null)
                return result.ToDomain();
            return null;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public async Task<Book?> AddBook(BookEntity book)
    {
        try
        {
            var result = await _context.Book.AddAsync(book);
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

    public Task UpdateBook(BookEntity book)
    {
        try
        {
            var bookUpdated = _context.Book.Update(book);
            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }

    public Task DeleteBook(BookEntity book)
    {
        try
        {
            var bookUpdated = _context.Book.Remove(book);
            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }
}