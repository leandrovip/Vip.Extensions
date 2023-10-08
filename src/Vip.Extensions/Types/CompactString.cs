using System.IO;
using System.IO.Compression;
using System.Text;

public static partial class Methods
{
    public static byte[] ZipString(this string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        using (var mso = new MemoryStream())
        {
            using (var gs = new GZipStream(mso, CompressionMode.Compress))
                gs.Write(bytes, 0, bytes.Length);

            return mso.ToArray();
        }
    }

    public static string UnzipString(this byte[] value)
    {
        using (var memoryStream = new MemoryStream(value))
        using (var gZipStream = new GZipStream(memoryStream, CompressionMode.Decompress))
        using (var resultStream = new MemoryStream())
        {
            var buffer = new byte[4096];
            int bytesRead;
            while ((bytesRead = gZipStream.Read(buffer, 0, buffer.Length)) > 0) resultStream.Write(buffer, 0, bytesRead);

            return Encoding.UTF8.GetString(resultStream.ToArray());
        }
    }
}