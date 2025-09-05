using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Domain.ValueObject;
using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.ApplicationCore.UseCases.Abstractions;
using Microsoft.Extensions.Logging;

namespace LibraryManager.ApplicationCore.UseCases;

public class ProcessRent : IProcessRent
{
    private readonly ILogger<ProcessRent> _logger;
    private readonly IRentGateway _gateway;

    public ProcessRent(ILogger<ProcessRent> logger, IRentGateway gateway)
    {
        _logger = logger;
        _gateway = gateway;
    }
    
    public async Task<Result<Rent>> ExecuteAsync(Rent rent)
    {
        var isRent = await _gateway.GetRentsByUserIdAsync(rent.CustomerId);
        if (isRent != null && rent.ReturnDate != null)
            return ProcessReturnBook(rent, isRent);
        
        var rentBook = await _gateway.CreateRentAsync(rent);
        if (rentBook != null)
            return Result<Rent>.Fail("Failed to create rent");;
        return Result<Rent>.Success(rent);
    }

    //TODO: A ideia aqui a principio é receber a devolução de uma locação de um livro
    // a ideia é identificar a devolução pela data de devolução preenchida uma vez preenchida 
    // devemos verificar o prazo de entrega, esse prazo de entrega pode ser tornar um enriquecimento 
    // de objeto dentro do proprio objeto de locação.
    private Result<Rent> ProcessReturnBook(Rent rent, Rent isRent)
    {
        if (isRent.BookId == rent.BookId && isRent.CheckReturnTime())
        {
            _gateway.UpdateRentAsync(rent);
            //TODO: Atualizar score do cliente (Falta criar regra de negocio para o score)
        }
        //Todo: calcular dias em atraso e reduzir score
        return Result<Rent>.Fail("Failed to return book");;
    }   
}