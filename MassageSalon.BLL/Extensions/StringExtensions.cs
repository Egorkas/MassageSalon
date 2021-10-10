using System;
using System.Collections.Generic;
using System.Text;

namespace MassageSalon.BLL.Extensions
{
    public static class StringExtensions
    {
        public static string NormalizedSearchString(this string serach)
        {
            return serach.Replace(",", "")
                         .Replace(".", "")
                         .Replace("?", "")
                         .Replace("/", "")
                         .Replace("\\", "")
                         .Trim();
        }
    }
}
