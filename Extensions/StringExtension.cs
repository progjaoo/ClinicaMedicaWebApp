using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.RegularExpressions;

namespace ClinicManageWebApp.Extensions
{
    public static class StringExtension
    {
        public static string SomenteCaracteres(this string input)
        {
            if(string.IsNullOrEmpty(input))
                return input;

            string pattern = @"[-\.\(\)\s]";

            string result = Regex.Replace(input, pattern, string.Empty); 
            
            return result;
        }
    }
}
