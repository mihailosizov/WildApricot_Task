﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;

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
            WaitForDelete();
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
            WaitForLoading();
        }

        public void WaitForLoading()
        {
            Driver.Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(byLoadingMessageXPath));
        }

        public void WaitForDelete()
        {
            Driver.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(bySuccessfullDeleteMessageXPath));
        }

        public void Refresh()
        {
            refreshButton.Click();
            WaitForLoading();
        }
    }
}