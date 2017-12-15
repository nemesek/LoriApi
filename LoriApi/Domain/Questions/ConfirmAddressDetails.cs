using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Imperatives;

namespace LoriApi.Domain.Questions
{
    public class ConfirmAddressDetails : ISentence
    {
        public Sentences SentenceId => Sentences.ConfirmAddressDetails;

        public Func<string, string> DisplayText => _ =>
            $"Oh French Style – I like it.  It looks like that property is a single family residence with a sale price of $300,000.  Does that sound correct?";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new LetMeKnowWhenYouHaveTheFinalValue();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion { get; }
    }
}
