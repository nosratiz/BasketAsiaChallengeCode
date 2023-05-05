using Ardalis.GuardClauses;
using Mc2.CrudTest.Domain.Primitives;

namespace Mc2.CrudTest.Domain.ValueObjects;

public sealed class Email : ValueObject
{
    public Email(string value)
    {
        Value = Guard.Against.NullOrWhiteSpace(value, nameof(value));
        Guard.Against.InvalidFormat(value, nameof(value), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
    }

    public string Value { get; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public override string ToString() => Value;
}