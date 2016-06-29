﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GMailPages.Pages
{
    public class ComposePage : GmailInterfacePage
    {
        private static Random random = new Random();

        [FindsBy(How = How.Name, Using = "to")]
        [CacheLookup]
        private IWebElement toField;

        [FindsBy(How = How.Name, Using = "subjectbox")]
        [CacheLookup]
        private IWebElement subjectField;

        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        [CacheLookup]
        private IWebElement messageBody;

        [FindsBy(How = How.XPath, Using = "//div[contains(text(), 'Send')]")]
        [CacheLookup]
        private IWebElement sendButton;

        private By bySuccessfullSendMessageXPath = By.XPath("//div[contains(text(), 'Your message has been sent.')]");

        public static List<string> sentMessagesSubjects = new List<string>();

        public ComposePage()
        {
            PageFactory.InitElements(driver, this);
        }

        public void FillToField(string to)
        {
            toField.SendKeys(to);
        }

        public void FillSubjectField(string subject)
        {
            subjectField.SendKeys(subject);
        }

        public void FillMessageBody(string message)
        {
            messageBody.SendKeys(message);
        }

        public void SendMessage()
        {
            sendButton.Click();
            if (!driver.FindElements(bySuccessfullSendMessageXPath).Any())
                throw new Exception("Message has not been sent");
        }

        public static string GenerateRandomSubject()
        {
            string subject = StaticData.DefaultSubject + random.Next(10000, 99999);
            sentMessagesSubjects.Add(subject);
            return subject;
        }

        public static void ClearSentMessagesList()
        {
            sentMessagesSubjects.Clear();
        }
    }
}
