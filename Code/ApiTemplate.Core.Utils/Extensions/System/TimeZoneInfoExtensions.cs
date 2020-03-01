namespace System
{
    public static class TimeZoneInfoHelper
    {
        public static TimeZoneInfo GetSpainZoneInfo()
        {
            TimeZoneInfo spainZone;
            try
            {
                spainZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            }
            catch (TimeZoneNotFoundException)
            {
                spainZone = TimeZoneInfo.FindSystemTimeZoneById("Europe/Madrid");
            }
            return spainZone;
        }
    }
}