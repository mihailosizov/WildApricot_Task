using TechTalk.SpecFlow;
using WildApricotPages.Pages;

namespace WildApricotTests.Steps
{
    [Binding]
    public class AdminViewSteps
    {
        private AdminViewPage adminViewPage = new AdminViewPage();

        [Given(@"Admin user is logged in to admin view")]
        public void GivenAdminUserIsLoggedInToAdminView()
        {
            if (!adminViewPage.IsAdminMenuPresent())
            {
                adminViewPage = new TestAccountLoginPage().PerformTestAccountAdminLogin();
            }
        }

        [Given(@"Admin user is in (.*) menu")]
        public void GivenAdminUserIsInSpecificMenu(string menuName)
        {
            adminViewPage.GoToTopTabMenu(menuName);
        }
    }
}
