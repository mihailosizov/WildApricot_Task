using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GMailPages.Pages
{
    public class InboxPage : GmailInterfacePage
    {
        private By byInboxMessagesPanelXPath = By.XPath("//div[@role='tabpanel']//tbody");
        private By byCheckBoxXPath = By.XPath("//div[@role='checkbox']");
        private string containsTextXPath = "//*[contains(text(), '{0}')]";

        public void SelectMessagesByText(string text)
        {
            List<IWebElement> messages = FindElementsByTextInMessagesPanel(text);
            foreach (IWebElement message in messages)
            {
                IWebElement checkBox = message.FindElement(byCheckBoxXPath);
                if (checkBox.GetAttribute("aria-checked").Equals("false"))
                {
                    checkBox.Click();
                }
            }
        }

        public List<IWebElement> FindElementsByTextInMessagesPanel(string textToLookFor)
        {
            IWebElement inboxMessagesPanel = driver.FindElement(byInboxMessagesPanelXPath);
            ReadOnlyCollection<IWebElement> allFoundElements = inboxMessagesPanel.
                FindElements(By.XPath(string.Format(containsTextXPath, textToLookFor)));
            List<IWebElement> elementsToReturn = new List<IWebElement>();
            foreach (IWebElement element in allFoundElements)
            {
                if (element.Displayed)
                {
                    elementsToReturn.Add(element);
                }
            }
            return elementsToReturn;
        }
    }
}
