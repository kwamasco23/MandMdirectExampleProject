using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

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
        var isCi = Environment.GetEnvironmentVariable("CI") == "true";

        if (isCi)
        {
            // Jenkins / CI safe defaults
            options.AddArgument("--headless=new");
            options.AddArgument("--no-sandbox");
            options.AddArgument("--disable-dev-shm-usage");
            options.AddArgument("--window-size=1920,1080");
        }
        else
        {
            // Local dev
            options.AddArgument("--start-maximized");
        }

        // Block browser notifications
        options.AddUserProfilePreference("profile.default_content_setting_values.notifications", 2);

        _driver = new ChromeDriver(options);
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

        _container.RegisterInstanceAs<IWebDriver>(_driver);
    }

    [AfterScenario]
    public void AfterScenario()
    {
        _driver?.Quit();
    }
}
