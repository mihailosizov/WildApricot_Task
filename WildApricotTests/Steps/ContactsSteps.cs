using TechTalk.SpecFlow;
using WildApricotPages.Pages;

namespace WildApricotTests.Steps
{
    [Binding]
    public class ContactsSteps
    {
        ContactsPage contactsPage = new ContactsPage();

        [Given(@"Contacts are not filtered")]
        public void GivenContactsAreNotFiltered()
        {
            contactsPage.ClearSimpleSearch();
        }

        [Given(@"Admin user is in Export screen")]
        public void GivenAdminUserIsInExportMenu()
        {
            contactsPage.GoToExportScreen();
        }
    }
}
