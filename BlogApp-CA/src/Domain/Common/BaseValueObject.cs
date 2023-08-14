namespace BlogApp_CA.Domain.ValueObjects;

public abstract class ValueObject : IEquatable<ValueObject>
{


    public abstract IEnumerable<object> GetAtomicObjects();
    public bool Equals(ValueObject? other)
    {
        return other != null && ValuesAreEqual(other);
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        int hash = default(int).GetHashCode();
        foreach (var item in GetAtomicObjects())
        {
            hash = HashCode.Combine(hash, item.GetHashCode());
            
        }
        return hash;
    }

    public bool ValuesAreEqual(ValueObject other){
        return GetAtomicObjects().SequenceEqual(other.GetAtomicObjects());
    }

}