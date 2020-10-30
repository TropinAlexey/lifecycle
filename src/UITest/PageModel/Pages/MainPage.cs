using OpenQA.Selenium;

namespace BWMS.UITest.PageModel.Pages
{
    /// <summary>
    /// Base class for all the pages.
    /// </summary>
    public class MainPage
    {
        public string Title { get; }
        public App App { get; }

        public IWebDriver WebDriver => Pitstop.WebDriver;


        /// <summary>
        /// Initialize a new MainPage instance.
        /// </summary>
        /// <param name="title">The title on the page. This is the text shown as standard title on the page (not the browser window-title!).</param>
        /// <param name="pitstop">The WebApp instance used for the test.</param>
        public MainPage(string title, App app)
        {
            Title = title;
            App = app;
        }

        /// <summary>
        /// Indication whether the page with the title of the page is shown.
        /// </summary>
        public bool IsActive()
        {
            var header = WebDriver
                .FindElement(By.Id("PageTitle"));       //TODO: change literal to nameof(PageTitle)
            return header.Text == Title;
        }

        /// <summary>
        /// Gets the current page with the title of the page being shown.
        /// </summary>
        public MainPage GetActivePageTitle(out string pageTitle)
        {
            var header = WebDriver
                .FindElement(By.Id("PageTitle"));
            pageTitle = header.Text;
            return this;
        }
    }
}