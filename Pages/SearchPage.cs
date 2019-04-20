using System.Threading.Tasks;
using OpenQA.Selenium;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Models;
using SeleniumExtras.PageObjects;

namespace RestaurantSearch.UITests.Pages
{
    public class SearchPage
    {
        private const string SearchUrl = "https://www.just-eat.co.uk/";
        private readonly IWebDriver _driver;

        //Identified page elements
        [FindsBy(How = How.Name, Using = "postcode")]
        public IWebElement PostcodeSearchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[id='errorMessage']")]
        public IWebElement ErrorMessage { get; set; }

        //Initializing the registered driver to the page elements using PageFactory
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //Navigate to page
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(SearchUrl);
        }

        //Page method
        public Task<string> PostCodeErrorMessage() => Task.FromResult(ErrorMessage.Text);

        public async Task GetErrorInformationFromSearchPageAsync()
        {
            StateManager.Set(Result.PostCodeErrorMessage.ToString(), await PostCodeErrorMessage());

        }
    }
}
