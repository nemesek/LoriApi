using System;
using System.Collections.Generic;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain.Imperatives
{
    public class UploadOtherAssetsAndDebts : ISentence
    {
        public Sentences SentenceId => Sentences.UploadOtherAssetsAndDepts;

        public Func<string, string> DisplayText => _ =>
            "Ok I'll need a copy of your bank statement, retirement account, and a state issued picture ID. Please submit those now.";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new HowDoesPreApprovedAmountSound();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion { get; }
    }
}
