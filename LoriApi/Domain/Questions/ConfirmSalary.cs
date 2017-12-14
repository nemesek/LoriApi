using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoriApi.Domain.Assertions;

namespace LoriApi.Domain.Questions
{
    public class ConfirmSalary : ISentence
    {
        private readonly string _displayText = string.Empty;
        
        public ConfirmSalary(string displayText)
        {
            _displayText = displayText;
        }
        public Sentences SentenceId => Sentences.ConfirmSalary;
        public string DisplayText => _displayText;
        public ISentence GetNextSentence(string incomingSentence)
        {
            //var number = Regex.Replace(incomingSentence, @"[^\d]", "");
            if (AnswerParser.IsAnswerNegative(incomingSentence))
            {
                Synonyms.UpdateSynonym("75 large", "$75,000");
                return new AssertSalary("Oh gotcha, $75,000");
            }

            return new AssertSalary("OK, $75,000");
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
    }
}
