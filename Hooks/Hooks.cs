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
            // If a driver is already registered, skip
            if (_container.IsRegistered<IWebDriver>())
                return;

            // Detect if we are running in CI (Jenkins, GitHub Actions, etc.)
            bool isCI =
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("CI")) ||
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("JENKINS_HOME")) ||
                !string.IsNullOrEmpty(Environment.GetEnvironmentVariable("BUILD_NUMBER"));

            var options = new ChromeOptions();

            if (isCI)
            {
                // Linux/EC2 Chrome path
                options.BinaryLocation = "/usr/bin/google-chrome";

                // Headless options for CI
                options.AddArgument("--headless");                   // stable headless
                options.AddArgument("--no-sandbox");                 // required on Linux
                options.AddArgument("--disable-dev-shm-usage");      // avoid shared memory issues
                options.AddArgument("--disable-gpu");                // headless stability
                options.AddArgument("--window-size=1920,1080");      // large viewport
                options.AddArgument("--remote-debugging-port=9222"); // fix DevToolsActivePort error
            }
            else
            {
                // Local dev mode
                options.AddArgument("--start-maximized");
            }

            try
            {
                // Create ChromeDriver using Selenium Manager (auto-downloads driver)
                _driver = new ChromeDriver(options);

                // Set implicit wait and page load timeout
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

                // Register driver in DI container
                _container.RegisterInstanceAs<IWebDriver>(_driver);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ Error creating ChromeDriver: {ex.Message}");
                throw; // fail fast so CI logs the issue
            }
        }

        [AfterScenario(Order = 100)]
        public void TearDown()
        {
            if (_container.IsRegistered<IWebDriver>())
            {
                try
                {
                    var driver = _container.Resolve<IWebDriver>();
                    driver.Quit();
                    driver.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"⚠ Error during WebDriver cleanup: {ex.Message}");
                }
            }
        }
    }
}
