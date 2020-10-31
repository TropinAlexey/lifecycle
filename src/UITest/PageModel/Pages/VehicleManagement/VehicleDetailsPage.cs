using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BWMS.UITest.PageModel.Pages.VehicleManagement
{
    /// <summary>
    /// Represents the VehicleDetails page.
    /// </summary>
    public class VehicleDetailsPage : MainPage
    {        
        public VehicleDetailsPage(App app) : base("Vehicle Management - details", app)
        {
        }

        public VehicleManagementPage Back()
        {
            WebDriver.FindElement(By.Id("BackButton")).Click();
            return new VehicleManagementPage(App);
        }
    }
}