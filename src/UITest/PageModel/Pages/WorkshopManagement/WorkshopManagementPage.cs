using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace BWMS.UITest.PageModel.Pages.WorkshopManagement
{
    /// <summary>
    /// Represents the WorkshopManagement page.
    /// </summary>
    public class WorkshopManagementPage : MainPage
    {
        public WorkshopManagementPage(App app) : base("Workshop Management - overview", app)
        {
        }

        public RegisterMaintenanceJobPage RegisterMaintenanceJob()
        {
            WebDriver.FindElement(By.Id("RegisterMaintenanceJobButton")).Click();
            return new RegisterMaintenanceJobPage(App);
        }

        public MaintenanceJobDetailsPage SelectMaintenanceJob(string jobDescription)
        {
            WebDriver
                .FindElement(By.XPath($"//td[contains(text(),'{jobDescription}')]"))
                .Click();
            return new MaintenanceJobDetailsPage(App); 
        }
    }
}