using System.Globalization;
using System.Text;

namespace Shared.Helpers
{
    public static class AppHelper
    {
        public static string RemoveDiacritics(string input)
        {
            string normalized = input.Normalize(NormalizationForm.FormD);
            char[] chars = normalized
                .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                .ToArray();
            return new string(chars).Normalize(NormalizationForm.FormC).ToLower();
        }

        public static List<string> ParseSearchQuery(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return new List<string>();
            return query.Split('+').Select(RemoveDiacritics).ToList();
        }
    }
}
