using FluentAssertions;
using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Entity;
using LibraryManager.Infra.Gateways;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Librarymanager.Tests.Infra.UnitTests;

public class BookGatewayTest
{
    private readonly Mock<IBookRepository> _bookRepository;
    private readonly BookGateway _bookGateway;
    public BookGatewayTest()
    {
        _bookRepository = new Mock<IBookRepository>();
        _bookGateway = new BookGateway(_bookRepository.Object, new NullLogger<BookGateway>());
    }

    [Fact]
    public async Task GetAllBooksAsync_ShouldReturnBooks_WhenBooksExist()
    {
        var books = new List<Book> { new Book { Title = "Book 1" } };
        _bookRepository.Setup(x => x.GetAllBooksAsync()).ReturnsAsync(books);
        var result = (await _bookGateway.GetAllBooksAsync()).ToList();
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(books);
    }

    [Fact]
    public async Task GetAllBooksAsync_ShouldReturnEmptyList_WhenNoBooksExist()
    {
        var books = new List<Book>();
        _bookRepository.Setup(x => x.GetAllBooksAsync()).ReturnsAsync(books);
        var result = (await _bookGateway.GetAllBooksAsync()).ToList();
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllBooksAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        _bookRepository.Setup(x => x.GetAllBooksAsync()).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _bookGateway.GetAllBooksAsync());
    }

    [Fact]
    public async Task GetBookByIdAsync_ShouldReturnBook_WhenBookExists()
    {
        var bookId = Guid.NewGuid();
        var book = new Book { Id = bookId, Title = "Book 1" };
        _bookRepository.Setup(x => x.GetBookByIdAsync(bookId)).ReturnsAsync(book);
        var result = await _bookGateway.GetBookByIdAsync(bookId);
        result.Should().NotBeNull();
        result.Should().Be(book);
    }

    [Fact]
    public async Task GetBookByIdAsync_ShouldReturnNull_WhenBookDoesNotExist()
    {
        var bookId = Guid.NewGuid();
        _bookRepository.Setup(x => x.GetBookByIdAsync(bookId)).ReturnsAsync((Book?)null);
        var result = await _bookGateway.GetBookByIdAsync(bookId);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetBookByIdAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var bookId = Guid.NewGuid();
        _bookRepository.Setup(x => x.GetBookByIdAsync(bookId)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _bookGateway.GetBookByIdAsync(bookId));
    }

    [Fact]
    public async Task CreateBookAsync_ShouldReturnBook_WhenBookIsValid()
    {
        var book = new Book { Title = "Book 1" };
        _bookRepository.Setup(x => x.AddBook(It.IsAny<BookEntity>())).ReturnsAsync(book);
        var result = await _bookGateway.CreateBookAsync(book);
        result.Should().NotBeNull();
        result.Should().Be(book);
    }

    [Fact]
    public async Task CreateBookAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var book = new Book { Title = "Book 1" };
        _bookRepository.Setup(x => x.AddBook(It.IsAny<BookEntity>())).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _bookGateway.CreateBookAsync(book));
    }

    [Fact]
    public async Task UpdateBookAsync_ShouldComplete_WhenBookIsValid()
    {
        var book = new Book { Title = "Book 1" };
        _bookRepository.Setup(x => x.UpdateBook(It.IsAny<BookEntity>())).Returns(Task.CompletedTask);
        var result = await _bookGateway.UpdateBookAsync(book);
        result.Should().Be(Task.CompletedTask);
    }

    [Fact]
    public async Task UpdateBookAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var book = new Book { Title = "Book 1" };
        _bookRepository.Setup(x => x.UpdateBook(It.IsAny<BookEntity>())).Throws(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _bookGateway.UpdateBookAsync(book));
    }

    [Fact]
    public async Task DeleteBookAsync_ShouldComplete_WhenBookIsValid()
    {
        var book = new Book { Title = "Book 1" };
        _bookRepository.Setup(x => x.DeleteBook(It.IsAny<BookEntity>())).Returns(Task.CompletedTask);
        var task = _bookGateway.DeleteBookAsync(book);
        await task;
        task.IsCompletedSuccessfully.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteBookAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var book = new Book { Title = "Book 1" };
        _bookRepository.Setup(x => x.DeleteBook(It.IsAny<BookEntity>())).Throws(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _bookGateway.DeleteBookAsync(book));
    }
}