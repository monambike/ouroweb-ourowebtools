using System;

namespace Common.Utilities
{
    public static class String
    {
        public static string TruncateString(string value, int maxLength)
        {
            return !string.IsNullOrEmpty(value)
                ? value.Substring(0, Math.Min(value.Length, maxLength)) : value;
        }
    }
}
