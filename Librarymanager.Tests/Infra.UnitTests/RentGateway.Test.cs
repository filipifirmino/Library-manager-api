using FluentAssertions;
using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Gateways;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

public class RentGatewayTest
{
    private readonly Mock<IRentRepository> _rentRepository;
    private readonly RentGateway _rentGateway;
    public RentGatewayTest()
    {
        _rentRepository = new Mock<IRentRepository>();
        _rentGateway = new RentGateway(new NullLogger<RentGateway>(), _rentRepository.Object);
    }

    [Fact]
    public async Task GetAllRentsAsync_ShouldReturnRents_WhenRentsExist()
    {
        var rents = new List<Rent> { new Rent { Id = 1 } };
        _rentRepository.Setup(x => x.GetAllRentsAsync()).ReturnsAsync(rents);
        var result = (await _rentGateway.GetAllRentsAsync()).ToList();
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(rents);
    }

    [Fact]
    public async Task GetAllRentsAsync_ShouldReturnEmptyList_WhenNoRentsExist()
    {
        var rents = new List<Rent>();
        _rentRepository.Setup(x => x.GetAllRentsAsync()).ReturnsAsync(rents);
        var result = (await _rentGateway.GetAllRentsAsync()).ToList();
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllRentsAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        _rentRepository.Setup(x => x.GetAllRentsAsync()).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _rentGateway.GetAllRentsAsync());
    }

    [Fact]
    public async Task GetRentsByUserIdAsync_ShouldReturnRent_WhenRentExists()
    {
        var customerId = Guid.NewGuid();
        var rent = new Rent { Id = 1 };
        _rentRepository.Setup(x => x.GetRentsByUserIdAsync(customerId)).ReturnsAsync(rent);
        var result = await _rentGateway.GetRentsByUserIdAsync(customerId);
        result.Should().NotBeNull();
        result.Should().Be(rent);
    }

    [Fact]
    public async Task GetRentsByUserIdAsync_ShouldReturnNull_WhenRentDoesNotExist()
    {
        var customerId = Guid.NewGuid();
        _rentRepository.Setup(x => x.GetRentsByUserIdAsync(customerId)).ReturnsAsync((Rent?)null);
        var result = await _rentGateway.GetRentsByUserIdAsync(customerId);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetRentsByUserIdAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var customerId = Guid.NewGuid();
        _rentRepository.Setup(x => x.GetRentsByUserIdAsync(customerId)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _rentGateway.GetRentsByUserIdAsync(customerId));
    }

    [Fact]
    public async Task GetAllRentsByDateAsync_ShouldReturnRents_WhenRentsExist()
    {
        var date = DateTime.Now;
        var rents = new List<Rent> { new Rent { Id = 1 } };
        _rentRepository.Setup(x => x.GetAllRentsByDateAsync(date)).ReturnsAsync(rents);
        var result = (await _rentGateway.GetAllRentsByDateAsync(date)).ToList();
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(rents);
    }

    [Fact]
    public async Task GetAllRentsByDateAsync_ShouldReturnEmptyList_WhenNoRentsExist()
    {
        var date = DateTime.Now;
        var rents = new List<Rent>();
        _rentRepository.Setup(x => x.GetAllRentsByDateAsync(date)).ReturnsAsync(rents);
        var result = (await _rentGateway.GetAllRentsByDateAsync(date)).ToList();
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllRentsByDateAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var date = DateTime.Now;
        _rentRepository.Setup(x => x.GetAllRentsByDateAsync(date)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _rentGateway.GetAllRentsByDateAsync(date));
    }

    [Fact]
    public async Task CreateRentAsync_ShouldReturnRent_WhenRentIsValid()
    {
        var rent = new Rent { Id = 1 };
        _rentRepository.Setup(x => x.CreateRentAsync(rent)).ReturnsAsync(rent);
        var result = await _rentGateway.CreateRentAsync(rent);
        result.Should().NotBeNull();
        result.Should().Be(rent);
    }

    [Fact]
    public async Task CreateRentAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var rent = new Rent { Id = 1 };
        _rentRepository.Setup(x => x.CreateRentAsync(rent)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _rentGateway.CreateRentAsync(rent));
    }

    [Fact]
    public async Task UpdateRentAsync_ShouldComplete_WhenRentIsValid()
    {
        var rent = new Rent { Id = 1 };
        _rentRepository.Setup(x => x.UpdateRentAsync(rent)).Returns(Task.CompletedTask);
        await _rentGateway.UpdateRentAsync(rent);
    }

    [Fact]
    public async Task UpdateRentAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var rent = new Rent { Id = 1 };
        _rentRepository.Setup(x => x.UpdateRentAsync(rent)).Throws(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _rentGateway.UpdateRentAsync(rent));
    }

    [Fact]
    public async Task GetRentByRentId_ShouldReturnRent_WhenRentExists()
    {
        long rentId = 1;
        var rent = new Rent { Id = rentId };
        _rentRepository.Setup(x => x.GetRentById(rentId)).ReturnsAsync(rent);
        var result = await _rentGateway.GetRentByRentId(rentId);
        result.Should().NotBeNull();
        result.Should().Be(rent);
    }

    [Fact]
    public async Task GetRentByRentId_ShouldReturnNull_WhenRentDoesNotExist()
    {
        long rentId = 1;
        _rentRepository.Setup(x => x.GetRentById(rentId)).ReturnsAsync((Rent?)null);
        var result = await _rentGateway.GetRentByRentId(rentId);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetRentByRentId_ShouldThrowException_WhenRepositoryThrows()
    {
        long rentId = 1;
        _rentRepository.Setup(x => x.GetRentById(rentId)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _rentGateway.GetRentByRentId(rentId));
    }
}
