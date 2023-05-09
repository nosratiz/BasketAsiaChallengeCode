using Mc2.CrudTest.UI.Dto;
using Mc2.CrudTest.UI.Models;
using Mc2.CrudTest.UI.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace Mc2.CrudTest.UI.Pages;

public partial class EditCustomer
{
    [Parameter] public string? Id { get; set; }
    [Inject] private ICustomerWebServices CustomerWebServices { get; set; }

    [Inject] private NavigationManager NavigationManager { get; set; }

    private UpdateCustomerDto Customer = new();

    protected override async Task OnInitializedAsync()
    {
        var customer = await CustomerWebServices.GetCustomerAsync(Guid.Parse(Id), CancellationToken.None);

        if (customer is not null)
        {
            Customer = new UpdateCustomerDto
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                BankAccountNumber = customer.BankAccountNumber,
                DateOfBirth = customer.DateOfBirth
            };
        }
    }



    protected async Task UpdateCustomerAsync()
    {
        var result = await CustomerWebServices.UpdateCustomerAsync(Customer, CancellationToken.None);

        NavigationManager.NavigateTo("/");


    }
}