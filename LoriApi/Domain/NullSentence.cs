using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Questions
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
        public string DisplayText => _displayText;
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new NullSentence(_displayText);
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal => true;
    }
}
