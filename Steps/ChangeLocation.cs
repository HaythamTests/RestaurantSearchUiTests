using NUnit.Framework;
using OpenQA.Selenium;
using RestaurantSearch.UITests.Framework;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class ChangeLocation
    {
        private readonly Framework.PageObjectModel.SearchPage _searchPage;

        public ChangeLocation(Framework.PageObjectModel.SearchPage searchPage)
        {
            _searchPage = searchPage;
        }

        [When(@"I change the area to (.*) using the 'Change Location' button")]
        public void IChangeTheAreaUsingTheButton(string newInput)
        {
            //Clicking on the 'Change Location' button
            _searchPage.RestaurantHeader.FindElement(By.TagName("a")).Click();

            //Changing postcode and submit
            _searchPage.Search(_searchPage.PostcodeSearchInput, newInput);
            _searchPage.SearchButton.Click();
        }

        [Then(@"I should see some (.*) in (.*)")]
        public void ThenIShouldSeeSomeRestaurantsIn(string expectedPostcode)
        {
            //Assertion on positive results
            var actualSubheaderforRestaurant = StateManager.Get<string>(SearchValues.Postcode.ToString());

            Assert.That(actualSubheaderforRestaurant.Contains(expectedPostcode));
        }

        [Then(@"I shouldn't see the (.*) and I see the error message (.*)")]
        public void ThenIShouldntSeeSomeRestaurantsIn(string restaurant, string errorMessage)
        {
            //Assertion on error result
            var actualSubheaderforRestaurant = StateManager.Get<string>(SearchValues.RestaurantSubHeader.ToString());

            Assert.That(actualSubheaderforRestaurant.Contains(errorMessage));
        }
    }
}