using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace RestaurantSearch.UITests.Helpers
{
    [Binding]
    public class SeleniumIoCFactory
    {
        private readonly IObjectContainer _objectContainer;

        public SeleniumIoCFactory(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }
        //Registering ChromeDriver
        [BeforeScenario(Order = 0)]
        public void InitializeWebDriver()
        {
            var driver = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }
    }
}
