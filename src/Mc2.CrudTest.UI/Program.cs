using Mc2.CrudTest.UI.Options;
using Mc2.CrudTest.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();

builder.Services.Configure<HostAddress>(builder.Configuration.GetSection("HostAddress"));

var hostAddress = new HostAddress();
builder.Configuration.Bind(nameof(HostAddress), hostAddress);
builder.Services.AddSingleton(hostAddress);

builder.Services.AddHttpClient("CrudTest", client =>
{
    client.BaseAddress = new Uri(hostAddress.BaseUrl);
});

builder.Services.AddScoped<ICustomerWebServices, CustomerWebService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();