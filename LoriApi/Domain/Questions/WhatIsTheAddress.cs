using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Questions
{
    public class WhatIsTheAddress : ISentence
    {
        public Sentences SentenceId => Sentences.WhatIsTheAddress;

        public Func<string, string> DisplayText => n =>
            $"That’s great to hear, I’m so excited for you {n}. We will need to determine the type of loan you’ll need and get a rate locked in, but’s go ahead and tell me the address and we’ll keep moving forward.";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new ConfirmAddressDetails();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion { get; }
    }
}
