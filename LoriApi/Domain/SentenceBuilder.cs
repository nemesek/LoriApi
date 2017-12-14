using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain
{
    public static class SentenceBuilder
    {
        private static readonly Dictionary<Sentences, Func<string, ISentence>> SentenceMap = new Dictionary<Sentences, Func<string, ISentence>>
        {
            {Sentences.ReadyToGetStarted, _ => new ReadyToGetStarted() },
            {Sentences.HaveYouAlreadyDecidedOnAHome, _ => new HaveYouAreadyDecidedOnAHome() },
            {Sentences.OkToGetIncomeAndEmploymentInfo, _ => new OkToGetIncomeAndEmploymentInfo() },
            {Sentences.CanYouProvideW2Informaion, _ => new CanYouProvideW2Information() },
            {Sentences.CanYouVerifyCurrentEmployment, _ => new CanYouVerifyCurrentEmployment() },
            {Sentences.CanYouVerifyCurrentSalary, _ => new CanYouVerifyCurrentSalary() },
            {Sentences.ConfirmSalary, d => new ConfirmSalary(d) }
        };

        public static ISentence BuildSentence(Sentences sentenceId, string displayText)
        {
            return SentenceMap[sentenceId](displayText);
        }
    }
}
