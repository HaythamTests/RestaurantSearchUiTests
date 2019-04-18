//using System;
//using OpenQA.Selenium;
//using RestaurantSearch.UITests.Helpers;
//using SeleniumExtras.PageObjects;

//namespace RestaurantSearch.UITests.Pages
//{
//    public class SearchResultPage
//    {

//        //Identified objects from page elements

//        [FindsBy(How = How.CssSelector, Using = "[data-test-id='searchInput']")]
//        public IWebElement RestaurantSearchInput { get; set; }

//        [FindsBy(How = How.CssSelector, Using = "[data-test-id='onlineRestaurantsHeading']")]
//        public IWebElement RestaurantHeader { get; set; }

//        [FindsBy(How = How.CssSelector, Using = "section[class*='is-active'] a [data-test-id='restaurant_info'] [data-test-id='restaurant_name']")]
//        public IWebElement RestaurantSearchResults { get; set; }

//        //Initializing the registered driver to the page elements using PageFactory
//        public SearchResultPage(IWebDriver driver)
//        {
//            PageFactory.InitElements(driver, this);
//        }
//        //Re-Usable methods

//        //Including IWebElement parameter to use Search method in n other areas in the test journey
//        public void Search(IWebElement searchType, string input)
//        {
//            searchType.Clear();
//            searchType.SendKeys(input);
//        }

//        private string DefaultHeader() =>  RestaurantHeader.Text;

      
//        public void StoreDefaultHeader() =>
//            StateManager.Set(SearchValues.DefaultSubheaderForTotalRestaurants.ToString(), DefaultHeader());

//        public  string GetRestaurantHeader()
//        {
//            var totalRestaurants = StateManager.Get<string>(SearchValues.DefaultSubheaderForTotalRestaurants.ToString()).Split(new char[] { ' ' })[0];

//            return  new ValidationHelper().Validate(DefaultHeader, totalRestaurants,
//                TimeSpan.FromSeconds(5), 8);
//        }
        
//        //Including IWebElement parameter to Click in other areas in the test journey
//        public void Click(IWebElement searchOn)
//        {
//            searchOn.Click();
//        }
//    }
//}
