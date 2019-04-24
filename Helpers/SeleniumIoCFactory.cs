using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(@"chromedriver.exe");
            service.SuppressInitialDiagnosticInformation = true;
            service.HideCommandPromptWindow = true;
            _objectContainer.RegisterInstanceAs<IWebDriver>(new ChromeDriver(service));
        }
    }
}
