using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Threading;

namespace Common.Utils
{
    public class CommonUtils
    {
        private static string defaultDownloadPath = Environment.GetEnvironmentVariable("USERPROFILE") + "/Downloads";

        public static bool IsFileDownloadedNow(string expectedFileName, string expectedFileExtension, bool deleteFoundFile)
        {
            Thread.Sleep(TimeSpan.FromSeconds(1)); // give a little time for a file to appear in the folder after download start
            bool fileExist = false;
            string[] filePaths = Directory.GetFiles(defaultDownloadPath);
            foreach (string filePath in filePaths)
            {
                if (filePath.Contains(expectedFileName))
                {
                    FileInfo thisFile = new FileInfo(filePath);
                    if (thisFile.Extension.Contains(expectedFileExtension))
                    {
                        var downloadedTime = thisFile.LastWriteTime;
                        var nowTime = DateTime.Now;
                        if (nowTime.Subtract(downloadedTime) < TimeSpan.FromMinutes(1))
                        {
                            fileExist = true;
                            if (deleteFoundFile)
                            {
                                File.Delete(filePath);
                            }
                            break;
                        }
                    }
                }
            }
            return fileExist;
        }

        public static bool IsElementDisplayed(IWebElement element)
        {
            try
            {
                Driver.Wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy
                    (new ReadOnlyCollection<IWebElement>(new List<IWebElement>(new[] { element }))));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }
        }
    }
}
