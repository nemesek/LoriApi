using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain
{
    public class AnswerParser
    {
        private List<string> _possibleAnswers = new List<string>
        {
            "Yes, Let's Go",
            "Yes, I Could Actually",
            "No",
            "I Wish, been trying to get that raise for a few years now. I actually make 75 Large."

        };

        private static List<string> NegativeWords = new List<string>
        {
            "No",
            "Not",
            "Nope",
            "Nah"
        };
        //public AnswerParseResult ParseAnswer(string answer)
        //{
        //    var bestGuess = GetNormalizedAnswer(answer);
        //    return new AnswerParseResult {Answer = bestGuess};
        //}

        public static bool IsAnswerNegative(string answer)
        {
            var stripped = new string(answer.Where(c => !char.IsPunctuation(c)).ToArray());
            var words = stripped.Split(" ");
            return words.Any(w => NegativeWords.Contains(w));
        }

        public static int GetNormalizedAnswer(string answer, Dictionary<int, string> possibleAnswers)
        {
            var counts = possibleAnswers
                .Select(i => new KeyValuePair<int, int>(i.Key, GetNumberOfWordMatches(answer, i.Value)))
                .OrderBy(c => c.Value).ToList();

            return counts.Last().Key;
        }

        private static int GetNumberOfWordMatches(string answer, string candidate)
        {
            var wordsInFirst = answer.Split(" ");
            var wordsInSecond = candidate.Split(" ");

            return wordsInFirst.Count(w => wordsInSecond.Contains(w));
            //var count = wordsInFirst.Select(w => wordsInSecond.Contains(w)).Count();
            //return count;
        }
    }
}
