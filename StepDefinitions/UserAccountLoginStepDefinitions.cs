using MandMdirectExampleProject.Pages;
using MandMdirectExampleProject.Pages.UserAccount;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MandMdirectExampleProject.StepDefinitions
{
    [Binding]
    public sealed class UserAccountLoginStepDefinitions
    {

        private IWebDriver driver;
        // create object of the pages so you can call the correct method
        Homepage homepage;
        AccountLoginPage accountLoginPage;
        CustomerAccountPage customerAccountPage;



        public UserAccountLoginStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }



        [Given(@"User lands on the landing page")]
        public void GivenUserLandsOnTheLandingPage()
        {
            homepage = new Homepage(driver);

            driver.Url = "https://www.mandmdirect.com/";
            Thread.Sleep(4000);
            homepage.ClickOnCookiesAcceptButton();
            Thread.Sleep(2000);
          //  homepage.ClickToConfirmLatestOffersBanner();
          //  Thread.Sleep(4000);

        }

        [When(@"User selects My Account")]
        public void WhenUserSelectsMyAccount()
        {
            homepage = new Homepage(driver);

            homepage.ClickOnMyAccount();
            Thread.Sleep(3000);
        }

        [When(@"User types correct data into the username field")]
        public void WhenUserTypesCorrectDataIntoTheUsernameField()
        {
            accountLoginPage = new AccountLoginPage(driver);

            accountLoginPage.TypeInUserNameEmailAddress();
            Thread.Sleep(3000);
        }

        [When(@"User types correct data into the password field")]
        public void WhenUserTypesCorrectDataIntoThePasswordField()
        {
            accountLoginPage = new AccountLoginPage(driver);

            accountLoginPage.TypeInUserPassword();
            Thread.Sleep(3000);
            accountLoginPage.ClickOnToggleViewPassword();
        }

        [When(@"User selects Continue")]
        public void WhenUserSelectsContinue()
        {
            accountLoginPage= new AccountLoginPage(driver);

            accountLoginPage.ClickContinueToAccessCustomerAccount();
            Thread.Sleep(3000);
        }

        [Then(@"User should be directed to their account successfully")]
        public void ThenUserShouldBeDirectedToTheirAccountSuccessfully()
        {

                  // Retrieve the page title
        string actualTitle = driver.Title;

            // Define the expected title
            string expectedTitle = "MandM Direct Welcome";

            // Assert that the actual title is equal to the expected title
         //   Assert.That(expectedTitle, actualTitle, "The page title did not match the expected title.");
         //   Thread.Sleep(3000);

            //////////////////////////////////////////////////////////////////////////////////////////////////////////////

            // Asserting text on screen
            // Locate the element containing the text
            IWebElement element = driver.FindElement(By.XPath("//h1[contains(text(),'My Account')]"));

            // Retrieve the text of the element
            string actualText = element.Text;

            // Define the expected text
            string expectedText = "Welcome to My MandM";

            // Assert that the actual text is equal to the expected text
           // Assert.AreEqual(expectedText, actualText, "The text on the page did not match the expected value.");


        }


    }
    }

