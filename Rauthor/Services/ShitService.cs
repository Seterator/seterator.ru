using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Rauthor.Services
{
    public class ShitService
    {
        static public IEnumerable<string> FilteredWords => new[]
        {
            "хуй",
            "пизда",
            "писюн",
            "Пизда",
            "блять",
            "ебу",
        };
        static public string Mask(string input)
        {
            var result = input;
            FilteredWords.ToList().ForEach(filtered =>
            {
                result = result.Replace(filtered, Times("*", filtered.Length), StringComparison.OrdinalIgnoreCase);
            });
            return result;
        }
        static string Times(string s, int times)
        {
            var result = "";
            for (int i = 0; i < times; i++)
            {
                result += s;
            }
            return s;
        }
    }
}
