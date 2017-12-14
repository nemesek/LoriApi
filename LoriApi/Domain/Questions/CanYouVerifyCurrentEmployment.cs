using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain.Questions
{
    public class CanYouVerifyCurrentEmployment : ISentence
    {
        public Sentences SentenceId => Sentences.CanYouVerifyCurrentEmployment;

        public string DisplayText =>
            "That was what I needed, thanks. Can you verify the following information for me.Current employer is CoreLogic at 1214 Office Park Drive, is that correct?";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new CanYouVerifyCurrentSalary();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
    }
}
