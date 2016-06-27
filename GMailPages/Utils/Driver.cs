using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace GMailPages
{
    public class Driver
    {
        private static double waitTimeout = 5000;
        private static IWebDriver instance;
        private static ILog logger;

        public static IWebDriver Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ChromeDriver();
                }
                return instance;

            }
            private set { }
        }

        public static ILog Logger
        {
            get
            {
                if (logger == null)
                {
                    logger = LogManager.GetLogger("GMail test log");
                }
                return logger;
            }
        }

        public static void Initialize()
        {
            TurnOnImplicitlyWait();
            Instance.Manage().Window.Maximize();
        }

        private static void TurnOnImplicitlyWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(waitTimeout));
        }

        public static void Quit()
        {
            //Instance.Quit();
        }

        public static void NavigateTo(string address)
        {
            Instance.Navigate().GoToUrl(address);
        }
    }
}
