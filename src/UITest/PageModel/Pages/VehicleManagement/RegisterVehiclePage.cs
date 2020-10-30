using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BWMS.UITest.PageModel.Pages.VehicleManagement
{
    /// <summary>
    /// Represents the RegisterVehicle page.
    /// </summary>
    public class RegisterVehiclePage : MainPage
    {
        public RegisterVehiclePage(App app) : base("What is your bike? Register it", app)
        {
        }

        public RegisterVehiclePage FillVehicleDetails(string Name, string brand, string type, string owner)
        {
            WebDriver.FindElement(By.Name("Vehicle.Name")).SendKeys(Name);
            WebDriver.FindElement(By.Name("Vehicle.Brand")).SendKeys(brand);
            WebDriver.FindElement(By.Name("Vehicle.Type")).SendKeys(type);
            SelectElement select = new SelectElement(WebDriver.FindElement(By.Id("SelectedCustomerId")));
            select.SelectByText(owner);
            return this;
        }

        public VehicleManagementPage Submit()
        {
            WebDriver.FindElement(By.Id("SubmitButton")).Click();
            return new VehicleManagementPage(app);
        }

        public VehicleManagementPage Cancel()
        {
            WebDriver.FindElement(By.Id("CancelButton")).Click();
            return new VehicleManagementPage(app);
        }
    }
}