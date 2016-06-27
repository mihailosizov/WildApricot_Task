using GMailPages;
using GMailPages.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using static GMailPages.StaticData;

namespace GMailTests.Steps
{
    [Binding]
    public class SendSteps
    {
        private InboxPage inboxPage;
        private ComposePage composePage;
        private Random random = new Random();
        public static string messageSubject;

        [Given(@"User is on inbox page")]
        public void GivenUserIsOnInboxPage()
        {
            inboxPage = new InboxPage();
            if (inboxPage.IsNavToolbarPresent())
            {
                inboxPage.OpenInbox();
            }
            else
            {
                new LoginPage().PerformDefaultUserLogin();
            }
        }

        [When(@"User send an email to (.*)")]
        [Given(@"Email with Test subject was sent to (.*)")]
        public void WhenUserSendAnEmailTo(string address)
        {
            messageSubject = DefaultSubject + random.Next(10000, 99999);
            composePage = new ComposePage();
            inboxPage.ClickNewMessageButton();
            composePage.FillToField(address);
            composePage.FillSubjectField(messageSubject);
            composePage.FillMessageBody(DefaultMessageText);
            composePage.SendMessage();
        }

        [Then(@"User successfully receives this email")]
        public void ThenUserSuccessfullyReceivesThisEMail()
        {
            inboxPage = inboxPage.OpenInbox();
            bool isMessageInTheInbox = (inboxPage.FindElementsByTextInMessagesPanel(messageSubject).Count > 0);
            Assert.IsTrue(isMessageInTheInbox);
        }
    }
}
