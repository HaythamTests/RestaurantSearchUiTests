using NUnit.Framework;
using RestaurantSearch.UITests.Helpers;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class Valdiation
    {
        private readonly Pages.SearchPage _searchPage;

        public Valdiation(Pages.SearchPage searchPage)
        {
            _searchPage = searchPage;
        }

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

            var defaultHeaderForTotalRestaurants = StateManager.Get<string>(SearchValues.DefaultSubheaderForTotalRestaurants.ToString());

            Assert.That(actualSubheaderforRestaurant.Contains(expectedPostcode));
            Assert.AreNotEqual(actualSubheaderforRestaurant, defaultHeaderForTotalRestaurants) ;
        }

        //[Given(@"I should see the restaurant name contained in the subheader")]
        //public void ThenIShouldntSeeSomeRestaurantsIn(string restaurant, string errorMessage)
        //{
        //    //Assertion on error result
        //    var actualSubheaderforRestaurant = StateManager.Get<string>(SearchValues.RestaurantSubHeader.ToString());

        //    Assert.That(actualSubheaderforRestaurant.Contains(errorMessage));
        //}
    }
}