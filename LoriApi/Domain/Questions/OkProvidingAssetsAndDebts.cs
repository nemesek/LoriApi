using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Declaratives;

namespace LoriApi.Domain.Questions
{
    public class OkProvidingAssetsAndDebts : ISentence
    {
        public Sentences SentenceId => Sentences.OkToProvideAssetsAndDebts;
        public string DisplayText => "Ok, I just need a little more information about your assets, debts, etc. – are you ok providing this now?";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new DeclareNextSteps(": Sure, I’ll be around, when you come back just say Hi and we can pick up here. I will send you a checklist of documents I’ll need and also a link to upload them if you’d like to do that at your convenience. ");
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal { get; }
    }
}
