using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using WildApricotPages.Pages;
using static Common.Utils.CommonUtils;

namespace WildApricotTests.Steps
{
    [Binding]
    public class ExportContactsSteps
    {
        private ExportPage exportPage = new ExportPage();

        [Given(@"(.*) is a file format for Contacts export")]
        public void GivenXLSIsAFileFormatForContactsExport(string fileFormat)
        {
            exportPage.SetExportFormat(fileFormat);
        }

        [Given(@"All fields are selected for Contacts export")]
        public void GivenAllFieldsAreSelectedForContactsExport()
        {
            exportPage.SetExportAllFields(true);
        }

        [When(@"Admin user presses export Contacts and waits for file being generated")]
        public void WhenAdminUserPressesExportContactsAndWaitsForFileBeingGenerated()
        {
            exportPage.ClickExportButton(true);
        }

        [Then(@"Dialog with a link to an exported file is appeared")]
        public void ThenDialogWithALinkToAnExportedFileIsAppeared()
        {
            bool isLinkDisplayed = IsElementDisplayed(exportPage.ExportResultLink);
            Assert.IsTrue(isLinkDisplayed);
        }

        [Then(@"Exported file has been downloaded automatically")]
        public void ThenExportedFileHasBeenDownloadedAutomatically()
        {
            string exportedFileName = exportPage.ExportResultLink.Text;
            string[] fileNameAndExtension = exportedFileName.Split(".".ToCharArray());
            if (!(fileNameAndExtension.Length == 2))
            {
                throw new Exception("Unable to properly define file name and extension");
            }
            Assert.IsTrue(IsFileDownloadedNow(fileNameAndExtension[0], fileNameAndExtension[1], true));
        }

        [Then(@"Exported file has (.*) extension")]
        public void ThenExportedFileHasSpecificExtension(string expectedExtension)
        {
            string linkText = exportPage.ExportResultLink.Text;
            string actualExtension = linkText.Substring(linkText.LastIndexOf(".") + 1).ToLower();
            Assert.IsTrue(actualExtension.Equals(expectedExtension.ToLower()));
        }

        [AfterScenario]
        public void AfterScenarioActivities()
        {
            exportPage.CloseSucceedExport();
        }
    }
}
