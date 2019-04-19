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

        [FindsBy(How = How.CssSelector, Using = "[class='alpha']")]
        public IWebElement EmptySearchMessage { get; set; }

        //Initializing the registered driver to the page elements using PageFactory
        public SearchResultPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
 
        private Task<string> DefaultHeaderForGivenPostcode() => Task.FromResult(RestaurantHeader.Text);

        public void StoreDefaultHeaderForGivenPostcode() =>
            StateManager.Set(SearchValues.DefaultSubheaderForGivenPostcode.ToString(), DefaultHeaderForGivenPostcode().Result);

        public Task<List<IWebElement>> SearchResults() => Task.FromResult(RestaurantSearchResults.ToList());

        public string TotalRestaurantsForGivenPostcode() => StateManager.Get<string>(SearchValues.DefaultSubheaderForGivenPostcode.ToString()).Split(new char[] { ' ' })[0];

        public async Task<string> GetRestaurantHeaderAsync() => await ValidationHelper.ValidateAsync(DefaultHeaderForGivenPostcode, TotalRestaurantsForGivenPostcode,
                TimeSpan.FromSeconds(2));

        public Task<IWebElement> EmptySearchResultMessage() => Task.FromResult(EmptySearchMessage);
    }
}
