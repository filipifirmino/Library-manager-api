using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.ApplicationCore.UseCases.Abstractions;

namespace LibraryManager.ApplicationCore.UseCases;

public class ProcessAuthor : IProcessAuthor
{
    private readonly IAuthorGateway _gateway;
    public ProcessAuthor(IAuthorGateway gateway)
    {
        _gateway = gateway;
    }
    public async Task ExecuteAsync(Author author)
    {
        var saveResult = await _gateway.CreateAuthorAsync(author);
        if (saveResult == null)
        {
            throw new NullReferenceException();
        }
        
    }
}