using System;
using System.Security.Cryptography;
using System.Text;

public static partial class Methods
{
    #region Propriedades

    private const string defaultCryptoKey = "vipKey@0803#Crypto";
    private static readonly byte[] IV = {240, 3, 45, 29, 0, 76, 173, 59};

    #endregion

    #region Métodos Estáticos

    public static string Encrypt(this string value, string cryptoKey)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        cryptoKey = cryptoKey.IsNullOrEmpty() ? defaultCryptoKey : cryptoKey;

        try
        {
            var buffer = Encoding.ASCII.GetBytes(value);
            var des = new TripleDESCryptoServiceProvider();
            var MD5 = new MD5CryptoServiceProvider();

            des.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(cryptoKey));
            des.IV = IV;

            var result = Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            return result;
        }
        catch
        {
            return string.Empty;
        }
    }

    public static string Decrypt(this string value, string cryptoKey)
    {
        if (string.IsNullOrEmpty(value)) return string.Empty;
        cryptoKey = cryptoKey.IsNullOrEmpty() ? defaultCryptoKey : cryptoKey;

        try
        {
            var buffer = Convert.FromBase64String(value);
            var des = new TripleDESCryptoServiceProvider();
            var MD5 = new MD5CryptoServiceProvider();

            des.Key = MD5.ComputeHash(Encoding.ASCII.GetBytes(cryptoKey));
            des.IV = IV;

            var result = Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            return result;
        }
        catch
        {
            return string.Empty;
        }
    }

    #endregion
}