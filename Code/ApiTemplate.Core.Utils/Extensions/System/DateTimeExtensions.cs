using System.Collections.Generic;
using System.Globalization;

namespace System
{
    public static class DateTimeExtensions
    {
        public static int GetLastNumberOfYear(this DateTime date)
        {
            return date.Year % 10;
        }

        /// <summary>
        /// Obtiene la fecha de inicio de la semana siguiente a la fecha indicada
        /// </summary>
        /// <param name="date">
        /// Fecha desde la que se calculará la próxima semana
        /// </param>
        /// <param name="startOfWeek">
        /// Día de inicio de la semana. Por defecto Lunes
        /// </param>
        /// <returns>
        /// </returns>
        public static DateTime GetNextWeek(this DateTime date, DayOfWeek startOfWeek = DayOfWeek.Monday)
        {
            int daysToAdd = (((int)startOfWeek - (int)date.DayOfWeek + 7) % 7);
            daysToAdd = date.DayOfWeek == startOfWeek ? daysToAdd + 7 : daysToAdd;
            return date.AddDays(daysToAdd);
        }

        /// <summary>
        /// Obtiene el primer día del mes a partir de una fecha dada
        /// </summary>
        /// <param name="date">Fecha a partir de la cual se obtendrá el primer día del mes</param>
        /// <returns>Primer día del mes de la fecha dada</returns>
        public static DateTime GetFirstDayMonth(this DateTime date) => new DateTime(date.Year, date.Month, 1);

        /// <summary>
        /// Obtiene el último día del mes a partir de una fecha dada
        /// </summary>
        /// <param name="date">Fecha a partir de la cual se obtendrá el último día del mes</param>
        /// <returns>Último día del mes de la fecha dada</returns>
        public static DateTime GetLastDayMonth(this DateTime date)
        {
            DateTime firstDayOfMonth = date.GetFirstDayMonth();

            return firstDayOfMonth.AddMonths(1)
                                  .AddDays(-1);
        }

        /// <summary>
        /// Itera sobre los días de un mes, devolviendo la primera ocurrencia de un día de la semana en concreto
        /// </summary>
        /// <param name="date">Fecha de referencia con el mes a iterar</param>
        /// <param name="dayOfWeek">Día de la semana a buscar</param>
        /// <returns>Primera ocurrencia del día de la semana buscado</returns>
        public static DateTime GetFirstWeekDayOfMonth(this DateTime date, DayOfWeek dayOfWeek)
        {
            DateTime day = date.GetFirstDayMonth();

            while (day.DayOfWeek != dayOfWeek)
                day = day.AddDays(1);

            return day;
        }

        /// <summary>
        /// Obtiene un día de la semana determinado en una fecha dada
        /// </summary>
        /// <param name="date">Fecha en la que se buscará el día de la semana</param>
        /// <param name="dayOfWeek">Día de la semana a buscar</param>
        /// <returns>Día de la semana buscado</returns>
        public static DateTime GetWeekDay(this DateTime date, DayOfWeek dayOfWeek)
        {
            int searchedDayOfWeek = (int)dayOfWeek;
            int currentDayOfWeek = (int)date.DayOfWeek;

            int daysDifference = (currentDayOfWeek - searchedDayOfWeek) * -1;

            return date.AddDays(daysDifference);
        }

        /// <summary>
        /// Obtiene la hora de una fecha en formato "hh:mm tt", ignorando la cultura establecida
        /// </summary>
        /// <param name="date"></param>
        /// <returns>Hora en formato hh:mm tt</returns>
        public static string Get12Hour(this DateTime date) => date.ToString("hh:mm tt", CultureInfo.InvariantCulture);

        public static bool IsFutureDateTime(this DateTime date)
        {
            return date > DateTime.Now;
        }

        public static IEnumerable<DateTime> DaysBetween(this DateTime date, DateTime betweenDate)
        {
            if (date.Date == betweenDate.Date)
            {
                yield return date;
                yield break;
            }

            if (date < betweenDate)
            {
                for (var day = date; day.Date <= betweenDate.Date; day = day.AddDays(1))
                    yield return day;
            }
            else
            {
                for (var day = betweenDate; day.Date <= date.Date; day = day.AddDays(1))
                    yield return day;
            }
        }

        /// <summary>
        /// Devuelve la fecha solamente como cadena de un DateTime.
        /// </summary>
        /// <param name="date">DateTime del que extraer la fecha</param>
        /// <returns>Cadena con la fecha formateada</returns>
        public static string ToSimpleDateString(this DateTime date)
        {
            return date.ToString("dd/MM/yyyy");
        }

        /// <summary>
        /// Devuelve la hora solamente como cadena de un DateTime.
        /// </summary>
        /// <param name="date">DateTime del que extraer la hora</param>
        /// <returns>Cadena con la hora formateada</returns>
        public static string ToSimpleHourString(this DateTime date)
        {
            return date.ToString("HH:mm");
        }

        /// <summary>
        /// Obtiene el primer día del año a partir de una fecha dada
        /// </summary>
        /// <param name="date">Fecha a partir de la cual se obtendrá el primer día del año</param>
        /// <returns>Primer día del año de la fecha dada</returns>
        public static DateTime GetFirstDayYear(this DateTime date) => new DateTime(date.Year, 1, 1);

        /// <summary>
        /// Obtiene el primer día del año a partir de una fecha dada
        /// </summary>
        /// <param name="date">Fecha a partir de la cual se obtendrá el primer día del año</param>
        /// <returns>Primer día del año de la fecha dada</returns>
        public static DateTime GetLastDayYear(this DateTime date) => new DateTime(date.Year, 12, 31);

        /// <summary>
        /// Convierte una fecha UTC en su equivalente en España
        /// </summary>
        public static DateTime ToSpainDate(this DateTime date)
        {
            if (date.Kind != DateTimeKind.Utc)
                throw new InvalidOperationException("Input date is not an utc date");

            TimeZoneInfo spainZone = TimeZoneInfoHelper.GetSpainZoneInfo();
            return TimeZoneInfo.ConvertTimeFromUtc(date, spainZone);
        }

        public static DateTime GetFirstDayOfWeek(this DateTime date)
        {
            return date.GetWeekDay(DayOfWeek.Monday);
        }
    }
}