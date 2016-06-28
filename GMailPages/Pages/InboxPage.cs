using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace GMailPages.Pages
{
    public class InboxPage : GmailInterfacePage
    {
        [FindsBy(How = How.XPath, Using = "//div[@role='tabpanel']//tbody")]
        private IWebElement inboxMessagesPanel;

        private By byMessageRowCheckBoxXPath = By.XPath("ancestor::tr//div[@role='checkbox']");

        private string containsTextXPath = "//*[contains(text(), '{0}')]";

        public InboxPage()
        {
            PageFactory.InitElements(driver, this);
        }

        public void SelectMessagesByText(ICollection<string> texts)
        {
            List<IWebElement> messages = FindElementsByTextInMessagesPanel(texts);
            foreach (IWebElement message in messages)
            {
                IWebElement checkBox = message.FindElement(byMessageRowCheckBoxXPath);
                if (checkBox.GetAttribute("aria-checked").Equals("false"))
                {
                    checkBox.Click();
                }
            }
        }

        public List<IWebElement> FindElementsByTextInMessagesPanel(ICollection<string> texts)
        {
            List<IWebElement> foundElements = new List<IWebElement>();
            ReadOnlyCollection<IWebElement> nextFoundElements;
            foreach (string text in texts)
            {
                nextFoundElements = inboxMessagesPanel.FindElements(By.XPath(string.Format(containsTextXPath, text)));
                foundElements.AddRange(nextFoundElements);
            }
            List<IWebElement> elementsToReturn = new List<IWebElement>();
            foreach (IWebElement element in foundElements)
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
