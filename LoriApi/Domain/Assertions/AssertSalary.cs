using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain.Assertions
{
    public class AssertSalary : ISentence
    {
        private readonly string _displayText;
        public AssertSalary(string displayText)
        {
            _displayText = displayText;
        }
        public Sentences SentenceId => Sentences.AssertSalary;
        public string DisplayText => _displayText;
        public ISentence GetNextSentence(string incomingSentence)
        {
            //var synonym = Synonyms.GetSynonyms("75 large");
            return new NullSentence("foo");
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
    }
}
