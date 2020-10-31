using OpenQA.Selenium;

namespace BWMS.UITest.PageModel.Pages.CustomerManagement
{
    /// <summary>
    /// Represents the RegisterCustomer page.
    /// </summary>
    public class RegisterCustomerPage : MainPage
    {   
        public RegisterCustomerPage(App app) : base("Who are you? Let us know", app)
        {
        }

        public RegisterCustomerPage FillCustomerDetails(string name, string address,
            string city, string postalCode, string telephoneNumber, string emailAddress)
        {
            WebDriver.FindElement(By.Name("Customer.Name")).SendKeys(name);
            WebDriver.FindElement(By.Name("Customer.Address")).SendKeys(address);
            WebDriver.FindElement(By.Name("Customer.PostalCode")).SendKeys(postalCode);
            WebDriver.FindElement(By.Name("Customer.City")).SendKeys(city);
            WebDriver.FindElement(By.Name("Customer.TelephoneNumber")).SendKeys(telephoneNumber);
            WebDriver.FindElement(By.Name("Customer.EmailAddress")).SendKeys(emailAddress);
            return this;
        }

        public CustomerManagementPage Submit()
        {
            WebDriver.FindElement(By.Id("SubmitButton")).Click();
            return new CustomerManagementPage(App);
        }

        public CustomerManagementPage Cancel()
        {
            WebDriver.FindElement(By.Id("CancelButton")).Click();
            return new CustomerManagementPage(App);
        }
    }
}