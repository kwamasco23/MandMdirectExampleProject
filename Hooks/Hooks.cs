using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using BoDi;
using System;

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

        [BeforeScenario(Order = 0)]
        public void CreateWebDriver()
        {
            if (_container.IsRegistered<IWebDriver>())
                return;

            bool isCI =
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI")) ||
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("JENKINS_HOME")) ||
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BUILD_NUMBER"));

            var options = new ChromeOptions();

            if (isCI)
            {
                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--window-size=1920,1080");
            }
            else
            {
                options.AddArgument("--start-maximized");
            }

            // 🔑 Selenium Manager handles driver matching automatically
            _driver = new ChromeDriver(options);

            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

            _container.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario(Order = 100)]
        public void TearDown()
        {
            if (_container.IsRegistered<IWebDriver>())
            {
                var driver = _container.Resolve<IWebDriver>();
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}
