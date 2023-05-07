using Mc2.CrudTest.Web.Dto;

namespace Mc2.CrudTest.Web.Models;

public sealed class UpdateCustomerViewModel
{
    public ApiError? Error { get; set; }
    
    public CustomerDto? Customer { get; set; }
    
    public UpdateCustomerDto UpdateCustomer { get; set; }
}