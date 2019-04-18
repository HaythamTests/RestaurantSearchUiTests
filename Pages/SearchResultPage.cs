using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RestaurantSearch.UITests.Helpers;
using SeleniumExtras.PageObjects;

namespace RestaurantSearch.UITests.Pages
{
    public class SearchResultPage
    { 
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='searchInput']")]
        public IWebElement RestaurantSearchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='onlineRestaurantsHeading']")]
        public IWebElement RestaurantHeader { get; set; }

        [FindsBy(How = How.CssSelector, Using = "section[class*='is-active'] a [data-test-id='restaurant_info'] [data-test-id='restaurant_name']")]
        public IList<IWebElement> RestaurantSearchResults { get; set; }

        //Initializing the registered driver to the page elements using PageFactory
        public SearchResultPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
 
        private string DefaultHeader() => RestaurantHeader.Text;

        public void StoreDefaultHeader() =>
            StateManager.Set(SearchValues.DefaultSubheaderForTotalRestaurants.ToString(), DefaultHeader());

        public Task<List<IWebElement>> SearchResults() => Task.FromResult(RestaurantSearchResults.ToList());

        public string GetRestaurantHeader()
        {
            var totalRestaurants = StateManager.Get<string>(SearchValues.DefaultSubheaderForTotalRestaurants.ToString()).Split(new char[] { ' ' })[0];

            return new ValidationHelper().Validate(DefaultHeader, totalRestaurants,
                TimeSpan.FromSeconds(2));
        }
    }
}
