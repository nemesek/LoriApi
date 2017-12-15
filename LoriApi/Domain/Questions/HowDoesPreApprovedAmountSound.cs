using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Questions
{
    public class HowDoesPreApprovedAmountSound : ISentence
    {
        public Sentences SentenceId => Sentences.HowDoesPreApprovedAmountSound;
        public Func<string, string> DisplayText => _ => "Ok, I processed the files. Everything looks good & You’ve been pre-approved for a $275,000 loan. How does that sound?";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new WhatIsTheAddress();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion { get; }
    }
}
