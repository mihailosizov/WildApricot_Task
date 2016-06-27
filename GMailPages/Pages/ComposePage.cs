using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GMailPages.Pages
{
    public class ComposePage : GmailInterfacePage
    {
        private By byToFieldName = By.Name("to");
        private By bySubjectFieldName = By.Name("subjectbox");
        private By byMessageBodyXPath = By.XPath("//div[@aria-label='Message Body']");
        private By bySendButtonXPath = By.XPath("//div[contains(text(), 'Send')]");
        private By bySuccessfullSendMessageXPath = By.XPath("//div[contains(text(), 'Your message has been sent.')]");

        public void FillToField(string to)
        {
            driver.FindElement(byToFieldName).SendKeys(to);
        }

        public void FillSubjectField(string subject)
        {
            driver.FindElement(bySubjectFieldName).SendKeys(subject);
        }

        public void FillMessageBody(string message)
        {
            driver.FindElement(byMessageBodyXPath).SendKeys(message);
        }

        public void SendMessage()
        {
            driver.FindElement(bySendButtonXPath).Click();
            if (!driver.FindElements(bySuccessfullSendMessageXPath).Any())
                throw new Exception("Message has not been sent");
        }
    }
}
