using OpenQA.Selenium;

namespace RestaurantSearch.UITests.Pages
{
    public class SharedAction
    {
        //Useful journey functions
        public void Search(IWebElement searchType, string input)
        {
            searchType.Clear();
            searchType.SendKeys(input);
        }

        public void Click(IWebElement searchOn)
        {
            searchOn.Click();
        }
    }
}
