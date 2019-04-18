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
    }
}