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
                // Linux Chrome location (adjust if needed)
                options.BinaryLocation = "/usr/bin/google-chrome";

                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--disable-extensions");
                options.AddArgument("--disable-infobars");
                options.AddArgument("--remote-debugging-port=9222");
                options.AddArgument("--window-size=1920,1080");
                options.AddArgument("--user-data-dir=/tmp/chrome-user-data");
            }
            else
            {
                options.AddArgument("--start-maximized");
            }

            try
            {
                var service = ChromeDriverService.CreateDefaultService();
                service.HideCommandPromptWindow = true;
                service.SuppressInitialDiagnosticInformation = true;

                _driver = new ChromeDriver(service, options);

                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

                _container.RegisterInstanceAs<IWebDriver>(_driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating ChromeDriver: {ex}");
                throw;
            }
        }

        [AfterScenario(Order = 100)]
        public void TearDown()
        {
            if (_driver != null)
            {
                try
                {
                    _driver.Quit();
                    _driver.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠ Error during WebDriver cleanup: {ex.Message}");
                }
            }
        }
    }
}