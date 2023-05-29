using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Utilities
{
    public static class Collection
    {
        /// <summary>
        /// Retrieves the longest string from a list, array and any other types
        /// of enumerables.
        /// </summary>
        public static string GetLongestStringAtList(IEnumerable<string> list) => list.Aggregate("", (max, cur) => max.Length > cur.Length ? max : cur);

        /// <summary>
        /// Retrieves the longest string from an enum. The "Type" passed as parameter
        /// must be an enum, so use typeof(yourEnum) as argument.
        /// </summary>
        public static string GetLongestStringAtEnum(Type enumType)
        {
            if (!enumType.IsEnum)
                throw new ArgumentException("O tipo fornecido deve ser um Enum.");

            var enumContents = Enum.GetNames(enumType);
                
            var longestString = GetLongestStringAtList(enumContents);
            return longestString;
        }

        /// <summary>
        /// Retrieves the longest string length from a list, array and any other types
        /// of enumerables.
        /// </summary>
        public static int GetLongestStringLengthAtList(IEnumerable<string> list) => GetLongestStringAtList(list).Length;

        /// <summary>
        /// Retrieves the longest string length from an enum. The "Type" passed as parameter
        /// must be an enum, so use typeof(yourEnum) as argument.
        /// </summary>
        public static int GetLongestStringLengthAtEnum(Type enumType) => GetLongestStringAtEnum(enumType).Length;

        /// <summary>
        /// Appends a String to all items inside a list at beginning.
        /// </summary>
        /// <param name="string"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<string> AppendStringAtBeginningFromItemsAtList(string @string, List<string> list) => list.Select(item => string.Concat(@string, item)).ToList();


        /// <summary>
        /// Appends a String to all items inside a list at end.
        /// </summary>
        /// <param name="string"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<string> AppendStringAtEndFromItemsAtList(string @string, List<string> list) => list.Select(item => string.Concat(item, @string)).ToList();
    }
}
