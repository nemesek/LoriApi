using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoriApi.Domain
{
    public interface ISentence
    {
        Sentences SentenceId { get; }
        string DisplayText { get; }
        ISentence GetNextSentence(string incomingSentence);
        List<string> EquilaventQuestions { get; }
        bool IsTerminal { get; }
    }
}
