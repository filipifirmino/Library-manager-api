using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Config;
using LibraryManager.Infra.Mappers;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infra.Repositores;

public class AuthorRepository : IAuthorRepository
{
    private readonly DataContext _context;
    public AuthorRepository(DataContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Author>> GetAllAuthorAsync()
    {
        try
        {
            var result = await _context.Author.ToListAsync();

            if (result.Any())
            {
                var authorList = result.Select(x => x.ToDomain());
                return authorList;
            }
                
            return new List<Author>();
        }
        catch (Exception e)
        {
            var exepitionMessage = new Exception(e.Message, e.InnerException);
            throw exepitionMessage;
        }
    }

    public async Task<Author?> GetAuthorByIdAsync(Guid id)
    {
        try
        {
           var result = await _context.Author.FindAsync(id);
            if (result != null)
                return result.ToDomain();
            return null;
        }
        catch (Exception e)
        {
            var exepitionMessage = new Exception(e.Message, e.InnerException);
            throw exepitionMessage;
        }
    }

    public async Task<Author?> AddAuthor(Author author)
    {
        try
        {
            _ = await _context.Author.AddAsync(author.ToEntity());
            var saveResult = _context.SaveChanges();
            if (saveResult != 0)
                return author;
            return null;
        }
        catch (Exception e)
        {
            var exeptionMessage = new Exception(e.Message, e.InnerException);
            throw exeptionMessage;
        }
    }

    public Task UpdateAuthor(Author author)
    {
        try
        {
            var bookUpdated = _context.Author.Update(author.ToEntity());
            _context.SaveChanges();
            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            var exepitionMessage = new Exception(e.Message, e.InnerException);
            throw exepitionMessage;
        }
    }

    public Task DeleteAuthor(Author author)
    {
        try
        {
            var authorRemoved = _context.Author.Remove(author.ToEntity());
            _context.SaveChanges();
            
            return Task.CompletedTask;
        }
        catch (Exception e)
        {
            var exceptionMessage = new Exception(e.Message, e.InnerException);
            throw exceptionMessage;
        }
    }
}