using System;
using System.Linq;
using System.Threading.Tasks;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Pages;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class SearchResults
    {
        private readonly SearchResultPage _searchResultPage;
        private readonly SharedActions _sharedActions;

        public SearchResults(SearchResultPage searchResultPage, SharedActions sharedActions)
        {
            _searchResultPage = searchResultPage;
            _sharedActions = sharedActions;
        }

        [Given(@"I search for restaurant (.*)")]
        [When(@"I search for restaurant (.*)")]
        public async Task WhenISearchForRestaurants(string restaurant)
        {
            StateManager.Set(SearchValues.Restaurant.ToString(), restaurant);

            //Default Subheader for all restaurants
            _searchResultPage.StoreDefaultHeaderForGivenPostcode();

            //Restaurant search
            _sharedActions.Search(_searchResultPage.RestaurantSearchInput, restaurant);

            //Actual Subheader for the specified restaurant
            var subHeaderText = await _searchResultPage.GetRestaurantHeaderAsync();
            StateManager.Set(SearchValues.RestaurantSubHeader.ToString(), subHeaderText);

            if (!subHeaderText.ContainsString("No open restaurants", StringComparison.OrdinalIgnoreCase))
            {
                //Return search results for the specified restaurant
                var getSearchResults = await _searchResultPage.SearchResults();
                StateManager.Set(SearchValues.FirstSearchResult.ToString(), getSearchResults.First().Text);
                StateManager.Set(SearchValues.LastSearchResult.ToString(), getSearchResults.Last().Text);
            }
            else
            {
                var emptySearchResultMessage = await _searchResultPage.EmptySearchResultMessage();
                StateManager.Set(SearchValues.EmptySearchResultMessage.ToString(), emptySearchResultMessage);
            }
        }
    }
}