using Common.Utils;
using TechTalk.SpecFlow;

namespace WildApricotTests.Utils
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
