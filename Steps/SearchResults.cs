using System;
using System.Threading.Tasks;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Models;
using RestaurantSearch.UITests.Pages;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class SearchResults
    {
        private readonly SearchResultPage _searchResultPage;
        private readonly SharedAction _sharedAction;

        public SearchResults(SearchResultPage searchResultPage, SharedAction sharedActions)
        {
            _searchResultPage = searchResultPage;
            _sharedAction = sharedActions;
        }

        [Given(@"I search for restaurant (.*)")]
        [When(@"I search for restaurant (.*)")]
        public async Task WhenISearchForRestaurants(string restaurant)
        {
            StateManager.Set(Input.Restaurant.ToString(), restaurant);

            //Save default Subheader for all restaurants
            _searchResultPage.StoreDefaultHeaderForGivenPostcode();

            //Restaurant search
            _sharedAction.Search(_searchResultPage.RestaurantSearchInput, restaurant);

            //Save actual Subheader for the specified restaurant
            await _searchResultPage.GetSubheaderAsync();

            if (!StateManager.Get<string>(Result.RestaurantSubHeader.ToString()).ContainsString("No open restaurants", StringComparison.OrdinalIgnoreCase))
            {
                //Save first and last search results for the specified restaurant
                await _searchResultPage.GetFirstAndLastSearchResultsFromSearchResultPageAsync();
            }
            else
            {
                //Save error information for the invalid search
                await _searchResultPage.GetErrorInformationFromSearchResultPageAsync();
            }
        }
    }
}