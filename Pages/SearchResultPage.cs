using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        [FindsBy(How = How.CssSelector,
            Using = "section[class*='is-active'] a [data-test-id='restaurant_info'] [data-test-id='restaurant_name']")]
        public IList<IWebElement> RestaurantSearchResults { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class='alpha']")]
        public IWebElement EmptySearchMessage { get; set; }

        //Initializing the registered driver to the page elements using PageFactory
        public SearchResultPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        private Task<string> DefaultHeaderForGivenPostcode() => Task.FromResult(RestaurantHeader.Text);

        public void StoreDefaultHeaderForGivenPostcode() => StateManager.Set(SearchValues.DefaultSubheaderForGivenPostcode.ToString(), DefaultHeaderForGivenPostcode().Result);

        public Task<List<IWebElement>> SearchResults() => Task.FromResult(RestaurantSearchResults.ToList());

        private static string TotalNumberOfRestaurantsForPostcode() => StateManager.Get<string>(SearchValues.DefaultSubheaderForGivenPostcode.ToString()).Split(new char[] {' '})[0];

        private static readonly Func<string, bool> ValidateAgainstTotalRestaurantsForGivenPostcode = validation => !validation.ContainsString(TotalNumberOfRestaurantsForPostcode(), StringComparison.CurrentCulture);

        public async Task<string> GetRestaurantHeaderAsync()
        {
            await ValidationHelper.ValidateAsync(DefaultHeaderForGivenPostcode, ValidateAgainstTotalRestaurantsForGivenPostcode, TimeSpan.FromSeconds(2));
            return await DefaultHeaderForGivenPostcode();
        }

        public Task<string> EmptySearchResultMessage() => Task.FromResult(EmptySearchMessage.Text);

        public async Task<IEnumerable<string>> GetErrorMessagesFromSearchResultPage()
        {
            var errorMessages = new List<string>();
            errorMessages.Add(await EmptySearchResultMessage());
            errorMessages.Add(await GetRestaurantHeaderAsync());
            return errorMessages;
        }
    }
}
