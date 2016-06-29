using GMailPages.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GMailTests
{
    [Binding]
    public class DeleteSteps
    {
        private InboxPage inboxPage = new InboxPage();

        [When(@"User deletes all emails with Test subject")]
        [When(@"User deletes an email with Test subject")]
        public void WhenUserDeletesAnEmailWithTestSubject()
        {
            inboxPage = inboxPage.OpenInbox();
            inboxPage.SelectMessagesByText(ComposePage.sentMessagesSubjects);
            inboxPage.ClickDeleteButton();
        }

        [Then(@"Email with Test subject is deleted")]
        [Then(@"All emails with Test subject are deleted")]
        public void ThenEmailWithTestSubjectIsDeleted()
        {
            inboxPage = inboxPage.OpenInbox();
            bool isMessageNotInTheInbox = (inboxPage.FindElementsByTextInMessagesPanel(ComposePage.sentMessagesSubjects).Count == 0);
            Assert.IsTrue(isMessageNotInTheInbox);
        }
    }
}
