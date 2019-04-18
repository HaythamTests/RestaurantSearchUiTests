using RestaurantSearch.UITests.Framework;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class SearchResultPages
    {
        private readonly Framework.PageObjectModel.SearchPage _searchPage;

        public SearchResultPages(Framework.PageObjectModel.SearchPage searchPage)
        {
            _searchPage = searchPage;
        }

        [Given(@"I search for restaurant (.*)")]
        [When(@"I search for restaurant (.*)")]
        public void WhenISearchForRestaurants(string restaurant)
        {
            //Search by restaurant
            _searchPage.Search(_searchPage.RestaurantSearchInput, restaurant);

            //Find subheader associated to search
            var subHeaderText = _searchPage.GetRestaurantHeader();

            //Saving results to StateManager
            StateManager.Set(SearchValues.RestaurantSubHeader.ToString(), subHeaderText);
        }
    }
}