using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain
{
    public class Conversation
    {
        private string _name;
        private int _language;

        public Conversation(string name, int language)
        {
            _name = name;
            _language = language;
        }
        public ISentence GetNextSentence(ISentence currrentSentence)
        {
            if (currrentSentence.SentenceId == Sentences.AssertSalary)
            {
                return new OkProvidingAssetsAndDebts();
            }

            return new NullSentence("Foo");
        }

        public ISentence GetNextSentence(ISentence currrentSentence, Func<ISentence> getNextSentence)
        {
            return getNextSentence();
        }

        public ConversationDto GetConversationDto(ISentence currentSentence)
        {
            var displayText = _language == 1
                ? currentSentence.DisplayText(_name) : Translator.TranslateToSpanish(currentSentence, _name);
            return new ConversationDto
            {
                DisplayText = displayText,
                Language = _language,
                Name = _name,
                SentenceId = currentSentence.SentenceId,
                IsAssertion = currentSentence.IsAssertion
            };
        }
    }
}
