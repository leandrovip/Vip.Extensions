using System.IO;

public static partial class Methods
{
    public static MemoryStream AsMemoryStream(this byte[] bytes)
    {
        return new MemoryStream(bytes);
    }
}