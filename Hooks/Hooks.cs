using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MandMdirectExampleProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {


        // define inernal reference variable
        private readonly IObjectContainer _container;
        
        //constructor
        public Hooks(IObjectContainer container)
        {
            _container = container;
        }


        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
            //adding this to ensure that tests run on Jenkins chrome headless (no GUI)

            var options = new ChromeOptions();

            // Headless Chrome for CI (Linux / Jenkins)
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");

            IWebDriver driver = new ChromeDriver(options);

            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            var options = new ChromeOptions();
            // Configure browser to block notifications
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);

            // Pass options to ChromeDriver
            IWebDriver driver = new ChromeDriver(options);
            //driver.Manage().Window.Maximize();
            driver.Manage().Window.FullScreen();

            // Register the WebDriver instance for dependency injection
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }


        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _container.Resolve<IWebDriver>();

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}