using System.Text;
using System.Text.RegularExpressions;

namespace Domain.Helpers;

public static class StringExtensions
{
    public static bool EqualsIgnoreCaseAndAccents(this string str, string other)
    {
        string Normalize(string s) =>
            Regex.Replace(s.Normalize(NormalizationForm.FormD), @"\p{Mn}", "");
        
        return string.Equals(Normalize(str), Normalize(other), StringComparison.OrdinalIgnoreCase);
    }
}