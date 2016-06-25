using OpenQA.Selenium;

namespace GMailPages
{
    public class LoginPage
    {
        private static string loginFieldXPath = "//*[@id='Email']";
        private static string nextButtonXPath = "//*[@id='next']";
        private static string pwdFieldXPath = "//*[@id='Passwd']";
        private static string signInButtonXPath = "//*[@id='signIn']";
        private static string stayLoggedInCheckBoxXPath = "//*[@id='PersistentCookie']";
        private static string wrongPasswordMessageXPath = "//*[@id='errormsg_0_Passwd']";
        private IWebElement loginField;
        private IWebElement nextButton;
        private IWebElement pwdField;
        private IWebElement signInButton;
        private IWebElement stayLoggedInCheckBox;
        private IWebElement wrongPasswordMessage;

        public void OpenLoginPage()
        {
            Driver.NavigateTo(StaticData.LoginPageUrl);
        }

        public void EnterLoginAndProceed(string login)
        {
            loginField = Driver.Instance.FindElement(By.XPath(loginFieldXPath));
            loginField.SendKeys(login);
            nextButton = Driver.Instance.FindElement(By.XPath(nextButtonXPath));
            nextButton.Click();
        }

        public void EnterPassword(string pwd)
        {
            pwdField = Driver.Instance.FindElement(By.XPath(pwdFieldXPath));
            pwdField.SendKeys(pwd);
        }

        public void SignIn(bool stayLoggedIn)
        {
            signInButton = Driver.Instance.FindElement(By.XPath(signInButtonXPath));
            stayLoggedInCheckBox = Driver.Instance.FindElement(By.XPath(stayLoggedInCheckBoxXPath));
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
                wrongPasswordMessage = Driver.Instance.FindElement(By.XPath(wrongPasswordMessageXPath));
                throw new System.Exception("Login failed - wrong password");
            }
            catch (NoSuchElementException)
            {
            }
        }
    }
}
