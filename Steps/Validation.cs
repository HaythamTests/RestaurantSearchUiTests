using System.Linq;
using System.Threading.Tasks;
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
        private readonly SearchPage _searchPage;
        private readonly SearchResults _searchResults;
        private readonly string _openRestaurantUnavailableSubheader = "No open restaurants";

    
        public Validation(SearchPage searchPage, SearchResults searchResults)
        {
            _searchPage = searchPage;
            _searchResults = searchResults;
        }    
        
        [Then(@"I should see the correct subheader details in the search results page")]
        public void ThenIShouldSeeThePostcodeInTheSubheader()
        {
            var subheaderAfterRestaurantSearch = StateManager.Get<string>(Result.RestaurantSubHeader.ToString());
            var expectedPostcode = StateManager.Get<string>(Input.Postcode.ToString());
            var defaultHeaderForTotalRestaurants = StateManager.Get<string>(Result.DefaultSubheaderForGivenPostcode.ToString());

            ValidationHelper.AssertTrue(subheaderAfterRestaurantSearch, expectedPostcode);

            ValidationHelper.AssertNotEqual(subheaderAfterRestaurantSearch, defaultHeaderForTotalRestaurants);
        }

        [Then(@"the restaurant name is included in the first and last search result titles")]
        public void ThenIShouldSeeTheRestaurantNameInTheSearhResult()
        {
            var searchedRestaurant = StateManager.Get<string>(Input.Restaurant.ToString());
            var firstSearchResult = StateManager.Get<string>(Result.FirstSearchResult.ToString());
            var lastSearchResult = StateManager.Get<string>(Result.LastSearchResult.ToString());

            ValidationHelper.AssertTrue(firstSearchResult, searchedRestaurant);

            ValidationHelper.AssertTrue(lastSearchResult, searchedRestaurant);
        }

        [Then(@"the search result count is reflected in the subheader")]
        public void ThenTheSearchResultCountReflectsTheDetailsInTheSubHeader()
        {
            if (_searchResults._openRestaurantsAvailable)
            {
                var openRestaurantsSubHeaderValue = StateManager.Get<int>(Result.OpenRestaurantsCountFromSubheader.ToString());
                var openRestaurantsSearchResultCount = StateManager.Get<int>(Result.OpenRestaurantsFromSearchResult.ToString());

                ValidationHelper.AssertEqual(openRestaurantsSearchResultCount, openRestaurantsSubHeaderValue);
            }
            else
            {
                var subheaderAfterRestaurantSearch = StateManager.Get<string>(Result.RestaurantSubHeader.ToString());

                ValidationHelper.AssertTrue(subheaderAfterRestaurantSearch, _openRestaurantUnavailableSubheader);
            }
        }

        [Then(@"I should see the error message")]
        public async Task ThenIShouldSeeErrorMessageAsync(Table table)
        {
            var searchResultValidations = table.CreateSet<SearchResultValidations>();
            await _searchPage.GetErrorInformationFromSearchPageAsync();

            var actualPostcodeErrorMessage = StateManager.Get<string>(Result.PostCodeErrorMessage.ToString());

            foreach (var expected in searchResultValidations)
            {
                ValidationHelper.AssertTrue(actualPostcodeErrorMessage, expected.PostCodeErrorMessage);
            }
           
        }

        [Then(@"I should see the following texts and links on the page")]
        public void ThenIShouldSeeErrorMessagesOnPage(Table table)
        {
            var searchResultValidations = table.CreateSet<SearchResultValidations>();

            var actualSubheaderforRestaurant = StateManager.Get<string>(Result.RestaurantSubHeader.ToString());
            var emptySearchResultMessage = StateManager.Get<string>(Result.EmptySearchResultMessage.ToString());
            var searchButtonInvalidSearchText = StateManager.Get<string>(Result.SearchButtonInvalidSearchText.ToString());
            var searchButtonInvalidSearchLink = StateManager.Get<string>(Result.SearchButtonInvalidSearchLink.ToString());
            var tipUsOffText = StateManager.Get<string>(Result.TipUsOffText.ToString());
            var tipUsOffLink = StateManager.Get<string>(Result.TipUsOffLink.ToString());

            foreach (var expected in searchResultValidations)
            {
                ValidationHelper.AssertTrue(actualSubheaderforRestaurant, expected.Subheader);

                ValidationHelper.AssertTrue(emptySearchResultMessage, expected.EmptySearchResultMessage);

                ValidationHelper.AssertTrue(searchButtonInvalidSearchText, expected.SearchButtonText);

                ValidationHelper.AssertTrue(searchButtonInvalidSearchLink, expected.SearchButtonLink);

                ValidationHelper.AssertTrue(tipUsOffText, expected.TipUsOffText);

                ValidationHelper.AssertTrue(tipUsOffLink, expected.TipUsOffLink);
            }
        }
    }
}