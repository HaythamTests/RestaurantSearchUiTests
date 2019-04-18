using System.Linq;
using System.Threading.Tasks;
using RestaurantSearch.UITests.Helpers;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class SearchResultPages
    {
        private readonly Pages.SearchPage _searchPage;

        public SearchResultPages(Pages.SearchPage searchPage)
        {
            _searchPage = searchPage;
        }

        [Given(@"I search for restaurant (.*)")]
        [When(@"I search for restaurant (.*)")]
        public async Task WhenISearchForRestaurants(string restaurant)
        {
            StateManager.Set(SearchValues.Restaurant.ToString(), restaurant);

            //Default Subheader for all restaurants
            _searchPage.StoreDefaultHeader();

            //Restaurant search
            _searchPage.Search(_searchPage.RestaurantSearchInput, restaurant);

            //Actual Subheader for the specified restaurant
            var subHeaderText = _searchPage.GetRestaurantHeader();
            StateManager.Set(SearchValues.RestaurantSubHeader.ToString(), subHeaderText);

            //Return search results for the specified restaurant
            var getSearchResults =  await _searchPage.SearchResults();
            StateManager.Set(SearchValues.FirstSearchResult.ToString(), getSearchResults.First().Text);
            StateManager.Set(SearchValues.LastSearchResult.ToString(), getSearchResults.Last().Text);
        }
    }
}