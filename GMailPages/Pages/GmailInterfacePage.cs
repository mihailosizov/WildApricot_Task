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
    public abstract class GmailInterfacePage
    {
        protected IWebDriver driver;
        private string inboxLink = "Inbox";
        protected By byNavigationToolbarXPath = By.XPath("//div[@role='navigation']");
        protected By byComposeNewMailButtonXPath = By.XPath("//div[contains(text(), 'COMPOSE')]");
        protected By byLoadingMessageXPath = By.XPath("//div[contains(text(), 'Loading...')]");
        protected By byDeleteButtonXPath = By.XPath("//div[@role='button'][@aria-label='Delete']");
        protected By bySuccessfullDeleteMessageXPath = By.XPath("//span[contains(text(), 'been moved to the Trash')]");
       
        protected GmailInterfacePage()
        {
            driver = Driver.Instance;
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

        public void ClickNewMessageButton()
        {
            driver.FindElement(byComposeNewMailButtonXPath).Click();
        }

        public void ClickDeleteButton()
        {
            driver.FindElement(byDeleteButtonXPath).Click();
            if (!driver.FindElements(bySuccessfullDeleteMessageXPath).Any())
                throw new Exception("Message has not been deleted");
        }

        public InboxPage OpenInbox()
        {
            NavigationToolbarGoTo(inboxLink);
            return new InboxPage();
        }

        private void NavigationToolbarGoTo(string menuLinkName)
        {
            IWebElement navToolbar = driver.FindElement(byNavigationToolbarXPath);
            navToolbar.FindElement(By.PartialLinkText(menuLinkName)).Click();
            int count = 0;
            while (driver.FindElements(byLoadingMessageXPath).Any() && count < 100)
            {
                Thread.Sleep(100);
                count++;
            }
        }
    }
}