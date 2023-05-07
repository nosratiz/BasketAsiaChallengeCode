using System.Text;
using System.Text.Json;
using Mc2.CrudTest.Web.Dto;
using Mc2.CrudTest.Web.Models;

namespace Mc2.CrudTest.Web.Services;

public class CustomerWebService : ICustomerWebServices
{
    private readonly IHttpClientFactory _httpClientFactory;

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


    public async Task<CustomerDto?> AddCustomerAsync(CreateCustomerDto customer, CancellationToken cancellationToken)
    {
        var client = _httpClientFactory.CreateClient("CrudTest");
        var content = new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

        try
        {
            var response = await client.PostAsync("api/customers", content, cancellationToken);

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