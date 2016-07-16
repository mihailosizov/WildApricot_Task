using Common;
using Common.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using static Common.StaticData;

namespace GMailTests.Steps
{
    [Binding]
    public class SendSteps
    {
        private InboxPage inboxPage = new InboxPage();
        private ComposePage composePage = new ComposePage();

        [Given(@"User is on Inbox page")]
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

        [When(@"User sends an email to (.*)")]
        [Given(@"An email was sent to (.*)")]
        public void WhenUserSendsAnEmailTo(string address)
        {
            composePage = inboxPage.ClickNewMessageButton();
            composePage.FillToField(address);
            composePage.FillSubjectField(ComposePage.GenerateRandomSubject());
            composePage.FillMessageBody(DefaultMessageText);
            composePage.SendMessage();
        }

        [Given(@"(.*) emails was sent to (.*)")]
        public void GivenEmailsWasSentTo(int numberOfEmails, string address)
        {
            for (int i = 0; i < numberOfEmails; i++)
            {
                WhenUserSendsAnEmailTo(address);
            }
        }

        [Then(@"User received (.*) email successfully")]
        public void ThenUserReceivedEmailSuccessfully(int numberOfEmails)
        {
            inboxPage = inboxPage.OpenInbox();
            bool isMessageInTheInbox = (inboxPage.FindElementsByTextInMessagesPanel(ComposePage.SentMessagesSubjects).Count == numberOfEmails);
            Assert.IsTrue(isMessageInTheInbox);
        }
    }
}
