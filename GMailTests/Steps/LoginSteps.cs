using System;
using TechTalk.SpecFlow;
using GMailPages;
using GMailTests.Utils;
using GMailPages.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static GMailPages.StaticData;

namespace GMailTests
{
    [Binding]
    public class LoginSteps : BaseTest
    {
        private LoginPage loginPage;
        private InboxPage inboxPage;

        [Given(@"GMail login page")]
        public void GivenGMailLoginPage()
        {
            loginPage = new LoginPage();
            loginPage.OpenLoginPage();
        }

        [When(@"User tries to log in using standard password")]
        public void WhenUserTriesToLogInUsingLoginAndPassword()
        {
            loginPage.EnterLoginAndProceed(DefaultLogIn);
            loginPage.EnterPassword(DefaultPassword);
            inboxPage = loginPage.SignIn();
        }

        [Then(@"User successfully logged in")]
        public void ThenUserSuccessfullyLoggedIn()
        {
            Assert.IsTrue(Instance.Title.Contains("Inbox") && inboxPage.IsNavToolbarPresent());
        }
    }
}
