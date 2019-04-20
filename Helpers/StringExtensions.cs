using System;

namespace RestaurantSearch.UITests.Helpers
{
    public static class StringExtensions
    {
        public static bool ContainsString(this string source, string toCheck, StringComparison comp)
        {
            return source?.IndexOf(toCheck, comp) >= 0;
        }
    }
}
