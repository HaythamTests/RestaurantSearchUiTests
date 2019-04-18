using System.Linq;
using System.Threading.Tasks;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Pages;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class SearchResultPages
    {
        private readonly SearchResultPage _searchResultPage;
        private readonly SharedActions _sharedActions;

        public SearchResultPages(SearchResultPage searchResultPage, SharedActions sharedActions)
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
            _searchResultPage.StoreDefaultHeader();

            //Restaurant search
            _sharedActions.Search(_searchResultPage.RestaurantSearchInput, restaurant);

            //Actual Subheader for the specified restaurant
            var subHeaderText = _searchResultPage.GetRestaurantHeader();
            StateManager.Set(SearchValues.RestaurantSubHeader.ToString(), subHeaderText);

            //Return search results for the specified restaurant
            var getSearchResults =  await _searchResultPage.SearchResults();
            StateManager.Set(SearchValues.FirstSearchResult.ToString(), getSearchResults.First().Text);
            StateManager.Set(SearchValues.LastSearchResult.ToString(), getSearchResults.Last().Text);
        }
    }
}