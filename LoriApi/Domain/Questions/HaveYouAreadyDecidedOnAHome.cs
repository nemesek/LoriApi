using System;
using System.Collections.Generic;

namespace LoriApi.Domain.Questions
{
    public class HaveYouAreadyDecidedOnAHome : ISentence
    {
        private readonly Dictionary<int, string> _possibleAnswers = new Dictionary<int, string>
        {
            {1, "Yes, I have an address already" },
            {2, "NO NOT YET, I’M NOT SURE HOW MUCH OF A LOAN I WOULD QUALIFY FOR" },
            {3, "NO – STILL LOOKING, BUT I’M CURIOUS HOW MUCH I CAN BORROW" }
        };
        public Sentences SentenceId => Sentences.HaveYouAlreadyDecidedOnAHome;
        public Func<string, string> DisplayText => s => $"Great {s}. To start let's see where you are currently in process.  Have you already decided on a home?";
        
        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal => false;

        public ISentence GetNextSentence(string incomingSentence)
        {
            //var matchedAnswerId = AnswerParser.GetNormalizedAnswer(answer, _possibleAnswers);
            //if (matchedAnswerId == 1) return new NullQuestion("Ok cool, I am here when you are ready");
            return new OkToGetIncomeAndEmploymentInfo();

        }
        public bool IsAssertion => false;


    }
}
