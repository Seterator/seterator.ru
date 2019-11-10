using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rauthor.Services
{
    public class FoulLanguageFilter
    {
        private string replaceChar;

        public FoulLanguageFilter(string replaceChar)
        {
            this.replaceChar = replaceChar;
        }
        
        public virtual IEnumerable<string> FilteredWords => new[]
        {
            "хуй",
            "пизда",
            "писюн",
            "Пизда",
            "блять",
            "ебу",
        };

        public string Mask(string input)
        {
            var result = input;
            FilteredWords.ToList().ForEach(filtered =>
            {
                result = result.Replace(filtered, Times("*", filtered.Length), StringComparison.OrdinalIgnoreCase);
            });
            return result;
        }

        /// <summary>
        /// Возвращает строку <paramref name="s"/> повторённую <paramref name="times"/> раз.
        /// </summary>
        static string Times(string s, int times)
        {
            var result = new StringBuilder(capacity: times * s.Length);
            for (int i = 0; i < times; i++)
            {
                result.Append(s);
            }
            return result.ToString();
        }
    }
}
