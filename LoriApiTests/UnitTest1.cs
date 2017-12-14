using System;
using System.Collections.Generic;
using LoriApi.Domain;
using LoriApi.Domain.Events;
using LoriApi.Domain.Questions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LoriApiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void FrequencyDistribution_Foo()
        {
            List<string> li = new List<string>();
            li.Add("One");
            li.Add("Two");
            li.Add("Two");
            li.Add("Three");
            li.Add("Three");
            li.Add("Three");
            FrequencyDist<string> cs = new FrequencyDist<string>(li);
            //foreach (var v in cs.ItemFreq.Values)
            //{
            //    Console.WriteLine(v.value + " : " + v.count);
            //}

        }

        [TestMethod]
        public void StatementProcessor_ProcessEvent_ReturnsReadyToGetStartedWhenGivenLoanInterviewStarted()
        {
            // arrange
            var target = new StatementProcessor();
            // act
            var result = target.ProcessEvent(new LoanInterviewStarted());

            // assert
            Assert.IsTrue(result.SentenceId == Sentences.ReadyToGetStarted);
        }

        [TestMethod]
        public void StatementProcessor_ProcessEvent_ReturnsCanYouVerifyCurrentEmploymentWhenGivenFilesWereProcessed()
        {
            // arrange
            var target = new StatementProcessor();
            // act
            var result = target.ProcessEvent(new FilesWereProcessed());

            // assert
            Assert.IsTrue(result.SentenceId == Sentences.CanYouVerifyCurrentEmployment);
        }

        [TestMethod]
        public void ReadyToGetStarted_GetNextSentence_ReturnsHaveYouAlreadyDecidedOnAHome()
        {
            // arrange
            var target = new ReadyToGetStarted();

            // act
            var result = target.GetNextSentence("Yes");

            // result
            Assert.AreEqual(result.SentenceId, Sentences.HaveYouAlreadyDecidedOnAHome);
        }


        [TestMethod]
        public void HaveYouAlreadyDecidedOnAHome_GetNextSentence_ReturnsOkToGetIncomeInfo()
        {
            
            // arrange
            var target = new HaveYouAreadyDecidedOnAHome();

            // act
            var result = target.GetNextSentence("How");

            // assert
            Assert.IsTrue(result.SentenceId == Sentences.OkToGetIncomeAndEmploymentInfo);
        }

        [TestMethod]
        public void OkToGetIncomeAndEmploymentInfo_GetNextSentence_ReturnsCanYouProvideW2AndEmploymentInfo()
        {
            
            // arrange
            var target= new OkToGetIncomeAndEmploymentInfo();

            // act
            var result = target.GetNextSentence("Yes");

            // assert
            Assert.AreEqual(Sentences.CanYouProvideW2Informaion, result.SentenceId);
        }

        [TestMethod]
        public void CanYouProvideW2Information_GetNextSentence_ReturnsFileUploadImperative()
        {
            // arrange
            var target = new CanYouProvideW2Information();

            // act
            var result = target.GetNextSentence("Yep");

            // assert
            Assert.AreEqual(Sentences.PleaseUploadFiles, result.SentenceId);
        }

        [TestMethod]
        public void CanYouVerifyCurrentEmployment_GetNextSentence_ReturnsCanYouVerifyCurrentSalary()
        {
            // arrange
            var target = new CanYouVerifyCurrentEmployment();

            // act
            var result = target.GetNextSentence("Yeppers");

            // assert
            Assert.AreEqual(Sentences.CanYouVerifyCurrentSalary, result.SentenceId);
        }

        [TestMethod]
        public void CanYouVerifyCurrentSalary_GetNextSentence_ReturnsConfirmSalary()
        {
            // arrange
            var target = new CanYouVerifyCurrentSalary();

            // act
            var result = target.GetNextSentence("I wish, I make 75 large");

            // Assert
            Assert.AreEqual(Sentences.ConfirmSalary, result.SentenceId);
        }

        [TestMethod]
        public void ConfirmSalary_GetNextSentence_ReturnsAssertSalary()
        {
            // arrange
            var target = new ConfirmSalary($"So you earn $75 annually?");

            // act
            var result = target.GetNextSentence("Yep");

            // assert
            Assert.AreEqual(Sentences.AssertSalary, result.SentenceId);
        }

        [TestMethod]
        public void CanYouVerifyCurrentSalaryAndConfirmSalary_GetNextSentence_Learns()
        {
            // arrange
            var canYouVerify = new CanYouVerifyCurrentSalary();
            var confirmSalary = canYouVerify.GetNextSentence("I wish, I make 75 large");

            // act
            Assert.AreEqual("So you earn $75 annually?", confirmSalary.DisplayText);
            confirmSalary.GetNextSentence("No, $75,000");
            var confirmSalaryAgain = canYouVerify.GetNextSentence("I wish, I make 75 large");

            // assert
            Assert.AreEqual("So you earn $75,000 annually?", confirmSalaryAgain.DisplayText);
        }

    }
}
