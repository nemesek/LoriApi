using System;
using System.Collections.Generic;

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
        public Func<string,string> DisplayText => _ =>  _displayText;
        public ISentence GetNextSentence(string incomingSentence)
        {
            var conversation = new Conversation("foo", 1);
            return conversation.GetNextSentence(this);
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion => true;
    }
}
