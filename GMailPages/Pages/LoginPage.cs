using GMailPages.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Linq;
using static GMailPages.StaticData;

namespace GMailPages
{
    public class LoginPage
    {
        private IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//*[@id='Email']")]
        private IWebElement loginField;

        [FindsBy(How = How.XPath, Using = "//*[@id='next']")]
        private IWebElement nextButton;

        [FindsBy(How = How.XPath, Using = "//*[@id='Passwd']")]
        private IWebElement pwdField;

        [FindsBy(How = How.XPath, Using = "//*[@id='signIn']")]
        private IWebElement signInButton;

        private By byWrongPasswordMessageXPath = By.XPath("//*[@id='errormsg_0_Passwd']");

        public LoginPage()
        {
            driver = Driver.Instance;
            PageFactory.InitElements(driver, this);
        }

        public void OpenLoginPage()
        {
            driver.Navigate().GoToUrl(LoginPageUrl);
        }

        public void EnterLoginAndProceed(string logIn)
        {
            loginField.SendKeys(logIn);
            nextButton.Click();
        }

        public void EnterPassword(string password)
        {
            pwdField.SendKeys(password);
        }

        public InboxPage SignIn()
        {
            signInButton.Click();
            InboxPage inboxPage = new InboxPage();
            if (inboxPage.IsNavToolbarPresent())
                return inboxPage;
            else if (driver.FindElements(byWrongPasswordMessageXPath).Any())
            {
                throw new System.Exception("Login failed - wrong password");
            }
            throw new System.Exception("Login failed");
        }

        public InboxPage PerformDefaultUserLogin()
        {
            OpenLoginPage();
            EnterLoginAndProceed(DefaultLogIn);
            EnterPassword(DefaultPassword);
            return SignIn();
        }
    }
}
