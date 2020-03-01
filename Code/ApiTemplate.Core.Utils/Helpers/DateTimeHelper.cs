using System;

namespace ApiTemplate.Core.Utils.Helpers
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Obtiene el primer día del año actual
        /// </summary>
        /// <returns>Primer día del año</returns>
        public static DateTime GetFirstDayOfYear() => GetFirstDayOfYear(DateTime.Today.Year);

        /// <summary>
        /// Obtiene el primer día de un año dado
        /// </summary>
        /// <param name="year">Año del cual se quiere obtener el primer día</param>
        /// <returns>Primer día del año en cuestión</returns>
        public static DateTime GetFirstDayOfYear(int year) => new DateTime(year, 1, 1);

        /// <summary>
        /// Obtiene el último día del año actual
        /// </summary>
        /// <returns>Último día del año</returns>
        public static DateTime GetLastDayOfYear() => GetLastDayOfYear(DateTime.Today.Year);

        /// <summary>
        /// Obtiene el último día de un año dado
        /// </summary>
        /// <param name="year">Año del cual se quiere obtener el último día</param>
        /// <returns>Último día del año en cuestión</returns>
        public static DateTime GetLastDayOfYear(int year) => new DateTime(year, 12, 31);
    }
}