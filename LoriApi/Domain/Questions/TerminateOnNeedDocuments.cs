using System;
using System.Collections.Generic;

namespace LoriApi.Domain.Questions
{
    public class TerminateOnNeedDocuments : ISentence
    {
        public Sentences SentenceId => Sentences.TerminateOnNeedDocuments;

        public Func<string, string> DisplayText => _ => "Sure, I’ll be around, when you come back just say Hi and we can pick up here. I will send you a checklist of documents I’ll need and also a link to upload them if you’d like to do that at your convenience.";

        public ISentence GetNextSentence(string incomingSentence)
        {
            return new NullSentence();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
        public bool IsAssertion => false;
    }
}
