using System;
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
        // Read the last 4 bytes to get the length
        var lengthBuffer = new byte[4];
        Array.Copy(value, value.Length - 4, lengthBuffer, 0, 4);
        var uncompressedSize = BitConverter.ToInt32(lengthBuffer, 0);

        var buffer = new byte[uncompressedSize];
        using (var ms = new MemoryStream(value))
        using (var gzip = new GZipStream(ms, CompressionMode.Decompress))
            gzip.Read(buffer, 0, uncompressedSize);

        return Encoding.UTF8.GetString(buffer);
    }
}