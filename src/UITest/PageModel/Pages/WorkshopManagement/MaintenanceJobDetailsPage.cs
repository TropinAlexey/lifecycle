using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BWMS.UITest.PageModel.Pages.WorkshopManagement
{
    /// <summary>
    /// Represents the MaintenanceJob Details page.
    /// </summary>
    public class MaintenanceJobDetailsPage : MainPage
    {        
        public MaintenanceJobDetailsPage(App app) : base("Workshop Management - details", app)
        {
        }

        public FinishMaintenanceJobPage Complete()
        {
            WebDriver.FindElement(By.Id("CompleteButton")).Click();
            return new FinishMaintenanceJobPage(App);
        }

        public WorkshopManagementPage Back()
        {
            WebDriver.FindElement(By.Id("BackButton")).Click();
            return new WorkshopManagementPage(App);
        }

        public MaintenanceJobDetailsPage GetJobStatus(out string status)
        {
            status = WebDriver.FindElement(By.Id("JobStatus")).Text;
            return this;
        }
    }
}