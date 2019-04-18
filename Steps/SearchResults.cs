using System;
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
            StateManager.Set(SearchValues.Restaurant.ToString(), restaurant);

            StoreDefaultHeader();

            //Restaurant search
            _searchPage.Search(_searchPage.RestaurantSearchInput, restaurant);

            //Subheader
            var subHeaderText = _searchPage.GetRestaurantHeader();

            //Set test values
            StateManager.Set(SearchValues.RestaurantSubHeader.ToString(), subHeaderText);
        }

        private void StoreDefaultHeader()
        {
            throw new NotImplementedException();
        }
    }
}