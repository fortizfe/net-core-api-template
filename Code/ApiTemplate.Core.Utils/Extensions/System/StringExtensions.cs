using System.Globalization;
using System.Text.RegularExpressions;

namespace System
{
    public static class StringExtensions
    {
        #region Public Methods

        public static bool IsDecimal(this string cadena)
        {
            return decimal.TryParse(cadena, out _);
        }

        public static bool IsDecimalWithNDecimals(this string cadena, int n = 2)
        {
            return decimal.TryParse(cadena, out _) && cadena.IsNumberWithZeroOrNDecimals(n);
        }

        public static bool IsInteger(this string cadena)
        {
            return int.TryParse(cadena, out _);
        }

        public static bool IsLong(this string cadena)
        {
            return long.TryParse(cadena, out _);
        }

        public static bool IsNumberWithZeroOrNDecimals(this string cadena, int n = 2)
        {
            var pattern = @"^\d+([\,\.]\d{1," + n.ToString() + "}$)?$";
            return Regex.IsMatch(cadena, pattern);
        }

        public static bool IsValidDate(this string s, string format)
        {
            return DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        public static bool IsValidHour(this string s, string format)
        {
            return DateTime.TryParseExact(s, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }

        public static decimal? ToNullableDecimal(this string cadena)
        {
            return decimal.TryParse(cadena, out decimal result) ? result : (decimal?)null;
        }

        public static int? ToNullableInt(this string cadena)
        {
            return int.TryParse(cadena, out int result) ? result : (int?)null;
        }

        /// <summary>
        /// Atajo para el método string.IsNullOrEmpty
        /// </summary>
        /// <param name="input">Cadena a evaluar</param>
        /// <returns>Resultado de la llamada a string.IsNullOrEmpty</returns>
        public static bool IsNil(this string input) => string.IsNullOrEmpty(input);

        /// <summary>
        /// Atajo para la negación del método IsNil
        /// </summary>
        /// <param name="input">Cadena a evaluar</param>
        /// <see cref="IsNil(string)"></see>
        /// <returns>Resultado de la negación de la llamada a IsNil</returns>
        public static bool NotNil(this string input) => !IsNil(input);

        #endregion Public Methods
    }
}