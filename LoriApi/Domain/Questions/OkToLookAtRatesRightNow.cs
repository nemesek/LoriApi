using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Questions
{
    public class OkToLookAtRatesRightNow : ISentence
    {
        public Sentences SentenceId => Sentences.OkToLookAtRates;
        public Func<string, string> DisplayText => _ => "Let’s look at rates and loan types now. We’ll need to go ahead and get you locked in. Is that ok?";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new NullSentence();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion { get; }
    }
}
