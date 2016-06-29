using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace GMailPages
{
    public class Driver
    {
        private static double waitTimeout = 10000;
        private static IWebDriver instance;
        private static WebDriverWait wait;
        private static bool isInitialized = false;

        public static IWebDriver Instance
        {
            get
            {
                return instance;

            }
            private set { }
        }

        public static WebDriverWait Wait
        {
            get
            {
                return wait;
            }

            private set { }
        }

        public static void Initialize()
        {
            if (!isInitialized)
            {
                instance = new ChromeDriver();
                wait = new WebDriverWait(instance, TimeSpan.FromSeconds(waitTimeout));
                TurnOnImplicitlyWait();
                instance.Manage().Window.Maximize();
                isInitialized = true;
            }
        }

        private static void TurnOnImplicitlyWait()
        {
            instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(waitTimeout));
        }

        public static void Close()
        {
            instance.Quit();
            isInitialized = false;
        }
    }
}
