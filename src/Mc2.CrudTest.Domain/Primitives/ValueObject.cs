namespace Mc2.CrudTest.Domain.Primitives;

public abstract class ValueObject : IEquatable<ValueObject>
{
    public abstract IEnumerable<object> GetAtomicValues();

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;

        if (ReferenceEquals(this, obj)) return true;

        return obj.GetType() == GetType() && Equals((ValueObject) obj);
    }

    public override int GetHashCode()
    {
        return GetAtomicValues()
            .Aggregate(default(int),
                HashCode.Combine);
    }

    private bool ValueAreEqual(ValueObject other)
        => GetAtomicValues().SequenceEqual(other.GetAtomicValues());

    public bool Equals(ValueObject? other) => other != null && ValueAreEqual(other);
}