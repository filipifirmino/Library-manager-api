using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.Web.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookGateway _bookGateway;
    public BookController(IBookGateway bookGateway)
    { 
        _bookGateway = bookGateway;
    }
    [HttpGet]
    [Route("all-books")]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        var books = await _bookGateway.GetAllBooksAsync();
        return Ok(books);
    }

    [HttpGet]
    [Route("get-books")]
    public async Task<IActionResult> GetBooksAsync([FromHeader] Guid bookId)
    {
        var book = await _bookGateway.GetBookByIdAsync(bookId);
       
        return book is null ? NotFound() : Ok(book);
    }
    
    [HttpPost]
    [Route("register-books")]
    public async Task<IActionResult> PostBookAsync([FromBody] Book book)
    {
        var bookResult = await _bookGateway.CreateBookAsync(book);
        return bookResult is null ? BadRequest() : Ok(bookResult);
    }
    
    [HttpPut]
    [Route("update-books")]
    public async Task<IActionResult> PutBookAsync([FromBody] Book book)
    {
        var bookUpdate  = await _bookGateway.UpdateBookAsync(book);
        return bookUpdate is null ? BadRequest() : Ok(bookUpdate);
    }
    
    [HttpDelete]
    [Route("remove-books")]
    public async Task<IActionResult> DeleteBookAsync([FromBody] Book book)
    {
        await _bookGateway.DeleteBookAsync(book);
        return Ok();
    }
}