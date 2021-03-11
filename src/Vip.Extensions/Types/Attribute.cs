using System;
using System.Linq;
using System.Reflection;

public static partial class Methods
{
    public static TAttribute GetAttribute<TAttribute>(this ICustomAttributeProvider provider) where TAttribute : Attribute
    {
        var att = provider.GetCustomAttributes(typeof(TAttribute), true).FirstOrDefault() as TAttribute;
        return att;
    }
}