using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Events;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain
{
    public class StatementProcessor
    {
        private static readonly Dictionary<Events.Events, Func<ISentence>> EventSentenceMap = new Dictionary<Events.Events, Func<ISentence>>
        {
            {Events.Events.LoanInterviewStarted, ()=> new ReadyToGetStarted() },
            {Events.Events.FilesWereProcessed, ()=> new CanYouVerifyCurrentEmployment() }
        };
        public ISentence ProcessEvent(IEvent businessEvent)
        {
            return EventSentenceMap[businessEvent.EventId]();
        }

        public ISentence ProcessEvent(Events.Events businessEventId)
        {
            return EventSentenceMap[businessEventId]();
        }

    }
}
