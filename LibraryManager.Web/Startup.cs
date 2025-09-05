using LibraryManager.ApplicationCore.Configure;
using LibraryManager.Infra.Config;
using Microsoft.OpenApi.Models;

namespace LibraryManager.Web;

public class Startup
{
    public IConfiguration Configuration { get; }
    
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddInfraConfiguration();
        services.AddCoreConfiguration();
        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo { Title = "Library Manager", Version = "v1" });
        });
        services.AddDbContext<DataContext>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI( s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Library Manager"));
        }
        
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}