using Mc2.CrudTest.Web.Dto;

namespace Mc2.CrudTest.Web.Models;

public sealed class CreateCustomerViewModel
{
    public List<ApiError>? Errors { get; set; }
    
    public CreateCustomerDto Customer { get; set; }
}
