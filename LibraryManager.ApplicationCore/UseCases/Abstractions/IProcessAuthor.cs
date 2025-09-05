using LibraryManager.ApplicationCore.Domain.Entities;

namespace LibraryManager.ApplicationCore.UseCases.Abstractions;

public interface IProcessAuthor
{
    public Task ExecuteAsync(Author author);
}