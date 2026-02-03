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

        [BeforeScenario]
        public void FirstBeforeScenario()
        {
            try
            {
                // Detect if running in CI environment
                bool isCI = IsRunningInCI();
                Console.WriteLine($"[Hooks] Running in CI: {isCI}");

                var options = new ChromeOptions();

                if (isCI)
                {
                    // CI Environment - Headless mode
                    Console.WriteLine("[Hooks] Configuring Chrome for CI (headless mode)");
                    options.AddArgument("--headless=new");
                    options.AddArgument("--no-sandbox");
                    options.AddArgument("--disable-dev-shm-usage");
                    options.AddArgument("--disable-gpu");
                    options.AddArgument("--window-size=1920,1080");
                    options.AddArgument("--disable-extensions");
                    options.AddArgument("--disable-software-rasterizer");
                }
                else
                {
                    // Local Development - Visible browser
                    Console.WriteLine("[Hooks] Configuring Chrome for local development (visible mode)");
                    options.AddArgument("--start-maximized");
                }

                _driver = new ChromeDriver(options);

                // Configure timeouts
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

                _container.RegisterInstanceAs<IWebDriver>(_driver);
                Console.WriteLine("[Hooks] WebDriver initialized successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Hooks] ERROR initializing WebDriver: {ex.Message}");
                Console.WriteLine($"[Hooks] Stack trace: {ex.StackTrace}");
                throw;
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            try
            {
                if (_driver != null)
                {
                    Console.WriteLine("[Hooks] Closing WebDriver");
                    _driver.Quit();
                    _driver.Dispose();
                    _driver = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Hooks] ERROR during cleanup: {ex.Message}");
            }
        }

        private bool IsRunningInCI()
        {
            // Check multiple CI environment indicators
            var ciEnv = Environment.GetEnvironmentVariable("CI");
            var jenkinsHome = Environment.GetEnvironmentVariable("JENKINS_HOME");
            var buildNumber = Environment.GetEnvironmentVariable("BUILD_NUMBER");

            return !string.IsNullOrEmpty(ciEnv) ||
                   !string.IsNullOrEmpty(jenkinsHome) ||
                   !string.IsNullOrEmpty(buildNumber);
        }
    }
}