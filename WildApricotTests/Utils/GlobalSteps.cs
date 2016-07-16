using Common;
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

        [AfterFeature]
        public static void FeatureTearDown()
        {
            Driver.Close();
        }
    }
}
