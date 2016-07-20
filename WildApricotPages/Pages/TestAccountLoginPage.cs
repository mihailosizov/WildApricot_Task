using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Common.Utils;
using System.Linq;
using static WildApricotPages.Utils.StaticData;

namespace WildApricotPages.Pages
{
    public class TestAccountLoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div/input[contains(@id, 'loginControl_userName')]")]
        private IWebElement userNameField;

        [FindsBy(How = How.XPath, Using = "//div/input[contains(@id, 'loginControl_Password')]")]
        private IWebElement passwordField;

        [FindsBy(How = How.XPath, Using = "//div[@id='idLoginButtonBox']/span")]
        private IWebElement loginButton;

        private By byAuthErrorMessageXPath = By.XPath("//div/p[@class='oAuthError']");

        public TestAccountLoginPage()
        {
            this.driver = Driver.Instance;
            PageFactory.InitElements(driver, this);
        }

        public void OpenLoginPage(bool isAdmin)
        {
            driver.Navigate().GoToUrl(isAdmin ? TestAccountAdminLoginUrl : TestAccountAdminLoginUrl);
        }

        public void EnterUserName(string userName)
        {
            userNameField.SendKeys(userName);
            userNameField.Click();
        }

        public void EnterPassword(string password)
        {
            passwordField.SendKeys(password);
        }

        public AdminViewPage SignInAsAdmin()
        {
            loginButton.Click();
            AdminViewPage adminViewPage = new AdminViewPage();
            if (adminViewPage.IsAdminMenuPresent())
                return adminViewPage;
            else if (driver.FindElements(byAuthErrorMessageXPath).Any())
            {
                throw new System.Exception("Login failed - authentication error");
            }
            throw new System.Exception("Login failed");
        }

        public AdminViewPage PerformTestAccountAdminLogin()
        {
            OpenLoginPage(true);
            EnterUserName(TestAccountAdminUserName);
            EnterPassword(TestAccountAdminPassword);
            return SignInAsAdmin();
        }
    }
}
