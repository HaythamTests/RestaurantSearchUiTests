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

        public List<IWebElement> SearchResults() => RestaurantSearchResults.ToList();

        public List<IWebElement> OpenRestaurantsSearchResult() => OpenRestaurantsResults.ToList();

        public bool RestuarantsAvailable() => !RestaurantsAvailability.GetAttribute("class").Equals("is-visuallyHidden");

        public bool OpenRestaurantsAvailable() => OpenRestaurantsAvailability.Any( x => x.Displayed);

        private static string NumberOfRestaurantsForPostcodeFromSubheader() => StateManager.Get<string>(Result.DefaultSubheaderForGivenPostcode.ToString()).Split(new char[] {' '})[0];

        private static readonly Func<string, bool> ValidateByTotalRestaurantsForGivenPostcode = validation => !validation.ContainsString(NumberOfRestaurantsForPostcodeFromSubheader(), StringComparison.CurrentCulture);

        public async Task<string> RestaurantHeaderAsync()
        {
            await ValidationHelper.ValidateAsync(DefaultHeaderForGivenPostcode, ValidateByTotalRestaurantsForGivenPostcode, TimeSpan.FromSeconds(2));
            return await DefaultHeaderForGivenPostcode();
        }

        public string EmptySearchResultMessage() => EmptySearchMessage.Text;

        public string SearchButtonInvalidSearchText() => SearchButtonInvalidSearch.Text;

        public string SearchButtonInvalidSearchLink() => SearchButtonInvalidSearch.GetAttribute("href");

        public string TipUsOffText() => TipUsOff.Text;

        public string TipUsOffLink() => TipUsOff.GetAttribute("href");

        public async Task GetSubheaderForRestaurantAsync()
        {
            var subHeaderText = await RestaurantHeaderAsync();

            StateManager.Set(Result.RestaurantSubHeader.ToString(), subHeaderText);
        }

        public void GetSearchResultsFromSearchResultPage()
        {
            var getSearchResults = SearchResults();

            StateManager.Set(Result.FirstSearchResult.ToString(), getSearchResults.First().Text);
            StateManager.Set(Result.LastSearchResult.ToString(), getSearchResults.Last().Text);
        }

        public void GetOpenResturantsCountFromSearchResultPage()
        {
            var getOpenRestaurantsCount = OpenRestaurantsSearchResult();

            StateManager.Set<int>(Result.OpenRestaurantsFromSearchResult.ToString(), getOpenRestaurantsCount.Count());
        }

        public void GetOpenResturantsTotalFromSubheader()
        {
            var subheaderText = StateManager.Get<string>(Result.RestaurantSubHeader.ToString());

            StateManager.Set(Result.OpenRestaurantsCountFromSubheader.ToString(), int.Parse(subheaderText.Split(new char[] { ' ' })[0]));
        }

        public void GetOnscreenValidationsFromSearchResultPage()
        {
            StateManager.Set(Result.EmptySearchResultMessage.ToString(), EmptySearchResultMessage());
            StateManager.Set(Result.SearchButtonInvalidSearchText.ToString(), SearchButtonInvalidSearchText());
            StateManager.Set(Result.SearchButtonInvalidSearchLink.ToString(), SearchButtonInvalidSearchLink());
            StateManager.Set(Result.TipUsOffText.ToString(), TipUsOffText());
            StateManager.Set(Result.TipUsOffLink.ToString(), TipUsOffLink());
        }
    }
}
