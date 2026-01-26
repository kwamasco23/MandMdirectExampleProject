using MandMdirectExampleProject.Pages.UserAccount;
using MandMdirectExampleProject.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace MandMdirectExampleProject.StepDefinitions
{
    [Binding]
    public sealed class EditUserDeliveryAddressOnUserAccountStepDefinition
    {





        private IWebDriver driver;
        // create object of the pages so you can call the correct method
        Homepage homepage;
        AccountLoginPage accountLoginPage;
        CustomerAccountPage customerAccountPage;
        



        public EditUserDeliveryAddressOnUserAccountStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
        }


        [Given(@"User log into my user account")]
        public void GivenUserLogIntoMyUserAccount()
        {
            Homepage homepage = new Homepage(driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(driver);

            homepage.ClickOnMyAccount();
            Thread.Sleep(2500);
            accountLoginPage.TypeInUserNameEmailAddress();
            Thread.Sleep(2500);
            accountLoginPage.TypeInUserPassword();
            Thread.Sleep(2500);
            accountLoginPage.ClickContinueToAccessCustomerAccount();
            Thread.Sleep(2500);

        }

        [Given(@"User select Delivery Addresses")]
        public void GivenUserSelectDeliveryAddresses()
        {
            CustomerAccountPage customerAccountPage = new CustomerAccountPage(driver);
            customerAccountPage.ClickOnDeliveryAddresses();
            Thread.Sleep(2500);
            customerAccountPage.ClickOnNewDeliveryAddress();
            Thread.Sleep(2500);
            driver.Manage().Window.FullScreen();
            Thread.Sleep(2500);
            customerAccountPage.EnterIntoDeliveryAddress1();
            Thread.Sleep(2500);
            customerAccountPage.EnterIntoDeliveryAddress2();
            Thread.Sleep(2500);
            customerAccountPage.EnterIntoDeliveryAddress3();
            Thread.Sleep(2500);
            customerAccountPage.EnterIntoTownField();
            Thread.Sleep(2500);
            customerAccountPage.EnterPostCode();
            Thread.Sleep(2500);
            customerAccountPage.ClickOnPostcodeLookup();
            Thread.Sleep(2500);
            customerAccountPage.TypeIntoPostCodeField2();
            Thread.Sleep(2500);
            customerAccountPage.ClickOnFindMyAddress();
            Thread.Sleep(2500);
            customerAccountPage.SelectFromSearchedAddressesAlbertFieldsWalk();
            Thread.Sleep(2500);
            customerAccountPage.ClickOnSave();
            Thread.Sleep(5000);


        }

        [When(@"User select Edit on an address entry")]
        public void WhenUserSelectEditOnAnAddressEntry()
        {
            CustomerAccountPage customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.CLickOnEditDeliveryAddressBtn2();
            Thread.Sleep(4000);
           
        }

        [When(@"User manually fill out the address form after removing any existing data")]
        public void WhenUserManuallyFillOutTheAddressFormAfterRemovingAnyExistingData()
        {
            CustomerAccountPage customerAccountPage = new CustomerAccountPage(driver);


            customerAccountPage.ClickAndClearAddressLine1Field();
            Thread.Sleep(750);
            customerAccountPage.ClickAndClearNewAddressLine2();
            Thread.Sleep(750);
            customerAccountPage.ClickAndClearNewAddressLine3();
            Thread.Sleep(750);
            customerAccountPage.ClickAndClearTownField();
            Thread.Sleep(750);
            customerAccountPage.ClickAndClearPostcode1Field();
            Thread.Sleep(750);

            driver.Manage().Window.Maximize();
            customerAccountPage.TypeInNewAddressLine1ForEditAddressTestCase();
            Thread.Sleep(1500);
            customerAccountPage.TypeInNewAddressLine2ForEditAddressTestCase();
            Thread.Sleep(1500);
            customerAccountPage.TypeInNewAddressLine3ForEditAddressTestCase();
            Thread.Sleep(1500);
            customerAccountPage.TypeInNewTownForEditAddressTestCase();
            Thread.Sleep(1500);
            customerAccountPage.TypeInNewPostcodeForEditAddressTestCase();
            Thread.Sleep(1500);

        }

        [When(@"User select Save")]
        public void WhenUserSelectSave()
        {
            CustomerAccountPage customerAccountPage = new CustomerAccountPage(driver);

            customerAccountPage.ClickOnSave();
            Thread.Sleep(6000);
        }






        [Then(@"User account should be updated with my new address entry")]
        public void ThenUserAccountShouldBeUpdatedWithMyNewAddressEntry()
        {
            CustomerAccountPage customerAccountPage = new CustomerAccountPage(driver);


            string actualvalue = driver.FindElement(By.XPath("//div[contains(text(),'90, Ardwick Green North, M12 6fx')]")).Text;
            Assert.That(actualvalue.Contains("90, Ardwick Green North, M12 6fx"), actualvalue + " doesn't contain '90, Ardwick Green North, M12 6fx'");



            Thread.Sleep(4000);

            customerAccountPage.ClikcOnDeleteDeliveryAddressesBtn2();
            Thread.Sleep(3000);
            customerAccountPage.ClickOnYesToConfirmDeleteRequest();
            Thread.Sleep(4000);

            //string actualvalue1 = driver.FindElement(By.XPath("//span[contains(text(),'90, Ardwick Green North, M12 6fx')]")).Text;
            //Assert.False(actualvalue1.Contains("The correct new address containing 'M12 6fx' post code"), actualvalue + "The correct new address containing 'M12 6fx' post code");


        }

    }
}
