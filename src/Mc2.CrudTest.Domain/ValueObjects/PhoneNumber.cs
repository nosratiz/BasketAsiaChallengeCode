using Ardalis.GuardClauses;
using Mc2.CrudTest.Domain.Extensions;
using Mc2.CrudTest.Domain.Primitives;

namespace Mc2.CrudTest.Domain.ValueObjects;

public class PhoneNumber : ValueObject
{
    public PhoneNumber(string value)
    {
        Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
        Guard.Against.InvalidPhoneNumber(value);
    }
    
    public string Value { get; }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value; 
    }

    public override string ToString() => Value;
    
}