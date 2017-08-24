using System;
using System.Collections.Generic;
using System.Linq;

namespace IndependentUtils.Tools.Extensions
{
    public static class StringExtensions
    {
        private const int DefaultMaxLineSize = 60;

        private static readonly IEnumerable<char> _wordEndingValues = " \n\t";

        /// <summary>
        /// Tries to get the char at the index. If the index is larger than the
        /// string's size, null is returned.
        /// </summary>
        public static char? TryGetChar(this string stringValue, int idx)
        {
            if (stringValue == null)
            {
                throw new ArgumentNullException("stringValue");
            }

            if (idx >= stringValue.Length)
            {
                return null;
            }
            return stringValue[idx];
        }

        public static IEnumerable<string> SplitText(this string text, 
            int maxLineSize = DefaultMaxLineSize)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            return text
                .Split('\n')
                .SelectMany(t => t.SplitByLineSize(maxLineSize))
                .Select(t => t.Trim());
        }

        /// <summary>
        /// Splits the string into lines with the maxLineSize as specified.
        /// </summary>
        /// <param name="text">The text to split.</param>
        /// <param name="maxLineSize">The maximum amount of characters per line.</param>
        public static IEnumerable<string> SplitByLineSize(this string text, 
            int maxLineSize = DefaultMaxLineSize)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }

            var lastLineLimit = 0;
            var currLineLimit = maxLineSize;

            while (true)
            {
                var charAtLimit = text.TryGetChar(currLineLimit);
                if (charAtLimit == null)
                {
                    // Ending condition reached, this is the last line.
                    yield return text.Substring(lastLineLimit);
                    break;
                }

                // Find where the last word ends.
                while (!_wordEndingValues.Contains(charAtLimit.Value))
                {
                    // Fall back the word until the last one is found.
                    currLineLimit--;
                    charAtLimit = text.TryGetChar(currLineLimit);

                    if (currLineLimit == lastLineLimit)
                    {
                        // Word is larger than the max line size.
                        throw new InvalidOperationException(
                            "Current word is larger sthan the maxLineSize");
                    }
                }

                yield return text.Substring(lastLineLimit, currLineLimit - lastLineLimit);

                lastLineLimit = currLineLimit;
                currLineLimit += maxLineSize;
            }
        }

        public static string RemovePrefix(this string value, string prefix)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (prefix == null)
            {
                return value;
            }
            if (value.StartsWith(prefix))
            {
                return value.Substring(prefix.Length);
            }
            return value;
        }

        public static string RemoveSuffix(this string value, string suffix)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            if (suffix == null)
            {
                return value;
            }
            if (value.EndsWith(suffix))
            {
                return value.Substring(0, value.Length - suffix.Length);
            }
            return value;
        }
    }
}
