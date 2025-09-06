using FluentAssertions;
using LibraryManager.ApplicationCore.Domain.Entities;
using LibraryManager.Infra.Gateways;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.Logging.Abstractions;
using Moq;
using Xunit;

namespace Librarymanager.Tests.Infra.UnitTests;
public class CustomerGatewayTest
{
    private readonly Mock<ICustomerRepository> _customerRepository;
    private readonly CustomerGateway _customerGateway;
    public CustomerGatewayTest()
    {
        _customerRepository = new Mock<ICustomerRepository>();
        _customerGateway = new CustomerGateway(_customerRepository.Object, new NullLogger<CustomerGateway>());
    }

    [Fact]
    public async Task GetAllCustomersAsync_ShouldReturnCustomers_WhenCustomersExist()
    {
        var customers = new List<Customer> { new Customer { Name = "Customer 1" } };
        _customerRepository.Setup(x => x.GetAllCustomerAsync()).ReturnsAsync(customers);
        var result = (await _customerGateway.GetAllCustomersAsync()).ToList();
        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(customers);
    }

    [Fact]
    public async Task GetAllCustomersAsync_ShouldReturnEmptyList_WhenNoCustomersExist()
    {
        var customers = new List<Customer>();
        _customerRepository.Setup(x => x.GetAllCustomerAsync()).ReturnsAsync(customers);
        var result = (await _customerGateway.GetAllCustomersAsync()).ToList();
        result.Should().NotBeNull();
        result.Should().BeEmpty();
    }

    [Fact]
    public async Task GetAllCustomersAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        _customerRepository.Setup(x => x.GetAllCustomerAsync()).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _customerGateway.GetAllCustomersAsync());
    }

    [Fact]
    public async Task GetCustomerByIdAsync_ShouldReturnCustomer_WhenCustomerExists()
    {
        var customerId = Guid.NewGuid();
        var customer = new Customer { Id = customerId, Name = "Customer 1" };
        _customerRepository.Setup(x => x.GetByIdAsync(customerId)).ReturnsAsync(customer);
        var result = await _customerGateway.GetCustomerByIdAsync(customerId);
        result.Should().NotBeNull();
        result.Should().Be(customer);
    }

    [Fact]
    public async Task GetCustomerByIdAsync_ShouldReturnNull_WhenCustomerDoesNotExist()
    {
        var customerId = Guid.NewGuid();
        _customerRepository.Setup(x => x.GetByIdAsync(customerId)).ReturnsAsync((Customer?)null);
        var result = await _customerGateway.GetCustomerByIdAsync(customerId);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetCustomerByIdAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var customerId = Guid.NewGuid();
        _customerRepository.Setup(x => x.GetByIdAsync(customerId)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _customerGateway.GetCustomerByIdAsync(customerId));
    }

    [Fact]
    public async Task CreateCustomerAsync_ShouldReturnCustomer_WhenCustomerIsValid()
    {
        var customer = new Customer { Name = "Customer 1" };
        _customerRepository.Setup(x => x.AddAsync(customer)).ReturnsAsync(customer);
        var result = await _customerGateway.CreateCustomerAsync(customer);
        result.Should().NotBeNull();
        result.Should().Be(customer);
    }

    [Fact]
    public async Task CreateCustomerAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var customer = new Customer { Name = "Customer 1" };
        _customerRepository.Setup(x => x.AddAsync(customer)).ThrowsAsync(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _customerGateway.CreateCustomerAsync(customer));
    }

    [Fact]
    public async Task UpdateCustomerAsync_ShouldComplete_WhenCustomerIsValid()
    {
        var customer = new Customer { Name = "Customer 1" };
        _customerRepository.Setup(x => x.UpdateAsync(customer)).ReturnsAsync(customer);
        var result = await _customerGateway.UpdateCustomerAsync(customer);
        result.Should().Be(Task.CompletedTask);
    }

    [Fact]
    public async Task UpdateCustomerAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var customer = new Customer { Name = "Customer 1" };
        _customerRepository.Setup(x => x.UpdateAsync(customer)).Throws(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _customerGateway.UpdateCustomerAsync(customer));
    }

    [Fact]
    public async Task DeleteCustomerAsync_ShouldComplete_WhenCustomerIsValid()
    {
        var customer = new Customer { Name = "Customer 1" };
        _customerRepository.Setup(x => x.DeleteAsync(customer)).ReturnsAsync(true);
        var task = _customerGateway.DeleteCustomerAsync(customer);
        await task;
        task.IsCompletedSuccessfully.Should().BeTrue();
    }

    [Fact]
    public async Task DeleteCustomerAsync_ShouldThrowException_WhenRepositoryThrows()
    {
        var customer = new Customer { Name = "Customer 1" };
        _customerRepository.Setup(x => x.DeleteAsync(customer)).Throws(new Exception("Repository error"));
        await Xunit.Assert.ThrowsAsync<Exception>(() => _customerGateway.DeleteCustomerAsync(customer));
    }
}

