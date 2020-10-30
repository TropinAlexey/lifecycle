using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Pitstop.UITest.PageModel.Pages.VehicleManagement
{
    /// <summary>
    /// Represents the VehicleManagement page.
    /// </summary>
    public class VehicleManagementPage : PitstopPage
    {
        public VehicleManagementPage(PitstopApp pitstop) : base("Vehicle Management - overview", pitstop)
        {
        }

        public RegisterVehiclePage RegisterVehicle()
        {
            WebDriver.FindElement(By.Id("RegisterVehicleButton")).Click();
            return new RegisterVehiclePage(Pitstop);
        }

        public VehicleDetailsPage SelectVehicle(string Name)
        {
            WebDriver
                .FindElement(By.XPath($"//td[contains(text(),'{Name}')]"))
                .Click();
            return new VehicleDetailsPage(Pitstop); 
        }
    }
}