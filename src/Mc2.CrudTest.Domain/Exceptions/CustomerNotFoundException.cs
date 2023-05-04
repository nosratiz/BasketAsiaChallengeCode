namespace Mc2.CrudTest.Domain.Exceptions;

public sealed class CustomerNotFoundException : Exception
{
    public CustomerNotFoundException(Guid id) : base($"Customer with id {id} not found")
    {
    }
}