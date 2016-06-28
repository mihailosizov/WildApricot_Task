using GMailPages.Pages;
using GMailTests.Steps;
using GMailTests.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Support.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace GMailTests
{
    [Binding]
    public class DeleteSteps : BaseTest
    {
        private InboxPage inboxPage = new InboxPage();

        [When(@"User deletes all emails with Test subject")]
        [When(@"User deletes an email with Test subject")]
        public void WhenUserDeletesAnEmailWithTestSubject()
        {
            inboxPage = inboxPage.OpenInbox();
            inboxPage.SelectMessagesByText(SendSteps.sentMessagesSubjects);
            inboxPage.ClickDeleteButton();
        }

        [Then(@"Email with Test subject is deleted")]
        [Then(@"All emails with Test subject are deleted")]
        public void ThenEmailWithTestSubjectIsDeleted()
        {
            inboxPage = inboxPage.OpenInbox();
            bool isMessageNotInTheInbox = (inboxPage.FindElementsByTextInMessagesPanel(SendSteps.sentMessagesSubjects).Count == 0);
            SendSteps.sentMessagesSubjects.Clear();
            Assert.IsTrue(isMessageNotInTheInbox);
        }
    }
}
