﻿using System;
using System.Threading.Tasks;
using NUnit.Framework;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Models;
using RestaurantSearch.UITests.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class Validation
    {
        private readonly SearchResultPage _searchResultPage;
        private readonly SearchPage _searchPage;

        public Validation(SearchPage searchPage, SearchResultPage searchResultPage)
        {
            _searchResultPage = searchResultPage;
            _searchPage = searchPage;
        }

        [Then(@"I should see the correct subheader details in the Search Results page")]
        public void ThenIShouldSeeThePostcodeInTheSubheader()
        {
            var actualSubheaderforRestaurant = StateManager.Get<string>(Result.RestaurantSubHeader.ToString());
            var expectedPostcode = StateManager.Get<string>(Input.Postcode.ToString());
            var defaultHeaderForTotalRestaurants = StateManager.Get<string>(Result.DefaultSubheaderForGivenPostcode.ToString());

            Assert.That(actualSubheaderforRestaurant.Contains(expectedPostcode));
            Assert.AreNotEqual(actualSubheaderforRestaurant, defaultHeaderForTotalRestaurants) ;
        }


        [Then(@"the restaurant name is included in the first and last search result titles")]
        public void ThenIShouldSeeTheRestaurantNameInTheSearhResult()
        {
            var restaurant = StateManager.Get<string>(Input.Restaurant.ToString());
            var firstSearchResult = StateManager.Get<string>(Result.FirstSearchResult.ToString());
            var lastSearchResult = StateManager.Get<string>(Result.LastSearchResult.ToString());

            Assert.That(firstSearchResult.ContainsString(restaurant, StringComparison.OrdinalIgnoreCase));
            Assert.That(lastSearchResult.ContainsString(restaurant, StringComparison.OrdinalIgnoreCase));
        }

        [Then(@"I should see the error message")]
        public async Task ThenIShouldSeeErrorMessage(Table table)
        {
            var searchResultValidations = table.CreateSet<SearchResultValidations>();
            await _searchPage.GetErrorInformationFromSearchPageAsync();

            foreach (var validation in searchResultValidations)
            {
                var actualPostcodeErrorMessage = StateManager.Get<string>(Result.RestaurantSubHeader.ToString());

                Assert.That(actualPostcodeErrorMessage.ContainsString(validation.PostCodeErrorMessage, StringComparison.OrdinalIgnoreCase));
            }
        }

        [Then(@"I should see the following texts and links on the page")]
        public async Task ThenIShouldSeeErrorMessageAsync(Table table)
        {
            var searchResultValidations = table.CreateSet<SearchResultValidations>();
            await _searchResultPage.GetErrorInformationFromSearchResultPageAsync();

            foreach (var validation in searchResultValidations)
            {
                var actualSubheaderforRestaurant = StateManager.Get<string>(Result.RestaurantSubHeader.ToString());
                var emptySearchResultMessage = StateManager.Get<string>(Result.EmptySearchResultMessage.ToString());
                var searchButtonInvalidSearchText = StateManager.Get<string>(Result.SearchButtonInvalidSearchText.ToString());
                var searchButtonInvalidSearchLink = StateManager.Get<string>(Result.SearchButtonInvalidSearchLink.ToString());
                var tipUsOffText = StateManager.Get<string>(Result.TipUsOffText.ToString());
                var tipUsOffLink = StateManager.Get<string>(Result.TipUsOffLink.ToString());

                Assert.That(emptySearchResultMessage.ContainsString(validation.EmptySearchResultMessage, StringComparison.OrdinalIgnoreCase));
                Assert.That(actualSubheaderforRestaurant.ContainsString(validation.Subheader, StringComparison.OrdinalIgnoreCase));
                Assert.That(searchButtonInvalidSearchText.ContainsString(validation.SearchButtonInvalidSearchText, StringComparison.OrdinalIgnoreCase));
                Assert.That(searchButtonInvalidSearchLink.ContainsString(validation.SearchButtonInvalidSearchLink, StringComparison.OrdinalIgnoreCase));
                Assert.That(tipUsOffText.ContainsString(validation.TipUsOffText, StringComparison.OrdinalIgnoreCase));
                Assert.That(tipUsOffLink.ContainsString(validation.TipUsOffLink, StringComparison.OrdinalIgnoreCase));
            }
        }
    }
}