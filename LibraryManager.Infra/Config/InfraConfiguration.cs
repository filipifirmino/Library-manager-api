using LibraryManager.ApplicationCore.Gateway;
using LibraryManager.Infra.Gateways;
using LibraryManager.Infra.Repositores;
using LibraryManager.Infra.Repositores.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManager.Infra.Config;

public static class InfraConfiguration
{
    public static void addGateway(this IServiceCollection services)
    {
        services.AddScoped<IBookGateway, BookGateway>();
        services.AddScoped<IAuthorGateway, AuthorGateway>();
        services.AddScoped<IRentGateway, RentGateway>();
        services.AddScoped<ICustomerGateway, CustomerGateway>();
    }

    public static void AddRepository(this IServiceCollection services)
    {
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IAuthorRepository, AuthorRepository>();
        services.AddScoped<IRentRepository, RentRepository>();
        services.AddScoped<ICustomerRepository, CustomerRepository>();
    }

    public static void AddInfraConfiguration(this IServiceCollection services)
    {   
        services.AddRepository();
        services.addGateway();
    }
}