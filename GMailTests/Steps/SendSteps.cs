using GMailPages;
using GMailPages.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using static GMailPages.StaticData;

namespace GMailTests.Steps
{
    [Binding]
    public class SendSteps
    {
        private InboxPage inboxPage = new InboxPage();
        private ComposePage composePage = new ComposePage();

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
            composePage = inboxPage.ClickNewMessageButton();
            composePage.FillToField(address);
            composePage.FillSubjectField(ComposePage.GenerateRandomSubject());
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
            bool isMessageInTheInbox = (inboxPage.FindElementsByTextInMessagesPanel(ComposePage.sentMessagesSubjects).Count > 0);
            Assert.IsTrue(isMessageInTheInbox);
        }
    }
}
