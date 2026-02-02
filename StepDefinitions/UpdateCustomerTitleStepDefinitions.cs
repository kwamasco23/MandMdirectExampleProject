using MandMdirectExampleProject.Pages.UserAccount;
using MandMdirectExampleProject.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MandMdirectExampleProject.StepDefinitions
{
    [Binding]
    public class UpdateCustomerTitleStepDefinitions
    {




        private IWebDriver driver;


        // create object of the pages so you can call the correct method
        Homepage homepage;
        AccountLoginPage accountLoginPage;
        CustomerAccountPage customerAccountPage;


        // logic to get or define constructor that will accept the web driver object from hooks class
        public UpdateCustomerTitleStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }




        [Given(@"User lands on the home page")]
        public void GivenUserLandsOnTheHomePage()
        {
            driver.Url = "https://www.mandmdirect.com/";
            driver.Manage().Window.FullScreen();
            Thread.Sleep(3000);
            driver.FindElement(By.Id("onetrust-accept-btn-handler")).Click();
            Thread.Sleep(6000);
        }

        [Given(@"User signs into their user account")]
        public void GivenUserSignsIntoTheirUserAccount()
        {
           homepage = new Homepage(driver);
            accountLoginPage = new AccountLoginPage(driver);

            homepage.ClickOnMyAccount();
            Thread.Sleep(6000);
            accountLoginPage.TypeInUserNameEmailAddress();
            Thread.Sleep(2000);
            accountLoginPage.TypeInUserPassword();
            Thread.Sleep(2000);
            accountLoginPage.ClickContinueToAccessCustomerAccount();
            Thread.Sleep(6000);


        }

        [Given(@"User clicks Customer Name")]
        public void GivenUserClicksCustomerName()
        {
            customerAccountPage = new CustomerAccountPage(driver);
            customerAccountPage.ClickOnCustomerName();
            Thread.Sleep(6000);
        }

        [When(@"User clicks Edit Details")]
        public void WhenUserClicksEditDetails()
        {
            customerAccountPage = new CustomerAccountPage(driver);
            customerAccountPage.ClickOnEditDetails();
            Thread.Sleep(6000);
        }

        [When(@"User selects Mrs from the title drop down list")]
        public void WhenUserSelectsMrsFromTheTitleDropDownList()
        {
            customerAccountPage = new CustomerAccountPage(driver);
            customerAccountPage.UpdateTitleToMiss();
            Thread.Sleep(6000);
        }

        [When(@"User selects save button")]
        public void WhenUserSelectsSaveButton()
        {
            customerAccountPage = new CustomerAccountPage(driver);
            customerAccountPage.ClickOnSaveBttn();
            Thread.Sleep(6000);
        }

        [Then(@"The User title should be changed to Mrs")]
        public void ThenTheUserTitleShouldBeChangedToMrs()
        {
            customerAccountPage = new CustomerAccountPage(driver);
            homepage = new Homepage(driver);
            customerAccountPage.ClickOnMandMHomePageLogoIcon();
            Thread.Sleep(6000);
            homepage.ClickOnMyAccount();
            Thread.Sleep(6000);
            customerAccountPage.ClickOnCustomerName();
            Thread.Sleep(6000);
            customerAccountPage.ClickOnEditDetails();
            Thread.Sleep(6000);
            customerAccountPage.UpdateTitleToMrs();
            Thread.Sleep(6000);
            customerAccountPage.ClickOnSaveBttn(); 
        }

        [When(@"User reverts changes")]
        public void WhenUserRevertsChanges()
        {
            customerAccountPage = new CustomerAccountPage(driver);
            homepage = new Homepage(driver);

            customerAccountPage.ClickOnMandMHomePageLogoIcon();
            Thread.Sleep(6000);
            homepage.ClickOnMyAccount();
            Thread.Sleep(6000);
            customerAccountPage.ClickOnCustomerName();
            Thread.Sleep(7000);
            customerAccountPage.ClickOnEditDetails();
            Thread.Sleep(7000);


        }

        [Then(@"The User title should revert back to Mr")]
        public void ThenTheUserTitleShouldRevertBackToMr()
        {
            customerAccountPage = new CustomerAccountPage(driver);
            homepage = new Homepage(driver);

            customerAccountPage.UpdateTitleToOther();
            Thread.Sleep(6000);
            customerAccountPage.ClickOnSaveBttn();
            customerAccountPage.ClickOnMandMHomePageLogoIcon();
            homepage.ClickOnSignOut();
            Thread.Sleep(10000);


        }
    }
}
