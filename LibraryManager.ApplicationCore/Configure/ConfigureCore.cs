using LibraryManager.ApplicationCore.UseCases;
using LibraryManager.ApplicationCore.UseCases.Abstractions;
using Microsoft.Extensions.DependencyInjection;


namespace LibraryManager.ApplicationCore.Configure;

public static class ConfigureCore
{
    public static void ConfigureDependencies(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IProcessBook, ProcessBook>();
        serviceCollection.AddScoped<IProcessAuthor, ProcessAuthor>();
        serviceCollection.AddScoped<IProcessRent, ProcessRent>();
    }

    public static void AddCoreConfiguration(this IServiceCollection services)
    {
        services.ConfigureDependencies();
    }
}