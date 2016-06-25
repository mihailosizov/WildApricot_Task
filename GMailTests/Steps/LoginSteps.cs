using System;
using TechTalk.SpecFlow;
using GMailPages;
using GMailTests.Utils;

namespace GMailTests
{
    [Binding]
    public class LoginSteps : BaseTest
    {
        private LoginPage loginPage = new LoginPage();

        [Given(@"GMail login page")]
        public void GivenGMailLoginPage()
        {
            loginPage.OpenLoginPage();
        }

        [When(@"User tries to log in using (.*) and (.*)")]
        public void WhenUserTriesToLoginUsingLoginAndPassword(String login, String password)
        {
            loginPage.EnterLoginAndProceed(login);
            loginPage.EnterPassword(password);
            loginPage.SignIn(false);
        }

        [Then(@"User successfully logged in")]
        public void ThenUserSuccessfullyLoggedIn()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
