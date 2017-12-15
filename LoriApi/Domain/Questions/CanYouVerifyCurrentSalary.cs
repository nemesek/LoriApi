using System;
using System.Collections.Generic;
using System.Linq;

namespace LoriApi.Domain.Questions
{
    public class CanYouVerifyCurrentSalary : ISentence
    {
        public Sentences SentenceId => Sentences.CanYouVerifyCurrentSalary;
        public Func<string,string> DisplayText => _ => "Ok, and it looks like you make $80,000 annually, is that correct?";
        public ISentence GetNextSentence(string incomingSentence)
        {
            var synonym = Synonyms.GetSynonyms("75 large").First();
            return new ConfirmSalary($"So you earn {synonym} annually?");
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion => false;
    }
}
