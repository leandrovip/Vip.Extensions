public static partial class Methods
{
    public static int NotZeroOrLower(this int value)
    {
        return value <= 0 ? 1 : value;
    }

    public static int NotNegative(this int value, int defaultValue = 0)
    {
        if (defaultValue < 0) defaultValue = 0;
        return value < 0 ? defaultValue : value;
    }

    public static decimal Division(this int numerator, decimal denominator)
    {
        return denominator == 0 ? 0 : (numerator / denominator).Round();
    }
}