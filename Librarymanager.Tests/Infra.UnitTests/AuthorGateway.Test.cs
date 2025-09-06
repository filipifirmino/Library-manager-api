using FluentAssertions;
using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.Infra.Gateways;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Librarymanager.Tests.Infra.UnitTests;

public class AuthorGatewayTest
{
    private readonly Mock<IAuthorRepository> _authorRepository;
    private readonly IAuthorGateway _authorGateway;
    public AuthorGatewayTest()
    {
        _authorRepository = new Mock<IAuthorRepository>();
        _authorGateway = new AuthorGateway(_authorRepository.Object, new NullLogger<AuthorGateway>());
    }
    
    [Fact]
    public async Task CreateAuthor_ShouldReturnAuthor_WhenAuthorIsValid()
    {
        var author = new Author { Name = "John Doe" };
        
        _authorRepository.Setup(x => x.AddAuthor(author)).ReturnsAsync(author);
        
        var result = await _authorGateway.CreateAuthorAsync(author);
        
        result.Should().NotBeNull();
        result.Should().Be(author);
    }

    [Fact]
    public async Task GetAllAuthorsAsync_ShouldReturnAuthors_WhenAuthorsExist()
    {
        var authors = new List<Author> { new Author { Name = "John Doe" } };
        
        _authorRepository.Setup(x => x.GetAllAuthorAsync()).ReturnsAsync(authors);
        
        var result = (await _authorGateway.GetAllAuthorsAsync()).ToList();
        
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(authors);
    }

    [Fact]
    public async Task GetAllAuthorsAsync_ShouldReturnEmptyList_WhenNoAuthorsExist()
    {
        var authors = new List<Author>();
        
        _authorRepository.Setup(x => x.GetAllAuthorAsync()).ReturnsAsync(authors);
        
        var result = (await _authorGateway.GetAllAuthorsAsync()).ToList();
        
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllAuthorsAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        _authorRepository.Setup(x => x.GetAllAuthorAsync()).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _authorGateway.GetAllAuthorsAsync());
    }

    [Fact]
    public async Task GetAuthorByIdAsync_ShouldReturnAuthor_WhenAuthorExists()
    {
        var authorId = Guid.NewGuid();
        var author = new Author { Id = authorId, Name = "Jane Doe" };
        
        _authorRepository.Setup(x => x.GetAuthorByIdAsync(authorId)).ReturnsAsync(author);
        
        var result = await _authorGateway.GetAuthorByIdAsync(authorId);
        
        result.Should().NotBeNull();
        result.Should().Be(author);
    }

    [Fact]
    public async Task GetAuthorByIdAsync_ShouldReturnNull_WhenAuthorDoesNotExist()
    {
        var authorId = Guid.NewGuid();
        
        _authorRepository.Setup(x => x.GetAuthorByIdAsync(authorId)).ReturnsAsync((Author?)null);
        
        var result = await _authorGateway.GetAuthorByIdAsync(authorId);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetAuthorByIdAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var authorId = Guid.NewGuid();
        _authorRepository.Setup(x => x.GetAuthorByIdAsync(authorId)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _authorGateway.GetAuthorByIdAsync(authorId));
    }

    [Fact]
    public async Task CreateAuthorAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var author = new Author { Name = "John Doe" };
        _authorRepository.Setup(x => x.AddAuthor(author)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _authorGateway.CreateAuthorAsync(author));
    }

    [Fact]
    public async Task UpdateAuthorAsync_ShouldComplete_WhenAuthorIsValid()
    {
        var author = new Author { Name = "John Doe" };
        
        _authorRepository.Setup(x => x.UpdateAuthor(author)).Returns(Task.CompletedTask);
        
        var result = await _authorGateway.UpdateAuthorAsync(author);
        result.Should().Be(Task.CompletedTask);
    }

    [Fact]
    public async Task UpdateAuthorAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var author = new Author { Name = "John Doe" };
        _authorRepository.Setup(x => x.UpdateAuthor(author)).Throws(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _authorGateway.UpdateAuthorAsync(author));
    }

    [Fact]
    public async Task DeleteAuthorAsync_ShouldComplete_WhenAuthorIsValid()
    {
        var author = new Author { Name = "John Doe" };
        
        _authorRepository.Setup(x => x.DeleteAuthor(author)).Returns(Task.CompletedTask);
        
        var task = _authorGateway.DeleteAuthorAsync(author);
        await task;
        
        task.IsCompletedSuccessfully.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteAuthorAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var author = new Author { Name = "John Doe" };
        _authorRepository.Setup(x => x.DeleteAuthor(author)).Throws(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _authorGateway.DeleteAuthorAsync(author));
    }
}