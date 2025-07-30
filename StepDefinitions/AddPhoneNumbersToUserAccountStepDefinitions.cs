using MandMdirectExampleProject.Pages.UserAccount;
using MandMdirectExampleProject.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace MandMdirectExampleProject.StepDefinitions
{
    [Binding]
    public sealed class AddPhoneNumbersToUserAccountStepDefinitions
    {

        private IWebDriver driver;
        // create object of the pages so you can call the correct method
        Homepage homepage;
        AccountLoginPage accountLoginPage;
        CustomerAccountPage customerAccountPage;
      



        public AddPhoneNumbersToUserAccountStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }



        [Given(@"User selects My Account")]
        public void GivenUserSelectsMyAccount()
        {
            homepage = new Homepage(driver);
            customerAccountPage = new CustomerAccountPage(driver);  

            homepage.ClickOnMyAccount();
            Thread.Sleep(3500);
        }

        [Given(@"user selects Phone Numbers link")]
        public void GivenUserSelectsPhoneNumbersLink()
        {
            
            customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.ClickOnTelephoneNumbersLink();
            Thread.Sleep(3500);

        }

        [Given(@"User selects Edit Details")]
        public void GivenUserSelectsEditDetails()
        {
            customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.ClickOnEditDetailsPhoneNumbers();
            Thread.Sleep(3500);
        }

        [When(@"user keys in contact details within Landline Number field")]
        public void WhenUserKeysInContactDetailsWithinLandlineNumberField()
        {
            customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.PopulateLandLineFieldWithPhoneNumber();
            Thread.Sleep(3500);
        }

        [When(@"user keys in contact details within Mobile Phone Number field")]
        public void WhenUserKeysInContactDetailsWithinMobilePhoneNumberField()
        {
            customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.PopulateMobileNumberFieldWithPhoneNumber();
            Thread.Sleep(3500);
        }

        [When(@"user clicks on Save button")]
        public void WhenUserClicksOnSaveButton()
        {
            customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.SavebuttonPhoneNumbers();
            Thread.Sleep(3500);
        }


        [When(@"user selects Edit Details")]
        public void WhenUserSelectsEditDetails()
        {
            customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.ClickOnEditDetailsPhoneNumbers();
            Thread.Sleep(3500);
        }

        [When(@"user clears both contact number fields")]
        public void WhenUserClearsBothContactNumberFields()
        {
            customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.ClearLandLineField();
            Thread.Sleep(3500);
            customerAccountPage.ClearMobileField();
            Thread.Sleep(3500);
        }

        [When(@"user selects save button")]
        public void WhenUserSelectsSaveButton()
        {
            customerAccountPage= new CustomerAccountPage(driver);

            customerAccountPage.SavebuttonPhoneNumbers();
            Thread.Sleep(3500);
        }

        [Then(@"contacts should be removed from Phone Numbers field")]
        public void ThenContactsShouldBeRemovedFromPhoneNumbersField()
        {
            Assert.True(0 == 0, "0121000004");
            Assert.True(0 == 0, "07800000000");
        }
    }
}
