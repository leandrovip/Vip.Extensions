using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

public static partial class Methods
{
    public static string TrimVip(this string value)
    {
        return value?.Trim() ?? string.Empty;
    }

    public static bool IsNullOrEmpty(this string value)
    {
        value = value.TrimVip();
        return string.IsNullOrWhiteSpace(value);
    }

    public static bool IsNotNullOrEmpty(this string value)
    {
        return !value.IsNullOrEmpty();
    }

    public static string OnlyNumbers(this string value)
    {
        return value.TrimVip().IsNullOrEmpty()
            ? string.Empty
            : new string(value.Where(char.IsDigit).ToArray());
    }

    public static string RemoveAccent(this string value)
    {
        if (value.IsNullOrEmpty()) return string.Empty;

        const string withAccent = "ÄÅÁÂÀÃäáâàãÉÊËÈéêëèÍÎÏÌíîïìÖÓÔÒÕöóôòõÜÚÛüúûùÇç&º°ª";
        const string withoutAccent = "AAAAAAaaaaaEEEEeeeeIIIIiiiiOOOOOoooooUUUuuuuCcE   ";

        for (var i = 0; i < withAccent.Length; i++) value = value.Replace(withAccent[i].ToString(), withoutAccent[i].ToString());
        return value;
    }

    public static string RemoveSpecialChars(this string value)
    {
        if (value.IsNullOrEmpty()) return string.Empty;

        const string caracteresEspeciais = @"@§\><{}[]^~ºª*+!#$'¬¨&%";
        value = caracteresEspeciais.Aggregate(value, (current, t) => current.Replace(t.ToString(), ""));

        return value.TrimVip();
    }

    public static string RemoveZeroLeft(this string value)
    {
        return value.IsNullOrEmpty() ? string.Empty : value.TrimStart('0');
    }

    public static string JoinStringAndFill(this string value, string textJoin, char charFill, int length)
    {
        if (length <= 0) return string.Empty;
        if (charFill.IsNull()) charFill = ' ';

        var dif = length - (textJoin.Length + value.Length);

        string result;
        if (dif > 0)
            result = value + new string(charFill, dif) + textJoin;
        else
            result = value.Substring(0, value.Length - Math.Abs(dif - 1)) + " " + textJoin;

        return result;
    }

    public static string StringFill(this string value, int length, char with = ' ', bool left = true)
    {
        if (value.IsNullOrEmpty()) value = string.Empty;

        if (value.Length > length)
        {
            value = value.Remove(length);
        }
        else
        {
            length -= value.Length;

            if (left)
                value = new string(with, length) + value;
            else
                value += new string(with, length);
        }

        return value;
    }

    public static string FillRight(this string value, int length, char with = ' ')
    {
        return value.StringFill(length, with);
    }

    public static string FillLeft(this string value, int length, char with = ' ')
    {
        if (value.IsNull()) return string.Empty;
        return value.StringFill(length, with, false);
    }

    public static string ZeroFill(this string value, int length)
    {
        if (value.Length > length) return value;
        return value.OnlyNumbers().StringFill(length, '0');
    }

    public static string Center(this string value, int length, char charFill = ' ')
    {
        return value.PadLeft((length - value.Length) / 2 + value.Length, charFill).PadRight(length, charFill);
    }

    public static string SplitAndFillByLength(this string str, int length, string separator)
    {
        var listString = new List<string>();
        var index = 0;

        while (index + length < str.Length)
        {
            listString.Add(str.Substring(index, length));
            index += length;
        }

        listString.Add(str.Substring(index));

        return string.Join(separator, listString);
    }

    public static string Right(this string value, int length)
    {
        if (length > value.Length) length = value.Length;
        return value.Substring(value.Length - length);
    }

    public static string Truncate(this string value, int maxLength)
    {
        return value?.Substring(0, Math.Min(value.Length, maxLength));
    }

    public static decimal ToDecimal(this string value, decimal valueDefault = 0)
    {
        value = value.Replace("R$", "").Replace("%", "").Replace(" ", "");
        decimal.TryParse(value, out var result);
        return result != 0 ? result : valueDefault;
    }

    public static float ToFloat(this string value, float valueDefault = 0)
    {
        value = value.Replace("R$", "").Replace("%", "").Replace(" ", "");
        float.TryParse(value, out var result);
        return result != 0 ? result : valueDefault;
    }

    public static int ToInt(this string value, int valueDefault = 0)
    {
        value = value.OnlyNumbers();
        int.TryParse(value, out var result);
        return result != 0 ? result : valueDefault;
    }

    public static T TryParse<T>(this string input)
    {
        try
        {
            var converter = TypeDescriptor.GetConverter(typeof(T));
            return (T) converter.ConvertFromString(input);
        }
        catch (NotSupportedException)
        {
            return default;
        }
    }

    /// <summary>
    ///     Verifica se um código é um GTIN (8,12,13,14) válido
    /// </summary>
    /// <param name="value">Código</param>
    /// <returns><b>true</b> caso for válido</returns>
    public static bool IsGtin(this string value)
    {
        var code = value.OnlyNumbers();
        var validCodes = new[] {8, 12, 13, 14};
        if (!validCodes.Contains(code.Length)) return false;
        if (code.IsNullOrEmpty()) return false;

        code = code.ZeroFill(14);
        var digit = code[13] - '0';
        code = code.Substring(0, 13);

        var sum = 0;
        var factor = 3;

        foreach (var dig in code)
        {
            sum += (dig - '0') * factor;
            factor = factor == 3 ? 1 : 3;
        }

        var check = (10 - sum % 10) % 10;
        return check == digit;
    }

    public static byte[] ToUTF8Bytes(this string value)
    {
        return Encoding.UTF8.GetBytes(value);
    }

    public static void SafelyWriteToFile(this string value, string filePath, bool overwrite = true)
    {
        var mutexId = $"Global\\{{{Path.GetFileNameWithoutExtension(filePath)}}}";

        using (var mutex = new Mutex(false, mutexId))
        {
            var hasHandle = false;

            try
            {
                hasHandle = mutex.WaitOne(Timeout.Infinite, false);

                if (overwrite)
                    File.WriteAllText(filePath, value);
                else
                    File.AppendAllText(filePath, value);
            }
            finally
            {
                if (hasHandle)
                    mutex.ReleaseMutex();
            }
        }
    }
}