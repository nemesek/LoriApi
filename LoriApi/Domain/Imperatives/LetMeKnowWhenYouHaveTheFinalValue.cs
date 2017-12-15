using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain.Imperatives
{
    public class LetMeKnowWhenYouHaveTheFinalValue : ISentence
    {
        public Sentences SentenceId => Sentences.LetMeKnowWhenYouHaveTheFinalValue;

        public Func<string, string> DisplayText => _ =>
            "Sounds good, let me know how that goes and when you guys have that final value. I will need to get an appraisal and perhaps some other services ordered in order to verify the property’s value.";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new OkToLookAtRatesRightNow();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion { get; }
    }
}
