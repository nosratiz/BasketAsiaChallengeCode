using Mc2.CrudTest.Web.Dto;

namespace Mc2.CrudTest.Web.Models;

public sealed class UpdateCustomerViewModel
{
    public List<ApiError>? Errors { get; set; }

    public CustomerDto? Customer { get; set; }

    public UpdateCustomerDto UpdateCustomer { get; set; }
}