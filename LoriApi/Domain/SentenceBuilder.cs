using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LoriApi.Domain.Assertions;
using LoriApi.Domain.Declaratives;
using LoriApi.Domain.Imperatives;
using LoriApi.Domain.Questions;

namespace LoriApi.Domain
{
    public static class SentenceBuilder
    {
        private static readonly Dictionary<Sentences, Func<string, ISentence>> SentenceMap = new Dictionary<Sentences, Func<string, ISentence>>
        {
            {Sentences.NullQuestion, _ => new NullSentence() },
            {Sentences.ReadyToGetStarted, _ => new ReadyToGetStarted() },
            {Sentences.HaveYouAlreadyDecidedOnAHome, _ => new HaveYouAreadyDecidedOnAHome() },
            {Sentences.TerminateOnNeedDocuments, _ => new TerminateOnNeedDocuments() },
            {Sentences.OkToGetIncomeAndEmploymentInfo, _ => new OkToGetIncomeAndEmploymentInfo() },
            {Sentences.CanYouProvideW2Informaion, _ => new CanYouProvideW2Information() },
            {Sentences.CanYouVerifyCurrentEmployment, _ => new CanYouVerifyCurrentEmployment() },
            {Sentences.CanYouVerifyCurrentSalary, _ => new CanYouVerifyCurrentSalary() },
            {Sentences.ConfirmSalary, d => new ConfirmSalary(d) },
            {Sentences.AssertSalary, d => new AssertSalary(d) },
            {Sentences.OkToProvideAssetsAndDebts, _ => new OkProvidingAssetsAndDebts() },
            {Sentences.DeclareNextSteps, d => new DeclareNextSteps(d) },
            {Sentences.DeclareThanks, _ => new DeclareThanks() },
            {Sentences.UploadOtherAssetsAndDepts, _ => new UploadOtherAssetsAndDebts() },
            {Sentences.HowDoesPreApprovedAmountSound, _ => new HowDoesPreApprovedAmountSound() },
            {Sentences.WhatIsTheAddress, _ => new WhatIsTheAddress() },
            {Sentences.ConfirmAddressDetails, _ => new ConfirmAddressDetails() },
            {Sentences.LetMeKnowWhenYouHaveTheFinalValue, _ => new LetMeKnowWhenYouHaveTheFinalValue() },
            {Sentences.OkToLookAtRates, _ => new OkToLookAtRatesRightNow() }

        };

        public static ISentence BuildSentence(Sentences sentenceId, string displayText)
        {
            return SentenceMap[sentenceId](displayText);
        }
    }
}
