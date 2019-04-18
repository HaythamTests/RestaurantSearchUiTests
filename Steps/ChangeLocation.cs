using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class ChangeLocation
    {
        private readonly SearchPage _searchPage;

        public ChangeLocation(SearchPage searchPage)
        {
            _searchPage = searchPage;
        }

        [When(@"I change the area to (.*) using the 'Change Location' button")]
        public void IChangeTheAreaUsingTheButton(string newInput)
        {
            //Clicking on the 'Change Location' button
            //_searchPage.RestaurantHeader.FindElement(By.TagName("a")).Click();

            ////Changing postcode and submit
            //_searchPage.Search(_searchPage., newInput);
            //_searchPage.SearchButton.Click();
        }
    }
}