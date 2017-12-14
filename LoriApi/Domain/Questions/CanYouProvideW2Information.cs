using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Imperatives;

namespace LoriApi.Domain.Questions
{
    public class CanYouProvideW2Information : ISentence
    {
        public Sentences SentenceId => Sentences.CanYouProvideW2Informaion;

        public string DisplayText => "Would you be able to provide any W-2 informationnow, say for the last few years?  You could upload right here if so.";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new FileUploadImperative();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal => false;
    }
}
