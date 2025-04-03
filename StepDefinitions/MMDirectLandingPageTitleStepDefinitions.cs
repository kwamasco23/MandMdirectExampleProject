using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MandMdirectExampleProject.StepDefinitions
{
    [Binding]
    public class MMDirectLandingPageTitleStepDefinitions
    {

        private IWebDriver driver;
        

        // logic to get or define constructor that will accept the web driver object from hooks class
        public MMDirectLandingPageTitleStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }
        


        [Given(@"User navigates to M&M Direct landing page")]
        public void GivenUserNavigatesToMMDirectLandingPage()
        {
            driver.Url = "https://www.mandmdirect.com/";
            Thread.Sleep(3000);
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            Thread.Sleep(2500);
            
        }

        [When(@"User asserts the page title")]
        public void WhenUserAssertsThePageTitle()
        {
            throw new PendingStepException();
        }

        [Then(@"The correct page title should be displayed")]
        public void ThenTheCorrectPageTitleShouldBeDisplayed()
        {
            throw new PendingStepException();
        }
    }
}
