using OpenQA.Selenium;
using BWMS.UITest.PageModel.Pages;
using BWMS.UITest.PageModel.Pages.CustomerManagement;
using BWMS.UITest.PageModel.Pages.VehicleManagement;
using BWMS.UITest.PageModel.Pages.WorkshopManagement;

namespace BWMS.UITest.PageModel
{
    public class MainMenu
    {
        private readonly BWMS _app;

        public MainMenu(BWMS app)
        {
            _app = app;
        }

        public HomePage Home()
        {
            _app.WebDriver.FindElement(By.Id("MainMenu.Home")).Click();
            return new HomePage(_app);
        }

        public CustomerManagementPage CustomerManagement()
        {
            _app.WebDriver.FindElement(By.Id("MainMenu.CustomerManagement")).Click();
            return new CustomerManagementPage(_app);
        }

        public VehicleManagementPage VehicleManagement()
        {
            _app.WebDriver.FindElement(By.Id("MainMenu.VehicleManagement")).Click();
            return new VehicleManagementPage(_app);
        }

        public WorkshopManagementPage WorkshopManagement()
        {
            _app.WebDriver.FindElement(By.Id("MainMenu.WorkshopManagement")).Click();
            return new WorkshopManagementPage(_app);
        }

        public AboutPage About()
        {
            _app.WebDriver.FindElement(By.Id("MainMenu.About")).Click();
            return new AboutPage(_app);
        }
    }
}