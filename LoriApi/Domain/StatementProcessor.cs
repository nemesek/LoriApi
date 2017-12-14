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
        //private static readonly Dictionary<int, Func<IQuestion>> QuestionMap = new Dictionary<int, Func<IQuestion>>
        //{
        //    {1, ()=> new ReadyToGetStarted()},
        //    //{2, ()=> new QuestionTwo()},
        //    {3, ()=> new HaveYouAreadyDecidedOnAHome()}
        //};
        //public IQuestion BeginLoanInterview()
        //{
        //    return BuildQuestion(1);

        //}
        //public IQuestion GetNextQuestion(IQuestion question, string answer)
        //{
        //    return question.GetNextSentence(answer);
        //    //var id = question.GetNextQuestion(answer);
        //    //return BuildQuestion(id);
        //}

        //private static IQuestion BuildQuestion(int id)
        //{
        //    return QuestionMap[id]();
        //}
    }
}
