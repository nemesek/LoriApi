using System;
using System.Collections.Generic;

namespace LoriApi.Domain.Questions
{
    public class OkToGetIncomeAndEmploymentInfo : ISentence
    {
        public Sentences SentenceId => Sentences.OkToGetIncomeAndEmploymentInfo;
        public Func<string, string> DisplayText => s => $"Not uncommon {s}, I just need to get some income and employment verification information. OK?";

        public ISentence GetNextSentence(string incomingSentence)
        {
            return new CanYouProvideW2Information();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion => false;
    }
}
