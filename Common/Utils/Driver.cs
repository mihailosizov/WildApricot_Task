using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace Common.Utils
{
    public class Driver
    {
        private static double waitTimeout = 20000;
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
                instance = new ChromeDriver(generateDefaultOptions());
                wait = new WebDriverWait(instance, TimeSpan.FromMilliseconds(waitTimeout));
                SetDefaultWaitTimeout();
                instance.Manage().Window.Maximize();
                isInitialized = true;
            }
        }

        public static WebDriverWait GetCustomWait(TimeSpan timeout)
        {
            return new WebDriverWait(instance, timeout);
        }

        public static void Close()
        {
            instance.Quit();
            isInitialized = false;
        }

        public static void SetReducedWaitTimeout(TimeSpan timeout)
        {
            instance.Manage().Timeouts().ImplicitlyWait(timeout);
        }

        public static void SetReducedWaitTimeout()
        {
            SetReducedWaitTimeout(TimeSpan.FromSeconds(1));
        }

        public static void SetDefaultWaitTimeout()
        {
            instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(waitTimeout));
        }

        private static ChromeOptions generateDefaultOptions()
        {
            Dictionary<String, Object> prefs = new Dictionary<String, Object>();
            ChromeOptions options = new ChromeOptions();
            options.AddUserProfilePreference("profile.default_content_settings.popups", 0);
            options.AddUserProfilePreference("profile.content_settings.pattern_pairs.*.multiple-automatic-downloads", 1);
            options.AddUserProfilePreference("download.prompt_for_download", "false");
            options.AddUserProfilePreference("profile.default_content_setting_values.automatic_downloads", 1);
            options.AddUserProfilePreference("profile.managed_default_content_settings.popups", 2);
            options.AddUserProfilePreference("safebrowsing.enabled", "true");
            return options;
        }
    }
}
