using System;
using System.Collections.Generic;

namespace LoriApi.Domain
{
    public class NullSentence : ISentence
    {
        private string _displayText = "Thanks you too.";

        public NullSentence()
        {
            
        }
        public NullSentence(string displayText)
        {
            if (!string.IsNullOrWhiteSpace(displayText)) _displayText = displayText;
        }

        public Sentences SentenceId => Sentences.NullQuestion;
        public Func<string, string> DisplayText => _ => _displayText;
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new NullSentence(_displayText);
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal => true;
        public bool IsAssertion => false;
    }
}
