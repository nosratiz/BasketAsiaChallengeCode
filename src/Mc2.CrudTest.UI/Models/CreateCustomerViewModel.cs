using Mc2.CrudTest.UI.Dto;

namespace Mc2.CrudTest.UI.Models;

public sealed class CreateCustomerViewModel
{
    public List<ApiError>? Errors { get; set; }
    
    public CreateCustomerDto Customer { get; set; }
}
