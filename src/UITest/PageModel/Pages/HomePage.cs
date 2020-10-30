using OpenQA.Selenium;

namespace Pitstop.UITest.PageModel.Pages
{
    /// <summary>
    /// Represents the Home page.
    /// </summary>
    public class HomePage : PitstopPage
    {
        public HomePage(PitstopApp pitstop) : base("Lifecycle - Bike Workshop Management System"", pitstop)
        {
        }
    }
}