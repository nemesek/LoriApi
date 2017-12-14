using System.Collections.Generic;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain.Imperatives
{
    public class FileUploadImperative : ISentence
    {
        public Sentences SentenceId => Sentences.PleaseUploadFiles;
        public string DisplayText => "";
        public ISentence GetNextSentence(string incomingSentence)
        {
            return new NullSentence();
        }

        public List<string> EquilaventQuestions { get; }
        public bool IsTerminal => true;
    }
}
