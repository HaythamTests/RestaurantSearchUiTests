using System;
using System.Linq;
using NUnit.Framework;
using RestaurantSearch.UITests.Helpers;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class Valdiation
    {
        //[Given(@"I should see the restaurant name contained in the subheaderdfddf")]
        //public void ThenIShouldSeeSomeRestaurantsIn(string expectedPostcode)
        //{
        //    //Assertion on positive results
        //    var actualSubheaderforRestaurant = StateManager.Get<string>(SearchValues.Postcode.ToString());

        //    Assert.That(actualSubheaderforRestaurant.Contains(expectedPostcode));
        //}

        //[Then(@"I should see the restaurant name contained in the subheader")]
        //public void ThenIShouldSeeTheRestaurantNameInTheSubheader()
        //{
        //    var actualSubheaderforRestaurant = StateManager.Get<string>(SearchValues.RestaurantSubHeader.ToString());

        //    var expectedRestaurantName = StateManager.Get<string>(SearchValues.Restaurant.ToString());

        //    Assert.That(actualSubheaderforRestaurant.Contains(expectedRestaurantName));
        //}

        [Then(@"I should see the correct details in the subheader")]
        public void ThenIShouldSeeThePostcodeInTheSubheader()
        {
            var actualSubheaderforRestaurant = StateManager.Get<string>(SearchValues.RestaurantSubHeader.ToString());
            var expectedPostcode = StateManager.Get<string>(SearchValues.Postcode.ToString());
            var defaultHeaderForTotalRestaurants = StateManager.Get<string>(SearchValues.DefaultSubheaderForGivenPostcode.ToString());

            Assert.That(actualSubheaderforRestaurant.Contains(expectedPostcode));
            Assert.AreNotEqual(actualSubheaderforRestaurant, defaultHeaderForTotalRestaurants) ;
        }


        [Then(@"the restaurant name is included in the first and last search results")]
        public void ThenIShouldSeeTheRestaurantNameInTheSearhResult()
        {
            var restaurant = StateManager.Get<string>(SearchValues.Restaurant.ToString());
            var firstSearchResult = StateManager.Get<string>(SearchValues.FirstSearchResult.ToString());
            var lastSearchResult = StateManager.Get<string>(SearchValues.LastSearchResult.ToString());

            Assert.That(firstSearchResult.ContainsString(restaurant, StringComparison.OrdinalIgnoreCase));
            Assert.That(lastSearchResult.ContainsString(restaurant, StringComparison.OrdinalIgnoreCase));
        }


        [Then(@"I should see the message (.*)")]
        public void ThenIShouldSeeErrorMessage(string errorMessage)
        {
            var actualErrorMessage = StateManager.Get<string>(SearchValues.ErrorMessageOnSearchPage.ToString());

            Assert.AreEqual(errorMessage, actualErrorMessage);
        }

        [Then(@"I should see the following messages on the page")]
        public void ThenIShouldSeeErrorMessage(Table table)
        {
            var searchResultValidations = table.CreateSet<SearchResultValidations>();

            //var f = errorMessages.GetEnumerator<"">()

            var actualErrorMessage = StateManager.Get<string>(SearchValues.ErrorMessageOnSearchPage.ToString());

            //Assert.AreEqual(errorMessage, actualErrorMessage);
        }
    }
}