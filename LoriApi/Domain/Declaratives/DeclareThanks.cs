using System;
using System.Collections.Generic;

namespace LoriApi.Domain.Declaratives
{
    public class DeclareThanks : ISentence
    {
        public Sentences SentenceId => Sentences.DeclareThanks;
        public Func<string, string> DisplayText => d => $"Thanks {d}, you too.";
        public ISentence GetNextSentence(string incomingSentence)
        {
            throw new NotImplementedException();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion => false;
    }
}
