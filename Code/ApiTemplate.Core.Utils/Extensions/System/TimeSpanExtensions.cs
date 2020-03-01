namespace System
{
    public static class TimeSpanExtensions
    {
        /// <summary>
        /// Convierte un TimeSpan en cadena de texto con total horas y minutos. HH:mm
        /// </summary>
        /// <param name="timeSpan">TimeSpan a convertir</param>
        /// <returns>Cadena con horas y minutos</returns>
        public static string ToHourMinuteString(this TimeSpan timeSpan)
        {
            return $"{(timeSpan.TotalHours < 0 ? "-" : "")}{Math.Floor(Math.Abs(timeSpan.TotalHours))}h {(timeSpan.Minutes != 0 ? $"{Math.Abs(timeSpan.Minutes)}m" : "")}";
        }
    }
}
