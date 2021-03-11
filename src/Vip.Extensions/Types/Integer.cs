public static partial class Methods
{
    public static int NotZeroOrLower(this int value)
    {
        return value <= 0 ? 1 : value;
    }
}