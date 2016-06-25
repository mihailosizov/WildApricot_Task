using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace GMailPages
{
    public class Driver
    {

        private static IWebDriver instance;
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

        public static void Initialize()
        {
            TurnOnImplicitlyWait();
            Instance.Manage().Window.Maximize();
        }

        private static void TurnOnImplicitlyWait()
        {
            Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
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
