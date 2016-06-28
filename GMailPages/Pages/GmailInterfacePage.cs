using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GMailPages.Pages
{
    public class GmailInterfacePage
    {
        protected IWebDriver driver;

        [FindsBy(How = How.XPath, Using = "//div[@role='navigation']")]
        [CacheLookup]
        protected IWebElement navigationToolbar;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'COMPOSE')]")]
        [CacheLookup]
        protected IWebElement composeNewMailButton;

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Delete']|//div[@title='Delete']")]
        protected IWebElement deleteButton;

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Refresh']|//div[@title='Refresh']")]
        protected IWebElement refreshButton;

        protected By byNavigationToolbarXPath = By.XPath("//div[@role='navigation']");
        protected By bySuccessfullDeleteMessageXPath = By.XPath("//span[contains(text(), 'been moved to the Trash')]");
        protected By byLoadingMessageXPath = By.XPath("//*[contains(text(), 'Loading...')]");

        public GmailInterfacePage()
        {
            driver = Driver.Instance;
            PageFactory.InitElements(driver, this);
        }

        public bool IsNavToolbarPresent()
        {
            if (driver.FindElements(byNavigationToolbarXPath).Any())
            {
                Driver.Logger.Info("GMail main interface page is loaded");
                return true;
            }
            return false;
        }

        public ComposePage ClickNewMessageButton()
        {
            composeNewMailButton.Click();
            return new ComposePage();
        }

        public void ClickDeleteButton()
        {
            deleteButton.Click();
            if (!driver.FindElements(bySuccessfullDeleteMessageXPath).Any())
                throw new Exception("Message has not been deleted");
            Refresh();
        }

        public InboxPage OpenInbox()
        {
            NavigationToolbarGoTo("Inbox");
            return new InboxPage();
        }

        private void NavigationToolbarGoTo(string menuLinkName)
        {
            navigationToolbar.FindElement(By.PartialLinkText(menuLinkName)).Click();
            waitForLoading();
        }

        public void waitForLoading()
        {
            Driver.Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(byLoadingMessageXPath));
        }

        public void Refresh()
        {
            refreshButton.Click();
            waitForLoading();
        }
    }
}