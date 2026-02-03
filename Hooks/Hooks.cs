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
        public void FirstBeforeScenario()
        {
            var options = new ChromeOptions();

            // Detect CI environment (Jenkins sets JENKINS_HOME, BUILD_NUMBER, or CI variable)
            var isCi = Environment.GetEnvironmentVariable("CI") == "true"
                       || Environment.GetEnvironmentVariable("JENKINS_HOME") != null
                       || Environment.GetEnvironmentVariable("BUILD_NUMBER") != null;

            if (isCi)
            {
                // Jenkins / CI safe defaults
                options.AddArgument("--headless=new");
                options.AddArgument("--no-sandbox");
                options.AddArgument("--disable-dev-shm-usage");
                options.AddArgument("--disable-gpu");
                options.AddArgument("--window-size=1920,1080");
                options.AddArgument("--disable-extensions");
                options.AddArgument("--disable-web-security");
                options.AddArgument("--ignore-certificate-errors");

                Console.WriteLine("Running in CI mode (headless)");
            }
            else
            {
                // Local development
                options.AddArgument("--start-maximized");

                Console.WriteLine("Running in local mode (headed)");
            }

            // Common options for both environments
            options.AddArgument("--disable-blink-features=AutomationControlled");
            options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);
            options.AddUserProfilePreference("credentials_enable_service", false);
            options.AddUserProfilePreference("profile.password_manager_enabled", false);

            try
            {
                _driver = new ChromeDriver(options);
                _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(30);

                _container.RegisterInstanceAs<IWebDriver>(_driver);

                Console.WriteLine("WebDriver initialized successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to initialize WebDriver: {ex.Message}");
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
                    _driver.Quit();
                    _driver.Dispose();
                    _driver = null;

                    Console.WriteLine("WebDriver closed successfully");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during WebDriver cleanup: {ex.Message}");
            }
        }
    }
}