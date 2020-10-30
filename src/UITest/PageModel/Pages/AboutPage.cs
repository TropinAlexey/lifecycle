using OpenQA.Selenium;

namespace BWMS.UITest.PageModel.Pages
{
    /// <summary>
    /// Represents the About page.
    /// </summary>
    public class AboutPage : MainPage
    {
        public AboutPage(App app) : base("About Pitstop", app)
        {
        }
    }
}