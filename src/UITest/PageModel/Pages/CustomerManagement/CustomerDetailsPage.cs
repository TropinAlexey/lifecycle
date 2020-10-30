using OpenQA.Selenium;

namespace BWMS.UITest.PageModel.Pages.CustomerManagement
{
    /// <summary>
    /// Represents the CustomerDetails page.
    /// </summary>
    public class CustomerDetailsPage : MainPage
    {
        public CustomerDetailsPage(App app) : base("Customer Management - details", app)
        {
        }

        public CustomerManagementPage Back()
        {
            WebDriver.FindElement(By.Id("BackButton")).Click();
            return new CustomerManagementPage(BWMS);
        }
    }
}