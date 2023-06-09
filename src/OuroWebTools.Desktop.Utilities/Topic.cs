using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Utilities
{
    public class Topics<T> : List<Topic<T>>
    {
        public IEnumerable<string> ToOutput(Func<T, string> format)
            => this.SelectMany((topic, numerator) => topic.ToOutput(0, $"{numerator + 1}", format));
    }

    public class Topic<T> : List<Topic<T>>
    {
        private T Text { get; }

        public Topic(T value, params Topic<T>[] innerTopic)
        {
            Text = value;
            if (innerTopic != null) AddRange(innerTopic);
        }

        public IEnumerable<string> ToOutput(int depth, string numerator, Func<T, string> format)
        {
            var tabSize = depth + 1;

            yield return $"{new string(' ', tabSize)}{numerator}) {format(Text)}";

            var subTopics = this.SelectMany((topic, subNumerator) =>
                topic.ToOutput(tabSize, $"{numerator}.{subNumerator + 1}", format));
            foreach (var topic in subTopics) yield return topic;
        }
    }
}
