using TechTalk.SpecFlow;
using GMailPages;
using GMailPages.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GMailPages.StaticData;

namespace GMailTests
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
