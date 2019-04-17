using System;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace RestaurantSearch.UITests.Framework.PageObjectModel
{
    public class SearchPage
    {
        private const string SearchUrl = "https://www.just-eat.co.uk/";
        private readonly IWebDriver _driver;

        //Identified objects from page elements
        [FindsBy(How = How.Name, Using = "postcode")]
        public IWebElement PostcodeSearchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='searchInput']")]
        public IWebElement RestaurantSearchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='onlineRestaurantsHeading']")]
        public IWebElement RestaurantHeader { get; set; }

        //Initializing the registered driver to the page elements using PageFactory
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //Re-Usable methods
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(SearchUrl);
        }
        //Including IWebElement parameter to use Search method in n other areas in the test journey
        public void Search(IWebElement searchType, string input)
        {
            searchType.Clear();
            searchType.SendKeys(input);
        }

        private string FindInPage() =>  RestaurantHeader.Text;

        public  string GetRestaurantHeader()
        {
            return  new ValidationHelper().Validate(FindInPage, "535",
                TimeSpan.FromSeconds(5), 8);
        }
        
        //Including IWebElement parameter to Click in other areas in the test journey
        public void Click(IWebElement searchOn)
        {
            searchOn.Click();
        }
    }
}
