using WildApricotPages.Pages;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Common.Utils;
using static WildApricotPages.Utils.StaticData;

namespace WildApricotTests.Steps
{
    [Binding]
    public class LoginSteps
    {
        private TestAccountLoginPage loginPage;
        private AdminViewPage adminViewPage;

        [Given(@"Test account admin login page")]
        public void GivenTestAccountAdminLoginPage()
        {
            loginPage = new TestAccountLoginPage();
            loginPage.OpenLoginPage(true);
        }

        [When(@"Admin user performs login with correct credentials")]
        public void WhenAdminUserPerformsLoginWithCorrectCredentials()
        {
            loginPage.EnterUserName(TestAccountAdminUserName);
            loginPage.EnterPassword(TestAccountAdminPassword);
            adminViewPage = loginPage.SignInAsAdmin();
        }

        [Then(@"Admin user is successfully logged in to admin view")]
        public void ThenAdminUserIsSuccessfullyLoggedInToAdminView()
        {
            string expectedTitle = TestAccountAdminUserName.Remove(TestAccountAdminUserName.IndexOf("@"));
            Assert.IsTrue(Driver.Instance.Title.Contains(expectedTitle) && adminViewPage.IsAdminMenuPresent());
        }
    }
}
