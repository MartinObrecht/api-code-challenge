
using System.Text.RegularExpressions;

namespace codeChallenge.Domain.Extensions
{
    public static class StringExtensions
    {
        public static long ToLong(this string str, long? defaultValue = null)
        {
            try
            {
                var valid = Int64.TryParse(str, out long result);
                return valid ? Int64.Parse(str) : defaultValue ?? default;
            }
            catch
            {
                return defaultValue ?? default;
            }
        }

        public static string OnlyNumbers(this string param, string defaultValue = null) => String.IsNullOrEmpty(param)
        ? defaultValue
        : Regex.Replace(param, @"[^\d]", "");
    }
}