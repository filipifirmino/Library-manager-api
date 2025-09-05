using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.ApplicationCore.UseCases.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Web.Controllers;

[ApiController]
[Route("/api/v1/[controller]")]
public class RentController : ControllerBase
{
    private readonly ILogger<RentController> _logger;
    private readonly IProcessRent _useCase;
    private readonly IRentGateway _gateway;
    public RentController(IProcessRent useCase,
        ILogger<RentController> logger, 
        IRentGateway gateway)
    {
      _useCase = useCase;
      _logger = logger;
      _gateway = gateway;
    }

    [HttpGet]
    public async Task<IEnumerable<Rent>> GetAllRentAsync()
    {
        var rents = await _gateway.GetAllRentsAsync();
        return rents.Any() ? rents : new List<Rent>();
    }
    
    [HttpGet]
    [Route("/api/v1/[controller]/byId")]
    public async Task<IActionResult> GetAllRentByIdAsync(long rentId)
    {
        
        var rent = await _gateway.GetRentByRentId(rentId);
        return Ok(rent);
    }
    
    [HttpPost]
    [Route("/api/v1/[controller]/rent")]
    public async Task<IActionResult> PostRentAsync([FromBody] Rent rent)
    {
        var createRent = await _useCase.ExecuteAsync(rent);
        return createRent.IsSuccess ? Ok(createRent) : BadRequest(createRent);
    }
    
}