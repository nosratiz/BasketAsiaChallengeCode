using Mc2.CrudTest.Web.Dto;

namespace Mc2.CrudTest.Web.Models;

public sealed class CreateCustomerViewModel
{
    public ApiError? Error { get; set; }
    
    public CreateCustomerDto Customer { get; set; }
}
