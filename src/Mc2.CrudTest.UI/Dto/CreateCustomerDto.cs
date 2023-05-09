using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.UI.Dto;

public sealed record CreateCustomerDto
{
    [Required]
    public string FirstName { get; set; } = string.Empty;
    [Required]
    public string LastName { get; set; } = string.Empty;
    [Required]
    public string Email { get; set; } = string.Empty;
    [Required]
    public string PhoneNumber { get; set; } = string.Empty;
    [Required]
    public string BankAccountNumber { get; set; } = string.Empty;
    [Required]
    public DateTime DateOfBirth { get; set; }
}