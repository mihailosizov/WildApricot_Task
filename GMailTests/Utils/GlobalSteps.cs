using GMailPages;
using GMailPages.Pages;
using TechTalk.SpecFlow;

namespace GMailTests.Utils
{
    [Binding]
    public class GlobalSteps : Driver
    {
        [BeforeScenario]
        protected void SetUp()
        {
            Initialize();
        }

        [AfterScenario]
        protected void ScenarioTearDown()
        {
            ComposePage.ClearSentMessagesList();
            
        }

        [AfterFeature]
        protected static void FeatureTearDown()
        {
            Quit();
        }
    }
}
