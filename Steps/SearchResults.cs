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
             _searchResultPage.GetSubheaderForRestaurantAsync();

            var restaurantsAvailable = await _searchResultPage.RestuarantsAvailable();
            var openRestaurantsAvailable = await _searchResultPage.OpenRestaurantsAvailable();

            //Check complete list of restaurants in the search result page
            if (restaurantsAvailable)
            {
                //Save first and last search results for the specified restaurant
                _searchResultPage.GetSearchResultsFromSearchResultPageAsync();
            }
            if (openRestaurantsAvailable)
            {
                _searchResultPage.GetOpenResturantsCountFromSearchResultPageAsync();
                _searchResultPage.GetOpenResturantsTotalFromSubheader();
            }
            if (!restaurantsAvailable)
            {
                //Save on-screen validations for the invalid search
                _searchResultPage.GetOnscreenValidationsFromSearchResultPageAsync();
            }
        }
    }
}