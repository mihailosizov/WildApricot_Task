using TechTalk.SpecFlow;
using GmailPages.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GmailPages.Utils.StaticData;
using Common.Utils;

namespace GMailTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private LoginPage loginPage;
        private InboxPage inboxPage;

        [Given(@"User is logged out")]
        public void GivenUserIsLoggedOut()
        {
            if (Driver.Instance.Title.Contains(DefaultLogIn))
            {
                Driver.Close();
                Driver.Initialize();
            }

        }

        [Given(@"GMail login page")]
        public void GivenGMailLoginPage()
        {
            loginPage = new LoginPage();
            loginPage.OpenLoginPage();
        }

        [When(@"User performs login with correct credentials")]
        public void WhenUserPerformsLoginWithCorrectCredentials()
        {
            loginPage.EnterLoginAndProceed(DefaultLogIn);
            loginPage.EnterPassword(DefaultPassword);
            inboxPage = loginPage.SignIn();
        }

        [Then(@"User logged in successfully")]
        public void ThenUserLoggedInSuccessfully()
        {
            Assert.IsTrue(Driver.Instance.Title.Contains(DefaultLogIn) && inboxPage.IsNavToolbarPresent());
        }
    }
}
