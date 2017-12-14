using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Questions
{
    public class OkToGetIncomeAndEmploymentInfo : ISentence
    {
        public Sentences SentenceId => Sentences.OkToGetIncomeAndEmploymentInfo;
        public string DisplayText => "I just need to get some income and employment verification information. OK?";

        public ISentence GetNextSentence(string incomingSentence)
        {
            return new CanYouProvideW2Information();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
    }
}
