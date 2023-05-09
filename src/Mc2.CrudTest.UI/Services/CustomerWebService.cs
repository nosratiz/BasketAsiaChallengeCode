using System.Net;
using System.Text;
using System.Text.Json;
using Mc2.CrudTest.UI.Dto;
using Mc2.CrudTest.UI.Models;

namespace Mc2.CrudTest.UI.Services;

public class CustomerWebService : ICustomerWebServices
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<CustomerWebService> _logger;

    public CustomerWebService(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public async Task<List<CustomerDto>?> GetCustomerListAsync(CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("CrudTest");
            var response = await client.GetAsync("api/customers", cancellationToken);

            if (response.IsSuccessStatusCode != true) return new List<CustomerDto>();

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<List<CustomerDto>>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return new List<CustomerDto>();
    }

    public async Task<CustomerDto?> GetCustomerAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("CrudTest");
            var response = await client.GetAsync($"api/customers/{id}", cancellationToken);

            if (response.IsSuccessStatusCode == false) return null;

            var content = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CustomerDto>(content, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }

        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }


    public async Task<CreateCustomerViewModel> AddCustomerAsync(CreateCustomerDto customer,
        CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("CrudTest");
        var content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync("api/customers", content, cancellationToken);

            if (response is {IsSuccessStatusCode: false, StatusCode: HttpStatusCode.BadRequest})
            {
                var errorContent = await response.Content.ReadAsStringAsync(cancellationToken);

                var error = JsonSerializer.Deserialize<List<ApiError>>(errorContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

                return new CreateCustomerViewModel()
                {
                    Errors = error
                };
            }

            if (response.IsSuccessStatusCode == false) return null;


            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            var customerResult = JsonSerializer.Deserialize<CreateCustomerDto>(responseContent,
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });

            return new CreateCustomerViewModel()
            {
                Customer = customerResult
            };
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }

        return null;
    }

    public async Task<CustomerDto?> UpdateCustomerAsync(UpdateCustomerDto customer, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("CrudTest");
        var content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PutAsync($"api/customers", content, cancellationToken);

            if (response.IsSuccessStatusCode) return null;

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken);
            return JsonSerializer.Deserialize<CustomerDto>(responseContent, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return null;
        }
    }

    public async Task DeleteCustomerAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var client = _httpClientFactory.CreateClient("CrudTest");
            await client.DeleteAsync($"api/customers/{id}", cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
}