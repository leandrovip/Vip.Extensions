using System.Linq;

public static partial class Methods
{
    public static bool IsNull(this object value) => value == null;
    public static bool IsNotNull(this object value) => value != null;
    public static bool IsNullOrEmpty(this object value) => value.IsNull() || value.ToString().IsNullOrEmpty();
    public static bool IsNotNullOrEmpty(this object value) => !value.IsNullOrEmpty();

    public static T GetPropertyValue<T>(this object value, string propertyName)
    {
        if (value == null) return default;

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

        return (T) result;
    }
}