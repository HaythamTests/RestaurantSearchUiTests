using OpenQA.Selenium;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Models;
using RestaurantSearch.UITests.Pages;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class Search
    {
        private readonly IWebDriver _driver;
        private SearchPage _searchPage;
        private readonly SharedAction _sharedAction;

        public Search(IWebDriver driver, SharedAction sharedAction)
        {
            _driver = driver;
            _sharedAction = sharedAction;
        }
        //Before Scenario: start up
        [BeforeScenario]
        public void BeforeScenario()
        {
            _searchPage = PageFactory.InitElements<SearchPage>(_driver);
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
            StateManager.Set(Input.Postcode.ToString(), postcode);

            //Navigation to the page
            _searchPage.Navigate();

            //Search by Postcode and submit
            _sharedAction.Search(_searchPage.PostcodeSearchInput, postcode);
            _searchPage.SearchButton.Click();         
        }
    }
}
