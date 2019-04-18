using OpenQA.Selenium;
using RestaurantSearch.UITests.Framework;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class SearchPage
    {
        private readonly IWebDriver _driver;
        private Framework.PageObjectModel.SearchPage _searchPage;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
        }
        //Before Scenario: start up
        [BeforeScenario]
        public void BeforeScenario()
        {
            _searchPage = PageFactory.InitElements<Framework.PageObjectModel.SearchPage>(_driver);
        }
        //After Scenario: clean up
        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
        }
        //Search for postcode
        [Given(@"I want food in area (.*)")]
        public void GivenIWantFoodIn(string postcode)
        {
            StateManager.Set(SearchValues.Postcode.ToString(), postcode);

            //Navigation to the page
            _searchPage.Navigate();

            //Search by Postcode and submit
            _searchPage.Search(_searchPage.PostcodeSearchInput, postcode);
            _searchPage.SearchButton.Click();
        }
    }
}
