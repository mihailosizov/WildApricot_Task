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
        private LoginPage loginPage = new LoginPage();
        private InboxPage inboxPage = new InboxPage();

        [Given(@"GMail login page")]
        public void GivenGMailLoginPage()
        {
            loginPage.OpenLoginPage();
        }

        [When(@"User tries to log in using standard password")]
        public void WhenUserTriesToLoginUsingLoginAndPassword()
        {
            loginPage.EnterLoginAndProceed(DefaultLogIn);
            loginPage.EnterPassword(DefaultPassword);
            loginPage.SignIn(false);
        }

        [Then(@"User successfully logged in")]
        public void ThenUserSuccessfullyLoggedIn()
        {
            Assert.IsTrue(inboxPage.IsNavToolbarPresent());
        }
    }
}
