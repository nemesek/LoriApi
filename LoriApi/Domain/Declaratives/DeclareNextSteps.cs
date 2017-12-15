using System;
using System.Collections.Generic;

namespace LoriApi.Domain.Declaratives
{
    public class DeclareNextSteps : ISentence
    {
        private readonly string _displayText;
        public DeclareNextSteps(string displayText)
        {
            _displayText = displayText;
        }

        public Sentences SentenceId => Sentences.DeclareNextSteps;
        public Func<string, string> DisplayText => _ => _displayText;
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new DeclareThanks();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion => false;
    }
}
