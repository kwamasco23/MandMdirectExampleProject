using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace MandMdirectExampleProject.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private readonly IObjectContainer _container;
        private IWebDriver? _driver;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var options = new ChromeOptions();

            // Jenkins / CI safe defaults
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");

            // Block browser notifications
            options.AddUserProfilePreference(
                "profile.default_content_setting_values.notifications", 2
            );

            _driver = new ChromeDriver(options);
            _container.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _driver?.Quit();
            _driver?.Dispose();
        }
    }
}
