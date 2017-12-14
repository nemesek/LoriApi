using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Declaratives
{
    public class DeclareThanks : ISentence
    {
        public Sentences SentenceId => Sentences.DeclareThanks;
        public string DisplayText => "Thanks, you have a good night";
        public ISentence GetNextSentence(string incomingSentence)
        {
            throw new NotImplementedException();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
    }
}
