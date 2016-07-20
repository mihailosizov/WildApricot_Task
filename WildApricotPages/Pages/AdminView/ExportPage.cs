using Common.Utils;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using static Common.Utils.CommonUtils;

namespace WildApricotPages.Pages
{
    public class ExportPage : AdminViewPage
    {
        private static string exportFormatSelectorXPath = ".//div[contains(text(), '{0}')]";
        private static string exportProcessingDialogId = "WaAdminPanel_ExportModule_ExportProcessingDialog_content";
        private static string exportSucceededDialogId = "WaAdminPanel_ExportModule_successContent";
        private const string exportSucceededResultLinkXPath = "//*[@id='WaAdminPanel_ExportModule_successContent']/div[@class='exportResultContainer']//a[contains(@id, 'WaAdminPanel_ExportModule_successContent_downloadLink')]";
        private const string closeSucceedExportResultDialogButtonId = "WaAdminPanel_ExportModule_successContent_closeButton_buttonName";

        [FindsBy(How = How.Id, Using = "WaAdminPanel_ExportModule_exportSettingsContent_exportFormat_textContainer")]
        private IWebElement exportFormatDropDown;

        [FindsBy(How = How.Id, Using = "WaAdminPanel_ExportModule_exportSettingsContent_exportFormat_dropDown_scrollablePanel_content")]
        private IWebElement exportFormatDropDownElements;

        [FindsBy(How = How.Id, Using = "WaAdminPanel_ExportModule_exportSettingsContent_selectAll")]
        private IWebElement exportAllFieldsCheckBox;

        [FindsBy(How = How.Id, Using = "WaAdminPanel_ExportModule_exportSettingsContentOkButton_toolBarButton")]
        private IWebElement exportButton;

        [FindsBy(How = How.XPath, Using = exportSucceededResultLinkXPath)]
        private IWebElement exportResultLink;

        [FindsBy(How = How.Id, Using = closeSucceedExportResultDialogButtonId)]
        private IWebElement closeSucceedExportResultDialogButton;


        public IWebElement ExportResultLink
        {
            get
            {
                return exportResultLink;
            }

            private set { }
        }

        public ExportPage()
        {
            this.driver = Driver.Instance;
            PageFactory.InitElements(driver, this);
            switchToDefaultFrame();
        }

        public void SetExportAllFields(bool isAllFieldsShouldBeExported)
        {
            if (isAllFieldsShouldBeExported)
            {
                if (!exportAllFieldsCheckBox.Selected)
                {
                    exportAllFieldsCheckBox.Click();
                }
            }
            else
            {
                if (exportAllFieldsCheckBox.Selected)
                {
                    exportAllFieldsCheckBox.Click();
                }
            }
        }

        public void SetExportFormat(string exportFormat)
        {
            exportFormatDropDown.Click();
            exportFormatDropDownElements.FindElement(By
                .XPath(string.Format(exportFormatSelectorXPath, exportFormat)))
                .Click();
        }

        public void ClickExportButton(bool waitForFileGenerated)
        {
            exportButton.Click();
            Driver.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(exportProcessingDialogId)));
            if (waitForFileGenerated)
            {
                Driver.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(exportSucceededDialogId)));
                Driver.Wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(exportSucceededResultLinkXPath)));
                Driver.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id(closeSucceedExportResultDialogButtonId)));
                
            }
        }

        public void CloseSucceedExport()
        {
            if (IsElementDisplayed(closeSucceedExportResultDialogButton))
            {
                closeSucceedExportResultDialogButton.Click();
                Driver.SetReducedWaitTimeout();
                Driver.Wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.Id(closeSucceedExportResultDialogButtonId)));
                Driver.SetDefaultWaitTimeout();
            }
        }
    }
}
