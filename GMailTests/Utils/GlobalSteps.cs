using GMailPages;
using GMailPages.Pages;
using TechTalk.SpecFlow;

namespace GMailTests.Utils
{
    [Binding]
    public class GlobalSteps
    {
        [BeforeFeature]
        public static void SetUp()
        {
            Driver.Initialize();
        }

        [AfterScenario]
        public void ScenarioTearDown()
        {
            ComposePage.ClearSentMessagesList();
            
        }

        [AfterFeature]
        public static void FeatureTearDown()
        {
            Driver.Close();
        }
    }
}
