using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Questions
{
    public class ReadyToGetStarted : ISentence
    {

        public Sentences SentenceId => Sentences.ReadyToGetStarted;

        public string DisplayText =>
            "Hi, I’m LORI. Your personal Mortgage Loan Processing assistant, available 24/7. I’ll help you get pre-approved and on your way to a new home step-by-step. Ready to go?";

        //public int GetNextTransitionQuestion => 3;
        //public int GetNextClarifyingQuestion => 2;
        //public int GetNextQuestion(string answer)
        //{
        //    var isNegative = AnswerParser.IsAnswerNegative(answer);
        //    return isNegative ? 2 : 3;
        //}

        public ISentence GetNextSentence(string incomingSentence)
        {
            var isNegative = AnswerParser.IsAnswerNegative(incomingSentence);
            if (isNegative) return new NullSentence();
            return new HaveYouAreadyDecidedOnAHome();
        }

        public List<string> EquilaventQuestions => new List<string>();
        public bool IsTerminal { get; }
    }
}
