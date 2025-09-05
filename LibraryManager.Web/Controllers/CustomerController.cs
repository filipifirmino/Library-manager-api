using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Web.Controllers;

[ApiController]
[Route("api/vi/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ICustomerGateway _customerGateway;
    public CustomerController(ICustomerGateway customerGateway)
    {
        _customerGateway = customerGateway;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerAsync()
    {
        var allCustomers = await _customerGateway.GetAllCustomersAsync();
        return Ok(allCustomers);
    }
    
    [HttpPost]
    public async Task<IActionResult> PostCustomerAsync([FromBody] Customer customer)
    {
        var createdCustomer = await _customerGateway.CreateCustomerAsync(customer);
        return Ok(createdCustomer);
    }
    
    [HttpPut]
    public async Task<IActionResult> PutCustomerAsync([FromBody] Customer customer)
    {
        var updatedCustomer = await _customerGateway.UpdateCustomerAsync(customer);
        return Ok(updatedCustomer);
    }
    
    [HttpDelete]
    public async Task<IActionResult> DeleteCustomerAsync([FromBody] Customer customer)
    {
        _ = _customerGateway.DeleteCustomerAsync(customer);
        return Ok();
    }
}