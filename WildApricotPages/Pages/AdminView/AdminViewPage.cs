using Common.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Collections.ObjectModel;
using System.Linq;

namespace WildApricotPages.Pages
{
    public class AdminViewPage
    {
        protected IWebDriver driver;

        private const string adminMenuContainerXPath = "//div[@id='idAdminMenuContainer']";
        private const string adminMainMenuXPath = adminMenuContainerXPath + "//div[@id='idAdminMainMenu']";

        [FindsBy(How = How.XPath, Using = adminMenuContainerXPath)]
        private IWebElement adminMenu;

        [FindsBy(How = How.XPath, Using = adminMainMenuXPath)]
        private IWebElement adminMainMenu;

        [FindsBy(How = How.XPath, Using = adminMainMenuXPath + "//div[@id='idAdminTopTabSwitcher']")]
        private IWebElement adminTopTabMenu;

        private ReadOnlyCollection<IWebElement> topTabMenuElements;


        public AdminViewPage()
        {
            this.driver = Driver.Instance;
            PageFactory.InitElements(driver, this);
        }

        public bool IsAdminMenuPresent()
        {
            switchToDefaultFrame();
            Driver.SetReducedWaitTimeout();
            ReadOnlyCollection<IWebElement> adminMenuElements = driver.FindElements(By.XPath(adminMenuContainerXPath));
            Driver.SetDefaultWaitTimeout();
            return adminMenuElements.Any();
        }

        public void GoToTopTabMenu(string menuName)
        {
            switchToDefaultFrame();
            topTabMenuElements = adminTopTabMenu.FindElements(By.XPath("./div"));
            foreach (var element in topTabMenuElements)
            {
                if (element.GetAttribute("id").ToLower().Equals(menuName.ToLower() + "_container"))
                {
                    element.Click();
                    break;
                }
            }
        }

        protected void switchToContentFrame()
        {
            driver.SwitchTo().Frame(0);
        }

        protected void switchToDefaultFrame()
        {
            driver.SwitchTo().DefaultContent();
        }
    }
}
