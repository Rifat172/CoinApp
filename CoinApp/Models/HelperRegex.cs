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
        public static string ReplaceSpace(string input)
        {
            return Regex.Replace(input, @"\s+", "");
        }
    }
}