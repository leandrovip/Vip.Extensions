using System;
using System.Globalization;

public static partial class Methods
{
    public static decimal NotZeroOrLower(this decimal value)
    {
        return value <= 0 ? 1 : value;
    }

    public static decimal NotNegative(this decimal value, decimal defaultValue = 0)
    {
        return value < 0 ? defaultValue : value;
    }

    public static decimal Division(this decimal numerator, decimal denominator)
    {
        return denominator == 0 ? 0 : numerator / denominator;
    }

    public static decimal Truncate(this decimal value, int precision)
    {
        var step = (decimal) Math.Pow(10, precision);
        var tmp = Math.Truncate(step * value);
        return tmp / step;
    }

    public static decimal Round(this decimal value, int decimals = 2)
    {
        return decimals == 0 ? decimal.Round(value) : decimal.Round(value, decimals);
    }

    public static decimal ToPercent(this decimal value, decimal percentage)
    {
        return value * percentage / 100m;
    }

    public static decimal ToAbs(this decimal value)
    {
        return Math.Abs(value);
    }

    public static string ToExtension(this decimal amount)
    {
        if ((amount <= 0) | (amount >= 1000000000000000))
            return "Valor não suportado";

        var strValor = amount.ToString("000000000000000.00");

        var valueExtension = string.Empty;

        for (var i = 0; i <= 15; i += 3)
        {
            valueExtension += PrintExtension(Convert.ToDecimal(strValor.Substring(i, 3)));

            if ((i == 0) & (valueExtension != string.Empty))
            {
                if (Convert.ToInt32(strValor.Substring(0, 3)) == 1)
                    valueExtension += " TRILHÃO" + (Convert.ToDecimal(strValor.Substring(3, 12)) > 0 ? " E " : string.Empty);
                else if (Convert.ToInt32(strValor.Substring(0, 3)) > 1)
                    valueExtension += " TRILHÕES" + (Convert.ToDecimal(strValor.Substring(3, 12)) > 0 ? " E " : string.Empty);
            }
            else
            {
                if ((i == 3) & (valueExtension != string.Empty))
                {
                    if (Convert.ToInt32(strValor.Substring(3, 3)) == 1)
                        valueExtension += " BILHÃO" + (Convert.ToDecimal(strValor.Substring(6, 9)) > 0 ? " E " : string.Empty);
                    else if (Convert.ToInt32(strValor.Substring(3, 3)) > 1)
                        valueExtension += " BILHÕES" + (Convert.ToDecimal(strValor.Substring(6, 9)) > 0 ? " E " : string.Empty);
                }
                else
                {
                    if ((i == 6) & (valueExtension != string.Empty))
                    {
                        if (Convert.ToInt32(strValor.Substring(6, 3)) == 1)
                            valueExtension += " MILHÃO" + (Convert.ToDecimal(strValor.Substring(9, 6)) > 0 ? " E " : string.Empty);
                        else if (Convert.ToInt32(strValor.Substring(6, 3)) > 1)
                            valueExtension += " MILHÕES" + (Convert.ToDecimal(strValor.Substring(9, 6)) > 0 ? " E " : string.Empty);
                    }
                    else
                    {
                        if ((i == 9) & (valueExtension != string.Empty))
                            if (Convert.ToInt32(strValor.Substring(9, 3)) > 0)
                                valueExtension += " MIL" + (Convert.ToDecimal(strValor.Substring(12, 3)) > 0 ? " E " : string.Empty);
                    }
                }
            }

            if (i == 12)
            {
                if (valueExtension.Length > 8)
                    if ((valueExtension.Substring(valueExtension.Length - 6, 6) == "BILHÃO") |
                        (valueExtension.Substring(valueExtension.Length - 6, 6) == "MILHÃO"))
                        valueExtension += " DE";
                    else if ((valueExtension.Substring(valueExtension.Length - 7, 7) == "BILHÕES") |
                             (valueExtension.Substring(valueExtension.Length - 7, 7) == "MILHÕES") |
                             (valueExtension.Substring(valueExtension.Length - 8, 7) == "TRILHÕES"))
                        valueExtension += " DE";
                    else if (valueExtension.Substring(valueExtension.Length - 8, 8) == "TRILHÕES")
                        valueExtension += " DE";

                if (Convert.ToInt64(strValor.Substring(0, 15)) == 1)
                    valueExtension += " REAL";
                else if (Convert.ToInt64(strValor.Substring(0, 15)) > 1)
                    valueExtension += " REAIS";

                if (Convert.ToInt32(strValor.Substring(16, 2)) > 0 && valueExtension != string.Empty)
                    valueExtension += " E ";
            }

            if (i == 15)
                if (Convert.ToInt32(strValor.Substring(16, 2)) == 1)
                    valueExtension += " CENTAVO";
                else if (Convert.ToInt32(strValor.Substring(16, 2)) > 1)
                    valueExtension += " CENTAVOS";
        }

        return valueExtension;
    }

