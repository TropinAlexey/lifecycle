using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BWMS.UITest.PageModel.Pages.VehicleManagement
{
    /// <summary>
    /// Represents the VehicleManagement page.
    /// </summary>
    public class VehicleManagementPage : MainPage
    {
        public VehicleManagementPage(App app) : base("Add your bike", app)
        {
        }

        public RegisterVehiclePage RegisterVehicle()
        {
            WebDriver.FindElement(By.Id("RegisterVehicleButton")).Click();
            return new RegisterVehiclePage(app);
        }

        public VehicleDetailsPage SelectVehicle(string Name)
        {
            WebDriver
                .FindElement(By.XPath($"//td[contains(text(),'{Name}')]"))
                .Click();
            return new VehicleDetailsPage(app); 
        }
    }
}