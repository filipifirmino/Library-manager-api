using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.Infra.Mappers;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.Logging;

namespace LibraryManager.Infra.Gateways;

public class BookGateway: IBookGateway
{
    private readonly IBookRepository _bookRepository;
    private ILogger<BookGateway> _logger;
   
    public BookGateway(IBookRepository bookRepository,
        ILogger<BookGateway> logger)
    {
        _bookRepository = bookRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        try
        {
            var books  = await _bookRepository.GetAllBooksAsync();
            if (books.Any())
            {
                return books;
            }
            return new List<Book>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task<Book> GetBookByIdAsync(Guid bookId)
    {
        try
        {
            var book  = await _bookRepository.GetBookByIdAsync(bookId);
            return book;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }
    
    public async Task<Book> CreateBookAsync(Book book)
    {
        try
        {
           var result = await _bookRepository.AddBook(book.ToEntity());
           return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task<Task> UpdateBookAsync(Book book)
    {
        try
        {
            await _bookRepository.UpdateBook(book.ToEntity());
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task DeleteBookAsync(Book book)
    {
        try
        {
            await _bookRepository.DeleteBook(book.ToEntity());
            return ;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }
}