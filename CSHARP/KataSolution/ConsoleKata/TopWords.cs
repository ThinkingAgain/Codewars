using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleKata
{
    class TopWords
    {
        /// <summary>
        /// Most frequently used words in a text
        /// ================================
        /// Write a function that, given a string of text (possibly with punctuation and 
        /// line-breaks), returns an array of the top-3 most occurring words, in descending 
        /// order of the number of occurrences.
        /// ----------------------------------------------------------
        /// Assumptions:
        /// A word is a string of letters(A to Z) optionally containing one or more apostrophes(') 
        /// in ASCII. (No need to handle fancy punctuation.)
        /// Matches should be case-insensitive, and the words in the result should be lowercased.
        /// Ties may be broken arbitrarily.
        /// If a text contains fewer than three unique words, then either the top-2 or top-1 words 
        /// should be returned, or an empty array if a text contains no words.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static List<string> Top3(string s)
        {
            List<string> words = new List<string>();
            int h = 0;
            for (int i = 0; i < s.Length; i++)
            {
               if (!char.IsLetter(s[i]) && s[i] != '\'')
                {
                    if (i > h)
                    {
                        string word = s.Substring(h, i - h);
                        if (char.IsLetter(word[0])) words.Add(word.ToLower());
                    }
                    h = i + 1;
                }                    
            }
            if (h < s.Length) words.Add(s.Substring(h).ToLower());
            var query = words.GroupBy(w => w)
                .OrderByDescending(g => g.Count())
                .Select(w => w.Key)
                .ToList();           
            return query.Count < 3 ? query 
                : new List<string>() { query[0], query[1]??null, query[2]??null };
        }

        public static List<string> test(string s)
        {
            var alphabets = new HashSet<char>(Enumerable.Range('a', 26).Select(i => (char)i));
            var separators = Enumerable.Range(0, 256).Select(i => (char)i).Where(c => !alphabets.Contains(c) && c != '\'').ToArray();

            var res = s.ToLower().Split(separators, StringSplitOptions.RemoveEmptyEntries)
                  .Select(word => new string(word.Where(alphabets.Append('\'').Contains).ToArray()))
                  .Where(word => alphabets.Any(word.Contains))
                  //.GroupBy(word => word)
                 // .OrderByDescending(group => group.Count())
                 // .Take(3)
                 // .Select(group => group.Key)
                  .ToList();
            return res;
        }


    }
}
