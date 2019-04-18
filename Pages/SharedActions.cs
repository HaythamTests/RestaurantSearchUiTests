using OpenQA.Selenium;

namespace RestaurantSearch.UITests.Pages
{
    public class SharedActions
    {
        //Useful journey functions
        public void Search(IWebElement searchType, string input)
        {
            searchType.Clear();
            searchType.SendKeys(input);
        }

        //Including IWebElement parameter to Click in other areas in the test journey
        public void Click(IWebElement searchOn)
        {
            searchOn.Click();
        }
    }
}