    private static string PrintExtension(decimal amount)
    {
        if (amount <= 0)
            return string.Empty;

        var valuePrint = string.Empty;

        if ((amount > 0) & (amount < 1))
            amount *= 100;

        var strValor = amount.ToString("000");
        var a = Convert.ToInt32(strValor.Substring(0, 1));
        var b = Convert.ToInt32(strValor.Substring(1, 1));
        var c = Convert.ToInt32(strValor.Substring(2, 1));

        switch (a)
        {
            case 1:
                valuePrint += b + c == 0 ? "CEM" : "CENTO";
                break;
            case 2:
                valuePrint += "DUZENTOS";
                break;
            case 3:
                valuePrint += "TREZENTOS";
                break;
            case 4:
                valuePrint += "QUATROCENTOS";
                break;
            case 5:
                valuePrint += "QUINHENTOS";
                break;
            case 6:
                valuePrint += "SEISCENTOS";
                break;
            case 7:
                valuePrint += "SETECENTOS";
                break;
            case 8:
                valuePrint += "OITOCENTOS";
                break;
            case 9:
                valuePrint += "NOVECENTOS";
                break;
        }

        switch (b)
        {
            case 1 when c == 0:
                valuePrint += (a > 0 ? " E " : string.Empty) + "DEZ";
                break;
            case 1 when c == 1:
                valuePrint += (a > 0 ? " E " : string.Empty) + "ONZE";
                break;
            case 1 when c == 2:
                valuePrint += (a > 0 ? " E " : string.Empty) + "DOZE";
                break;
            case 1 when c == 3:
                valuePrint += (a > 0 ? " E " : string.Empty) + "TREZE";
                break;
            case 1 when c == 4:
                valuePrint += (a > 0 ? " E " : string.Empty) + "QUATORZE";
                break;
            case 1 when c == 5:
                valuePrint += (a > 0 ? " E " : string.Empty) + "QUINZE";
                break;
            case 1 when c == 6:
                valuePrint += (a > 0 ? " E " : string.Empty) + "DEZESSEIS";
                break;
            case 1 when c == 7:
                valuePrint += (a > 0 ? " E " : string.Empty) + "DEZESSETE";
                break;
            case 1 when c == 8:
                valuePrint += (a > 0 ? " E " : string.Empty) + "DEZOITO";
                break;
            case 1:
            {
                if (c == 9) valuePrint += (a > 0 ? " E " : string.Empty) + "DEZENOVE";
                break;
            }
            case 2:
                valuePrint += (a > 0 ? " E " : string.Empty) + "VINTE";
                break;
            case 3:
                valuePrint += (a > 0 ? " E " : string.Empty) + "TRINTA";
                break;
            case 4:
                valuePrint += (a > 0 ? " E " : string.Empty) + "QUARENTA";
                break;
            case 5:
                valuePrint += (a > 0 ? " E " : string.Empty) + "CINQUENTA";
                break;
            case 6:
                valuePrint += (a > 0 ? " E " : string.Empty) + "SESSENTA";
                break;
            case 7:
                valuePrint += (a > 0 ? " E " : string.Empty) + "SETENTA";
                break;
            case 8:
                valuePrint += (a > 0 ? " E " : string.Empty) + "OITENTA";
                break;
            case 9:
                valuePrint += (a > 0 ? " E " : string.Empty) + "NOVENTA";
                break;
        }

        if ((strValor.Substring(1, 1) != "1") & (c != 0) & (valuePrint != string.Empty)) valuePrint += " E ";

        if (strValor.Substring(1, 1) != "1")
            switch (c)
            {
                case 1:
                    valuePrint += "UM";
                    break;
                case 2:
                    valuePrint += "DOIS";
                    break;
                case 3:
                    valuePrint += "TRÊS";
                    break;
                case 4:
                    valuePrint += "QUATRO";
                    break;
                case 5:
                    valuePrint += "CINCO";
                    break;
                case 6:
                    valuePrint += "SEIS";
                    break;
                case 7:
                    valuePrint += "SETE";
                    break;
                case 8:
                    valuePrint += "OITO";
                    break;
                case 9:
                    valuePrint += "NOVE";
                    break;
            }

        return valuePrint;
    }

    public static string ToStringSql(this decimal value)
    {
        return value.ToString(CultureInfo.InstalledUICulture).Replace(",", ".");
    }
}