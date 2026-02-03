using System;

public static class TimeProvider
{
    public static Func<DateTime> UtcNow = () => DateTime.UtcNow;
}
