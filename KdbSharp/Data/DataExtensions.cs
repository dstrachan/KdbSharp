using System;

namespace KdbSharp.Data
{
    public static class DataExtensions
    {
        private static readonly DateTime _epoch = new DateTime(2000, 1, 1);

        public static DateTime ToDate(this int days) => _epoch.AddDays(days);
        public static DateTime ToDatetime(this double days) => _epoch.AddDays(days);
        public static DateTime ToMinute(this int minutes) => _epoch.AddMinutes(minutes);
        public static DateTime ToMonth(this int months) => _epoch.AddMonths(months);
        public static DateTime ToSecond(this int seconds) => _epoch.AddSeconds(seconds);
        public static DateTime ToTime(this int milliseconds) => _epoch.AddMilliseconds(milliseconds);
        public static TimeSpan ToTimespan(this long nanoseconds) => TimeSpan.FromTicks(nanoseconds / 100);
        public static DateTime ToTimestamp(this long nanoseconds) => _epoch.AddTicks(nanoseconds / 100);
    }
}
