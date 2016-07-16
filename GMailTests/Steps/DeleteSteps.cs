using Common.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GMailTests
{
    [Binding]
    public class DeleteSteps
    {
        private InboxPage inboxPage = new InboxPage();

        [When(@"User deletes all emails that was sent")]
        [When(@"User deletes an email that was sent")]
        public void WhenUserDeletesEmails()
        {
            inboxPage = inboxPage.OpenInbox();
            inboxPage.SelectMessagesByText(ComposePage.SentMessagesSubjects);
            inboxPage.ClickDeleteButton();
        }

        [Then(@"An email that was sent has been deleted")]
        [Then(@"All emails that was sent has been deleted")]
        public void ThenEmailsHasBeenDeleted()
        {
            inboxPage = inboxPage.OpenInbox();
            bool isMessageNotInTheInbox = (inboxPage.FindElementsByTextInMessagesPanel(ComposePage.SentMessagesSubjects).Count == 0);
            Assert.IsTrue(isMessageNotInTheInbox);
        }
    }
}
