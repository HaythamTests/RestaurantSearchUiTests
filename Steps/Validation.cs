using NUnit.Framework;
using RestaurantSearch.UITests.Framework;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class Valdiation
    {
        private readonly Framework.PageObjectModel.SearchPage _searchPage;

        public Valdiation(Framework.PageObjectModel.SearchPage searchPage)
        {
            _searchPage = searchPage;
        }

        [Given(@"I should see some (.*) in (.*)")]
        public void ThenIShouldSeeSomeRestaurantsIn(string expectedPostcode)
        {
            //Assertion on positive results
            var actualSubheaderforRestaurant = StateManager.Get<string>(SearchValues.Postcode.ToString());

            Assert.That(actualSubheaderforRestaurant.Contains(expectedPostcode));
        }

        [Given(@"I shouldn't see the (.*) and I see the error message (.*)")]
        public void ThenIShouldntSeeSomeRestaurantsIn(string restaurant, string errorMessage)
        {
            //Assertion on error result
            var actualSubheaderforRestaurant = StateManager.Get<string>(SearchValues.RestaurantSubHeader.ToString());

            Assert.That(actualSubheaderforRestaurant.Contains(errorMessage));
        }
    }
}