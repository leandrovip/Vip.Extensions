using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

public static partial class Methods
{
    public static bool IsNull(this object value) => value == null;
    public static bool IsNotNull(this object value) => value != null;
    public static bool IsNullOrEmpty(this object value) => value.IsNull() || value.ToString().IsNullOrEmpty();
    public static bool IsNotNullOrEmpty(this object value) => !value.IsNullOrEmpty();

    public static T GetPropertyValue<T>(this object value, string propertyName)
    {
        if (value == null) return default;
        if (propertyName.IsNullOrEmpty()) return default;

        var parts = propertyName.Split('.');
        var path = propertyName;
        var root = value;

        if (parts.Length > 1)
        {
            path = parts[parts.Length - 1];
            parts = parts.TakeWhile((p, i) => i < parts.Length - 1).ToArray();
            var path2 = string.Join(".", parts);
            root = value.GetPropertyValue<object>(path2);
        }

        if (root == null) return default;

        var sourceType = root.GetType();
        var result = typeof(T) == typeof(string)
            ? sourceType.GetProperty(path)?.GetValue(root, null)?.ToString()
            : sourceType.GetProperty(path)?.GetValue(root, null);

        if (result.IsNull())
            result = (T) default;

        return (T) result;
    }

    public static T GetValue<T>(this PropertyInfo property, object source)
    {
        try
        {
            var value = property.GetValue(source);
            var typeCode = Type.GetTypeCode(typeof(T));
            var convert = (T) Convert.ChangeType(value, typeCode);
            return convert;
        }
        catch
        {
            return Type.GetTypeCode(typeof(T)) == TypeCode.String ? (T) (object) string.Empty : default;
        }
    }

    /// <summary>
    ///     Get Property Name
    /// </summary>
    /// <returns>NameProperty</returns>
    public static string Name<T, TProp>(this T temp, Expression<Func<T, TProp>> propertySelector)
    {
        var body = (MemberExpression) propertySelector.Body;
        return body.Member.Name;
    }

    /// <summary>
    ///     Get Property FullName
    /// </summary>
    /// <returns>Class.NameProperty</returns>
    public static string FullName<T, TProp>(this T temp, Expression<Func<T, TProp>> propertySelector)
    {
        var body = (MemberExpression) propertySelector.Body;
        return $"{body.Member.DeclaringType.Name}.{body.Member.Name}";
    }

    public static string FullMethodName(this object value, [CallerMemberName] string methodName = "")
    {
        if (value == null) return "";
        var baseName = value.GetType().Name;
        return methodName.IsNotNullOrEmpty() ? $"{baseName}.{methodName}" : baseName;
    }

    public static string MethodName(this object value, [CallerMemberName] string methodName = "")
    {
        return value == null ? "" : methodName;
    }
}