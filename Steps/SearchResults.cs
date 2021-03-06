﻿using System.Security.Cryptography.X509Certificates;
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
        private readonly SearchPage _searchPage;
        public bool _openRestaurantsAvailable;

        public SearchResults(SearchResultPage searchResultPage, SearchPage searchPage)
        {
            _searchResultPage = searchResultPage;
            _searchPage = searchPage;
        }

        [Given(@"I search for restaurant (.*)")]
        [When(@"I search for restaurant (.*)")]
        public async Task WhenISearchForRestaurants(string restaurant)
        {
            StateManager.Set(Input.Restaurant.ToString(), restaurant);

            //Save default Subheader for all restaurants
            _searchResultPage.StoreDefaultHeaderForGivenPostcode();

            //Restaurant search
            _searchPage.Search(_searchResultPage.RestaurantSearchInput, restaurant);

            //Save actual Subheader for the specified restaurant
            await _searchResultPage.GetSubheaderForRestaurantAsync();            
        }

        [When(@"I wait for the restaurant results page")]
        public void WhenIWaitForRestaurantResults()
        {
            var restaurantsAvailable =  _searchResultPage.RestuarantsAvailable();
            _openRestaurantsAvailable =  _searchResultPage.OpenRestaurantsAvailable();

            //Check complete list of restaurants in the search result page
            if (restaurantsAvailable)
            {
                //Save first and last search results for the specified restaurant
                _searchResultPage.GetSearchResultsFromSearchResultPage();
            }
            if (_openRestaurantsAvailable)
            {
                _searchResultPage.GetOpenResturantsCountFromSearchResultPage();
                _searchResultPage.GetOpenResturantsTotalFromSubheader();
            }
            if (!restaurantsAvailable)
            {
                //Save on-screen validations for the invalid search
                _searchResultPage.GetOnscreenValidationsFromSearchResultPage();
            }
        }
    }
}