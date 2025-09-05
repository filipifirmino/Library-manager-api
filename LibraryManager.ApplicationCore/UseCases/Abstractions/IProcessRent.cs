using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Domain.ValueObject;

namespace LibraryManager.ApplicationCore.UseCases.Abstractions;

public interface IProcessRent
{
    public Task<Result<Rent>> ExecuteAsync(Rent rent);
}