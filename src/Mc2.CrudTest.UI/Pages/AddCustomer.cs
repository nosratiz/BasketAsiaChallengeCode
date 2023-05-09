using Mc2.CrudTest.UI.Dto;
using Mc2.CrudTest.UI.Models;
using Mc2.CrudTest.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Mc2.CrudTest.UI.Pages;

public partial class AddCustomer
{
    [Inject] private ICustomerWebServices CustomerWebServices { get; set; }

    [Inject] private NavigationManager NavigationManager { get; set; }

    private CreateCustomerDto Customer = new();
    private List<ApiError>? Errors { get; set; }
    
    
    protected async Task CreateCustomerAsync()
    {
        var result = await CustomerWebServices.AddCustomerAsync(Customer, CancellationToken.None);

        if (result.Errors is null)
        {
            NavigationManager.NavigateTo("/");
        }
        else
        {
            Errors = result.Errors;
        }
    }

    protected async Task InvalidSubmitAsync()
    {
        await Task.CompletedTask;
    }
}