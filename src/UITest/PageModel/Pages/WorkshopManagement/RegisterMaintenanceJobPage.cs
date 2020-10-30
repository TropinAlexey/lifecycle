using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BWMS.UITest.PageModel.Pages.WorkshopManagement
{
    /// <summary>
    /// Represents the Register MaintenanceJob page.
    /// </summary>
    public class RegisterMaintenanceJobPage : MainPage
    {
        public RegisterMaintenanceJobPage(App app) : base("Repair - schedule maintenance", app)
        {
        }

        public RegisterMaintenanceJobPage FillJobDetails(string startTime, string endTime, string description, string Name)
        {
            var startTimeBox = WebDriver.FindElement(By.Name("From when?"));
            startTimeBox.Clear();
            startTimeBox.SendKeys(startTime);

            var endTimeBox = WebDriver.FindElement(By.Name("Until when?"));
            endTimeBox.Clear();
            endTimeBox.SendKeys(endTime);

            WebDriver.FindElement(By.Name("Please, describe a problem:")).SendKeys(description);
            
            SelectElement select = new SelectElement(WebDriver.FindElement(By.Id("SelectedName")));     //TODO: change literal to nameof(SelectedName)
            select.SelectByValue(Name);
            
            return this;
        }

        public WorkshopManagementPage Submit()
        {
            WebDriver.FindElement(By.Id("SubmitButton")).Click();
            return new WorkshopManagementPage(BWMS);
        }

        public WorkshopManagementPage Cancel()
        {
            WebDriver.FindElement(By.Id("CancelButton")).Click();
            return new WorkshopManagementPage(BWMS);
        }
    }
}