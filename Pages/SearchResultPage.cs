using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OpenQA.Selenium;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Models;
using SeleniumExtras.PageObjects;

namespace RestaurantSearch.UITests.Pages
{
    public class SearchResultPage
    {
        //Identified page elements
        [FindsBy(How = How.CssSelector, Using = "[data-test-id='searchInput']")]
        public IWebElement RestaurantSearchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='onlineRestaurantsHeading']")]
        public IWebElement RestaurantHeader { get; set; }

        [FindsBy(How = How.CssSelector,
            Using = "section[class*='is-active'] a [data-test-id='restaurant_info'] [data-test-id='restaurant_name']")]
        public IList<IWebElement> RestaurantSearchResults { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[class='alpha']")]
        public IWebElement EmptySearchMessage { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='show_all_restaurants']")]
        public IWebElement SearchButtonInvalidSearch { get; set; }

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='tip_us_off']")]
        public IWebElement TipUsOff { get; set; }

        //Initializing the registered driver to the page elements using PageFactory
        public SearchResultPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        //Page methods
        private Task<string> DefaultHeaderForGivenPostcode() => Task.FromResult(RestaurantHeader.Text);

        public void StoreDefaultHeaderForGivenPostcode() => StateManager.Set(Result.DefaultSubheaderForGivenPostcode.ToString(), DefaultHeaderForGivenPostcode().Result);

        public Task<List<IWebElement>> SearchResults() => Task.FromResult(RestaurantSearchResults.ToList());

        private static string TotalNumberOfRestaurantsForPostcode() => StateManager.Get<string>(Result.DefaultSubheaderForGivenPostcode.ToString()).Split(new char[] {' '})[0];

        private static readonly Func<string, bool> ValidateAgainstTotalRestaurantsForGivenPostcode = validation => !validation.ContainsString(TotalNumberOfRestaurantsForPostcode(), StringComparison.CurrentCulture);

        public async Task<string> GetRestaurantHeaderAsync()
        {
            await ValidationHelper.ValidateAsync(DefaultHeaderForGivenPostcode, ValidateAgainstTotalRestaurantsForGivenPostcode, TimeSpan.FromSeconds(2));
            return await DefaultHeaderForGivenPostcode();
        }

        public Task<string> EmptySearchResultMessage() => Task.FromResult(EmptySearchMessage.Text);

        public Task<string> SearchButtonInvalidSearchText() => Task.FromResult(SearchButtonInvalidSearch.Text);

        public Task<string> SearchButtonInvalidSearchLink() => Task.FromResult(SearchButtonInvalidSearch.GetAttribute("href"));

        public Task<string> TipUsOffText() => Task.FromResult(TipUsOff.Text);

        public Task<string> TipUsOffLink() => Task.FromResult(TipUsOff.GetAttribute("href"));

        public async Task GetSubheaderAsync()
        {
            var subHeaderText = await GetRestaurantHeaderAsync();
            StateManager.Set(Result.RestaurantSubHeader.ToString(), subHeaderText);
        }

        public async Task GetFirstAndLastSearchResultsFromSearchResultPageAsync()
        {
            var getSearchResults = await SearchResults();
            StateManager.Set(Result.FirstSearchResult.ToString(), getSearchResults.First().Text);
            StateManager.Set(Result.LastSearchResult.ToString(), getSearchResults.Last().Text);
        }

        public async Task GetErrorInformationFromSearchResultPageAsync()
        {
            StateManager.Set(Result.EmptySearchResultMessage.ToString(), await EmptySearchResultMessage());
            StateManager.Set(Result.SearchButtonInvalidSearchText.ToString(), await SearchButtonInvalidSearchText());
            StateManager.Set(Result.SearchButtonInvalidSearchLink.ToString(),
                await SearchButtonInvalidSearchLink());
            StateManager.Set(Result.TipUsOffText.ToString(), await TipUsOffText());
            StateManager.Set(Result.TipUsOffLink.ToString(), await TipUsOffLink());
        }
    }
}
