using System.Collections.Generic;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain.Imperatives
{
    public class FileUploadImperative : ISentence
    {
        public Sentences SentenceId => Sentences.PleaseUploadFiles;
        public string DisplayText => "Great, let’s upload it now, just ask me if you have a question about it.";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new NullSentence();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal => true;
    }
}
