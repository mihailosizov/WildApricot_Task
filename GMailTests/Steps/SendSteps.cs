using GMailPages;
using GMailPages.Pages;
using GMailTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using static GMailPages.StaticData;
using System.Linq;

namespace GMailTests.Steps
{
    [Binding]
    public class SendSteps : BaseTest
    {
        private InboxPage inboxPage = new InboxPage();
        private ComposePage composePage = new ComposePage();
        private Random random = new Random();
        public static List<string> sentMessagesSubjects = new List<string>();

        [Given(@"User is on inbox page")]
        public void GivenUserIsOnInboxPage()
        {
            if (inboxPage.IsNavToolbarPresent())
            {
                inboxPage = inboxPage.OpenInbox();
            }
            else
            {
                inboxPage = new LoginPage().PerformDefaultUserLogin();
            }
        }

        [When(@"User send an email to (.*)")]
        [Given(@"Email with Test subject was sent to (.*)")]
        public void WhenUserSendAnEmailTo(string address)
        {
            sentMessagesSubjects.Add(DefaultSubject + random.Next(10000, 99999));
            composePage = inboxPage.ClickNewMessageButton();
            composePage.FillToField(address);
            composePage.FillSubjectField(sentMessagesSubjects.Last());
            composePage.FillMessageBody(DefaultMessageText);
            composePage.SendMessage();
        }

        [Given(@"(.*) emails with Test subject was sent to (.*)")]
        public void GivenEmailsWithTestSubjectWasSentTo(int numberOfEmails, string address)
        {
            for (int i = 0; i < numberOfEmails; i++)
            {
                WhenUserSendAnEmailTo(address);
            }
        }

        [Then(@"User successfully receives email")]
        public void ThenUserSuccessfullyReceivesEMail()
        {
            inboxPage = inboxPage.OpenInbox();
            bool isMessageInTheInbox = (inboxPage.FindElementsByTextInMessagesPanel(sentMessagesSubjects).Count > 0);
            sentMessagesSubjects.Clear();
            Assert.IsTrue(isMessageInTheInbox);
        }
    }
}
