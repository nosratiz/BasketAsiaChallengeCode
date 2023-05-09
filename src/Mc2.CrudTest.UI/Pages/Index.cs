using Mc2.CrudTest.UI.Dto;
using Mc2.CrudTest.UI.Services;
using Microsoft.AspNetCore.Components;

namespace Mc2.CrudTest.UI.Pages;

public partial class Index
{
    [Inject] private ICustomerWebServices CustomerWebServices { get; set; }
    [Inject] private NavigationManager NavigationManager { get; set; }
    [Inject] private ILogger<Index> Logger { get; set; }

    public List<CustomerDto> Customers { get; set; } = new();


    protected override async Task OnInitializedAsync()
    {
        var customers = await CustomerWebServices.GetCustomerListAsync(CancellationToken.None);

        Logger.LogInformation("Customers: {Customers}", customers);

        if (customers != null)
            Customers = customers.ToList();
    }

    private void EditCustomer(Guid Id)
    {
        NavigationManager.NavigateTo($"/editCustomer/{Id}");
    }

    private async Task DeleteCustomerAsync(Guid id)
    {
        await CustomerWebServices.DeleteCustomerAsync(id, CancellationToken.None);
        NavigationManager.NavigateTo("/");
    }
}