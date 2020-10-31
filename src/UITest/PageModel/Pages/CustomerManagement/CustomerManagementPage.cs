using OpenQA.Selenium;

namespace BWMS.UITest.PageModel.Pages.CustomerManagement
{
    /// <summary>
    /// Represents the CustomerManagement page.
    /// </summary>
    public class CustomerManagementPage : MainPage
    {
        public CustomerManagementPage(App app) : base("Customer Management - overview", app)
        {
        }

        public RegisterCustomerPage RegisterCustomer()
        {
            WebDriver.FindElement(By.Id("RegisterCustomerButton")).Click();
            return new RegisterCustomerPage(App);
        }

        public CustomerDetailsPage SelectCustomer(string customerName)
        {
            WebDriver
                .FindElement(By.XPath($"//td[contains(text(),'{customerName}')]"))
                .Click();
            return new CustomerDetailsPage(App); 
        }
    }
}