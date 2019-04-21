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

        [FindsBy(How = How.CssSelector, Using = "[data-test-id='searchresults']")]
        public IWebElement RestaurantsAvailability { get; set; }

        [FindsBy(How = How.CssSelector, 
            Using = "[data-test-id='openrestaurants'] section[class*='is-active'] a [data-test-id='restaurant_info'] [data-test-id='restaurant_name']")]
        public IList<IWebElement> OpenRestaurantsResults { get; set; }

        [FindsBy(How = How.CssSelector,
            Using = "[data-test-id='openrestaurants'] section[class*='is-active']")]
        public IList<IWebElement> OpenRestaurantsAvailability { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div[class*='is-active'] h2[class='alpha']")]
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

        public Task<List<IWebElement>> OpenRestaurantsSearchResult() => Task.FromResult(OpenRestaurantsResults.ToList());

        public Task<bool> RestuarantsAvailable() => Task.FromResult(!RestaurantsAvailability.GetAttribute("class").Equals("is-visuallyHidden"));

        public Task<bool> OpenRestaurantsAvailable() => Task.FromResult(OpenRestaurantsAvailability.Any( x => x.Displayed));

        private static string NumberOfRestaurantsForPostcodeFromSubheader() => StateManager.Get<string>(Result.DefaultSubheaderForGivenPostcode.ToString()).Split(new char[] {' '})[0];

        private static readonly Func<string, bool> ValidateByTotalRestaurantsForGivenPostcode = validation => !validation.ContainsString(NumberOfRestaurantsForPostcodeFromSubheader(), StringComparison.CurrentCulture);

        public async Task<string> RestaurantHeaderAsync()
        {
            await ValidationHelper.ValidateAsync(DefaultHeaderForGivenPostcode, ValidateByTotalRestaurantsForGivenPostcode, TimeSpan.FromSeconds(2));
            return await DefaultHeaderForGivenPostcode();
        }

        public Task<string> EmptySearchResultMessage() => Task.FromResult(EmptySearchMessage.Text);

        public Task<string> SearchButtonInvalidSearchText() => Task.FromResult(SearchButtonInvalidSearch.Text);

        public Task<string> SearchButtonInvalidSearchLink() => Task.FromResult(SearchButtonInvalidSearch.GetAttribute("href"));

        public Task<string> TipUsOffText() => Task.FromResult(TipUsOff.Text);

        public Task<string> TipUsOffLink() => Task.FromResult(TipUsOff.GetAttribute("href"));

        public async void GetSubheaderForRestaurantAsync()
        {
            var subHeaderText = await RestaurantHeaderAsync();

            StateManager.Set(Result.RestaurantSubHeader.ToString(), subHeaderText);
        }

        public async Task GetSearchResultsFromSearchResultPageAsync()
        {
            var getSearchResults = await SearchResults();

            StateManager.Set(Result.FirstSearchResult.ToString(), getSearchResults.First().Text);
            StateManager.Set(Result.LastSearchResult.ToString(), getSearchResults.Last().Text);
        }

        public async Task GetOpenResturantsCountFromSearchResultPageAsync()
        {
            var getOpenRestaurantsCount = await OpenRestaurantsSearchResult();

            StateManager.Set<int>(Result.OpenRestaurantsFromSearchResult.ToString(), getOpenRestaurantsCount.Count());
        }

        public void GetOpenResturantsTotalFromSubheader()
        {
            var subheaderText = StateManager.Get<string>(Result.RestaurantSubHeader.ToString());

            StateManager.Set(Result.OpenRestaurantsCountFromSubheader.ToString(), int.Parse(subheaderText.Split(new char[] { ' ' })[0]));
        }

        public async Task GetOnscreenValidationsFromSearchResultPageAsync()
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
