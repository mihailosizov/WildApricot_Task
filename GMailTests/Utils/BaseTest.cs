using GMailPages;
using TechTalk.SpecFlow;

namespace GMailTests.Utils
{
    public class BaseTest : Driver
    {
        [BeforeScenario]
        protected void SetUp()
        {
            Initialize();
        }

        [AfterScenario]
        protected void TearDown()
        {
            Quit();
        }
    }
}
