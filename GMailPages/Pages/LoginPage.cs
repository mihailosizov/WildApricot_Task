using OpenQA.Selenium;
using static GMailPages.StaticData;

namespace GMailPages
{
    public class LoginPage
    {
        private By byLoginFieldXPath = By.XPath("//*[@id='Email']");
        private By byNextButtonXPath = By.XPath("//*[@id='next']");
        private By byPwdFieldXPath = By.XPath("//*[@id='Passwd']");
        private By bySignInButtonXPath = By.XPath("//*[@id='signIn']");
        private By byStayLoggedInCheckBoxXPath = By.XPath("//*[@id='PersistentCookie']");
        private By byWrongPasswordMessageXPath = By.XPath("//*[@id='errormsg_0_Passwd']");
        private IWebDriver driver;
        private IWebElement loginField;
        private IWebElement nextButton;
        private IWebElement pwdField;
        private IWebElement signInButton;
        private IWebElement stayLoggedInCheckBox;
        private IWebElement wrongPasswordMessage;

        public LoginPage()
        {
            driver = Driver.Instance;
        }

        public void OpenLoginPage()
        {
            Driver.NavigateTo(LoginPageUrl);
        }

        public void EnterLoginAndProceed(string logIn)
        {
            loginField = driver.FindElement(byLoginFieldXPath);
            loginField.SendKeys(logIn);
            nextButton = driver.FindElement(byNextButtonXPath);
            nextButton.Click();
        }

        public void EnterPassword(string password)
        {
            pwdField = driver.FindElement(byPwdFieldXPath);
            pwdField.SendKeys(password);
        }

        public void SignIn(bool stayLoggedIn)
        {
            signInButton = driver.FindElement(bySignInButtonXPath);
            stayLoggedInCheckBox = driver.FindElement(byStayLoggedInCheckBoxXPath);
            if (stayLoggedIn)
            {
                if (!stayLoggedInCheckBox.Selected)
                    stayLoggedInCheckBox.Click();
            }
            else
            {
                if (stayLoggedInCheckBox.Selected)
                    stayLoggedInCheckBox.Click();
            }
            signInButton.Click();
            try
            {
                wrongPasswordMessage = driver.FindElement(byWrongPasswordMessageXPath);
                throw new System.Exception("Login failed - wrong password");
            }
            catch (NoSuchElementException)
            {
            }
        }

        public void PerformDefaultUserLogin()
        {
            OpenLoginPage();
            EnterLoginAndProceed(DefaultLogIn);
            EnterPassword(DefaultPassword);
            SignIn(false);
        }
    }
}
