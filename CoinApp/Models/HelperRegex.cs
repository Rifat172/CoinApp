using System.Text.RegularExpressions;

namespace CoinApp.Models
{
    public static class HelperRegex
    {
        public static bool IsCorrectlyEmail(string Email)
        {
            string pattern = @"^(?("")(""[^""]+?""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9]{2,17}))$";
            if (Regex.IsMatch(Email, pattern, RegexOptions.IgnoreCase))
                return true;
            return false;
        }
    }
}