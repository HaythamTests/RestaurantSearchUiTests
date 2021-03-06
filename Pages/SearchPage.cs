﻿using OpenQA.Selenium;
using RestaurantSearch.UITests.Helpers;
using RestaurantSearch.UITests.Models;
using SeleniumExtras.PageObjects;

namespace RestaurantSearch.UITests.Pages
{
    public class SearchPage
    {
        private const string SearchUrl = "https://www.just-eat.co.uk/";
        private readonly IWebDriver _driver;

        //Identified page elements
        [FindsBy(How = How.Name, Using = "postcode")]
        public IWebElement PostcodeSearchInput { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button[type='submit']")]
        public IWebElement SearchButton { get; set; }

        [FindsBy(How = How.Id, Using = "errorMessage")]
        public IWebElement ErrorMessage { get; set; }

        //Initializing the registered driver to the page elements using PageFactory
        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        //Navigate to page
        public void Navigate()
        {
            _driver.Navigate().GoToUrl(SearchUrl);
        }

        public void Search(IWebElement searchType, string input)
        {
            searchType.Clear();
            searchType.SendKeys(input);
        }

        //Page method
        public string PostCodeErrorMessage() => ErrorMessage.Text;

        public void GetErrorInformationFromSearchPage()
        {
            StateManager.Set(Result.PostCodeErrorMessage.ToString(), PostCodeErrorMessage());

        }
    }
}
