using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace WildApricotPages.Pages
{
    public class ContactsPage : AdminViewPage
    {
        [FindsBy(How = How.XPath, Using = "//select[@id='ctl00_content_filter']")]
        private IWebElement simpleSearchFilterDropDown;

        [FindsBy(How = How.XPath, Using = "//input[@id='ctl00_content_SearchBox']")]
        private IWebElement simpleSearchFilterTextField;

        [FindsBy(How = How.Id, Using = "ctl00_content_idSimpleSearchLink_InnerControl")]
        private IWebElement simpleSearchLink;

        [FindsBy(How = How.Id, Using = "toolbar_Buttons")]
        private IWebElement toolbarButtonsContainer;

        private ReadOnlyCollection<IWebElement> toolbarButtons;

        public ContactsPage()
        {
            PageFactory.InitElements(driver, this);
            switchToContentFrame();
        }

        public void SetSimpleSearchFilterText(string value)
        {
            simpleSearchFilterTextField.SendKeys(value);
        }

        public void SetSimpleSearchFilterDropDown(string dropDownItemToSelect)
        {
            SelectElement select = new SelectElement(simpleSearchFilterDropDown);
            select.SelectByText(dropDownItemToSelect);
        }

        public void ClearSimpleSearch()
        {
            simpleSearchLink.Click();
            SetSimpleSearchFilterDropDown("All");
            SetSimpleSearchFilterText("");
        }

        public void PressToolbarButton(string buttonName)
        {
            switchToDefaultFrame();
            toolbarButtons = toolbarButtonsContainer.FindElements(By.XPath(".//div[@class='buttonName']"));
            foreach (IWebElement element in toolbarButtons)
            {
                if (element.Text.ToLower().Equals(buttonName.ToLower()))
                {
                    element.Click();
                    break;
                }
            }
            switchToContentFrame();
        }

        public void GoToExportScreen()
        {
            PressToolbarButton("Export");
        }

    }
}
