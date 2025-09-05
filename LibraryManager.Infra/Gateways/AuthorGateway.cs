using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.Logging;

namespace LibraryManager.Infra.Gateways;

public class AuthorGateway : IAuthorGateway
{
    private readonly IAuthorRepository _authorRepository;
    private ILogger<AuthorGateway> _logger;
    public AuthorGateway(IAuthorRepository authorRepository, ILogger<AuthorGateway> logger)
    {
        _authorRepository = authorRepository;
        _logger = logger;
    }

    public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
    {
        try
        {
            var authors  = await _authorRepository.GetAllAuthorAsync();
            if (authors.Any())
            {
                return authors;
            }
            return new List<Author>();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task<Author> GetAuthorByIdAsync(Guid authorId)
    {
        try
        {
            var author  = await _authorRepository.GetAuthorByIdAsync(authorId);
            return author;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task<Author> CreateAuthorAsync(Author author)
    {
        try
        {
            var result = await _authorRepository.AddAuthor(author);
            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task<Task> UpdateAuthorAsync(Author author)
    {
        try
        {
            await _authorRepository.UpdateAuthor(author);
            return Task.CompletedTask;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            var exeptionMessage  = new Exception(ex.Message, ex.InnerException);
            throw exeptionMessage;
        }
    }

    public async Task DeleteAuthorAsync(Author author)
    {
        try
        {
            await _authorRepository.DeleteAuthor(author);
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