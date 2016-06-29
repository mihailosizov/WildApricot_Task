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
        private static WebDriverWait wait;

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

        public static WebDriverWait Wait
        {
            get
            {
                if (wait == null)
                {
                    wait = new WebDriverWait(Instance, TimeSpan.FromSeconds(waitTimeout));
                }
                return wait;
            }

            private set { }
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
            Instance.Quit();
        }
    }
}
