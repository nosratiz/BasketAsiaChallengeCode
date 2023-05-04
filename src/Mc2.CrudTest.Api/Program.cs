using Mc2.CrudTest.Api.Installer;
using Mc2.CrudTest.Api.Middleware;
using Mc2.CrudTest.Application;
using Mc2.CrudTest.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.InstallServicesAssembly();
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);

var app = builder.Build();

await InitialDatabaseServices.Init(app);

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();