using System.Text.RegularExpressions;

namespace CoinApp.Models
{
    public static class HelperRegex
    {
        /// <summary>
        /// Удаляет все пробелы в строке
        /// </summary>
        /// <param name="input">Входная строка</param>
        /// <returns></returns>
        public static string RemoveSpace(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
        public static bool IsCorrectlyEmail(string Email)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (Regex.IsMatch(Email, pattern, RegexOptions.IgnoreCase))
                return true;
            return false;
        }
        public static bool IsCorrectlyPassword(string password)
        {
            string pattern = @"\s+";
            if (Regex.IsMatch(password, pattern, RegexOptions.IgnoreCase))
                return false;
            return true;
        }
    }
}