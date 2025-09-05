using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class AuthorController : ControllerBase
{
    private readonly IAuthorGateway _authorGateway;
    public AuthorController(IAuthorGateway authorGateway)
    { 
        _authorGateway = authorGateway;
    }
    [HttpGet]
    [Route("all-authors")]
    public async Task<IActionResult> GetAllAuthorsAsync()
    {
        var books = await _authorGateway.GetAllAuthorsAsync();
        return Ok(books);
    }

    [HttpGet]
    [Route("get-author")]
    public async Task<IActionResult> GetAuthorAsync([FromHeader] Guid authorId)
    {
        var author = await _authorGateway.GetAuthorByIdAsync(authorId);
       
        return author is null ? NotFound() : Ok(author);
    }
    
    [HttpPost]
    [Route("register-author")]
    public async Task<IActionResult> PostAuthorAsync([FromBody] Author author)
    {
        var authorResult = await _authorGateway.CreateAuthorAsync(author);
        return authorResult is null ? BadRequest() : Ok(authorResult);
    }
    
    [HttpPut]
    [Route("update-author")]
    public async Task<IActionResult> PutAuthorAsync([FromBody] Author author)
    {
        var authorUpdate  = await _authorGateway.UpdateAuthorAsync(author);
        return authorUpdate is null ? BadRequest() : Ok(authorUpdate);
    }
    
    [HttpDelete]
    [Route("remove-author")]
    public async Task<IActionResult> DeleteAuthorAsync([FromBody] Author author)
    {
        await _authorGateway.DeleteAuthorAsync(author);
        return Ok();
    }
}