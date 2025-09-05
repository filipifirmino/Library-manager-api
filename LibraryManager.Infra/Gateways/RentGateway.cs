using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.Logging;

namespace LibraryManager.Infra.Gateways;

public class RentGateway : IRentGateway
{
    private readonly ILogger<RentGateway> _logger;
    private readonly IRentRepository _repository;
    public RentGateway(ILogger<RentGateway> logger, IRentRepository repository)
    {
       _logger = logger;
       _repository = repository;
    }
    public async Task<IEnumerable<Rent>> GetAllRentsAsync()
    {
        try
        {
            var rents = await _repository.GetAllRentsAsync();
            if(!rents.Any())
                return Array.Empty<Rent>();
            return rents;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            const string message = "There was an error retrieving all rents.";
            throw new Exception(message);
        }
    }

    public async Task<Rent> GetRentsByUserIdAsync(Guid customerId)
    {
        try
        {
            var rent = await _repository.GetRentsByUserIdAsync(customerId);
            return rent;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            const string message = "There was an error retrieving rent by customer.";
            throw new Exception(message);
        }
    }

    public async Task<IEnumerable<Rent>> GetAllRentsByDateAsync(DateTime date)
    {
        try
        {
            var rent = await _repository.GetAllRentsByDateAsync(date);
            return rent;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            const string message = "There was an error retrieving all rents by date.";
            throw new Exception(message);
        }
    }

    public async Task<Rent> CreateRentAsync(Rent rent)
    {
        try
        {
            var rentResult = await _repository.CreateRentAsync(rent);
            return rentResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            const string message = "There was an error retrieving rent.";
            throw new Exception(message);
        }
    }

    public async Task UpdateRentAsync(Rent rent)
    {
        try
        {
            await _repository.UpdateRentAsync(rent);
            return ;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            const string message = "There was an error updating rent.";
            throw new Exception(message);
        }
    }

    public async Task<Rent> GetRentByRentId(long rentId)
    {
        try
        {
            var rent = await _repository.GetRentById(rentId);
            return rent;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, ex.Message);
            const string message = "There was an error get rent by id.";
            throw new Exception(message);
        }
    }
}