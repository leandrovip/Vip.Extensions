using System;

public static partial class Methods
{
    public static bool IsEmpty(this Guid value)
    {
        return value.Equals(Guid.Empty);
    }

    public static bool IsNotEmpty(this Guid value)
    {
        return !value.IsEmpty();
    }
}