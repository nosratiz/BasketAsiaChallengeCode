using System.Reflection;
using AutoMapper;
using Mc2.CrudTest.Application.Common.AutoMapper;
using Microsoft.OpenApi.Models;

namespace Mc2.CrudTest.Api.Installer;

public class MvcInstaller : IInstaller
{
    public void InstallServices(IServiceCollection services)
    {

        var mappingConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        IMapper mapper = mappingConfig.CreateMapper();
        services.AddSingleton(mapper);
        
        services.AddRouting(options => options.LowercaseUrls = true);

        services.AddControllers();
            
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opts =>
        {
            opts.SwaggerDoc("v1", new OpenApiInfo { Title = "Mc2 Test information", Version = "v1" });
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            opts.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
        });
    }
}
