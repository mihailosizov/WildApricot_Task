using GMailPages.Pages;
using GMailTests.Steps;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace GMailTests
{
    [Binding]
    public class DeleteSteps
    {
        private InboxPage inboxPage;

        [When(@"User deletes a letter with Test subject")]
        public void WhenUserDeletesALetterWithTestSubject()
        {
            inboxPage = new InboxPage();
            inboxPage = inboxPage.OpenInbox();
            inboxPage.SelectMessagesByText(SendSteps.messageSubject);
            inboxPage = inboxPage.OpenInbox();
            inboxPage.ClickDeleteButton();
        }

        [Then(@"Email with Test subject is deleted")]
        public void ThenEmailWithTestSubjectIsDeleted()
        {
            inboxPage = inboxPage.OpenInbox();
            bool isMessageNotInTheInbox = (inboxPage.FindElementsByTextInMessagesPanel(SendSteps.messageSubject).Count == 0);
            Assert.IsTrue(isMessageNotInTheInbox);
        }
    }
}
