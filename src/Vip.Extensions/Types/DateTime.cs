using System;

public static partial class Methods
{
    public static int DaysDiff(this DateTime startDate, DateTime endDate)
    {
        return endDate < startDate ? 0 : (endDate - startDate).Days;
    }

    public static DateTime AddDays(this DateTime date, double days, bool onlyWorkDays)
    {
        var dateAdd = date.AddDays(days);

        if (onlyWorkDays)
            switch (dateAdd.DayOfWeek)
            {
                case DayOfWeek.Sunday: return dateAdd.AddDays(1);
                case DayOfWeek.Saturday: return dateAdd.AddDays(2);
            }

        return dateAdd;
    }

    public static string TimeDiff(this DateTime startDate, DateTime endDate)
    {
        return $"{endDate - startDate:hh\\:mm\\:ss}";
    }

    public static bool BetweenIn(this DateTime date, DateTime startDate, DateTime endDate)
    {
        return startDate <= date && endDate >= date;
    }

    public static bool IsLowerOrEqualToday(this DateTime date)
    {
        return date <= DateTime.Today;
    }

    public static DateTime DateInitial(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
    }

    public static DateTime DateEnd(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, 23, 59, 59);
    }

    public static int DaysInMonth(this DateTime date)
    {
        return DateTime.DaysInMonth(date.Year, date.Month);
    }

    public static DateTime FirstDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, 1);
    }

    public static DateTime LastDayOfMonth(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.DaysInMonth());
    }
}