using System.Threading.Tasks;
using OpenQA.Selenium;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Pages;
using SeleniumExtras.PageObjects;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Steps
{
    [Binding]
    public class SearchPage
    {
        private readonly IWebDriver _driver;
        private Pages.SearchPage _searchPage;
        private readonly SharedActions _sharedActions;

        public SearchPage(IWebDriver driver, SharedActions sharedActions)
        {
            _driver = driver;
            _sharedActions = sharedActions;
        }
        //Before Scenario: start up
        [BeforeScenario]
        public void BeforeScenario()
        {
            _searchPage = PageFactory.InitElements<Pages.SearchPage>(_driver);
        }
        //After Scenario: clean up
        [AfterScenario]
        public void AfterScenario()
        {
            _driver.Close();
        }
        //Search for postcode
        [Given(@"I want food in area (.*)")]
        public async Task GivenIWantFoodIn(string postcode)
        {
            StateManager.Set(SearchValues.Postcode.ToString(), postcode);

            //Navigation to the page
            _searchPage.Navigate();

            //Search by Postcode and submit
            _sharedActions.Search(_searchPage.PostcodeSearchInput, postcode);
            _searchPage.SearchButton.Click();

            //Set error message
            var errorMessage = await _searchPage.GetErrorMessage();
            StateManager.Set(SearchValues.ErrorMessageOnSearchPage.ToString(), errorMessage.Text);
        }
    }
}
