using AventStack.ExtentReports.Gherkin.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandMdirectExampleProject.Pages.UserAccount
{
    public class CustomerAccountPage
    {

        private IWebDriver driver;

        //Definiing constructor to initate web driver
        public CustomerAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }



        public string getTitle()
        {
            return driver.Title;
        }


        //elements
        By WelcomeLinkMyAccountPage = By.XPath("//a[contains(text(),'Welcome')]");

        // Elements for Delivery Addresses 
        By DeliveryAddresses = By.XPath("//a[contains(text(),'Delivery Addresses')]");
        By DeleteDeliveryAddressesBtn1 = By.XPath("(//a[contains(text(),'Delete')])[1]");
        By DeleteDeliveryAddressesBtn2 = By.XPath("(//a[contains(text(),'Delete')])[2]");
        By EditDeliveryAddressesBtn1 = By.Id("edit-name-link");
        By EditDeliveryAddressBtn2 = By.XPath("(//a[@id='edit-delivery-link'])[2]");
        By AddressLine1Field = By.XPath("//input[@placeholder='Address line 1']");
        By AddressLine2Field = By.XPath("//input[@placeholder='Address line 2']");
        By AddressLine3Field = By.XPath("//input[@placeholder='Address line 3']");
        By TownField = By.XPath("//input[@placeholder='town']");
        By CountyField = By.XPath("//input[@placeholder='County']");
        By PostCodeField1 = By.Id("Address_PostCode");
        By PostCodeField2 = By.Id("FindAddress_PostCode");
        By LookUpPostCodeLink = By.ClassName("returnToPostCode");
        By FindMyAddressBtn = By.Id("find_address_btn");
        By CanterburyStreetAddressFromPostCodeSearch = By.XPath("(//a[contains(text(),'2 Canterbury Street,Ashton-under-Lyne, OL6 6HY')])[3]");
        By SaveButton = By.Id("btnSave");
        By CancelButton = By.Id("CancelBtn");
        By NewDeliveryAddress = By.Id("new-delivery-link");
        By YesButtonDeleteConfirmation = By.Id("delete-confirmation-yes");


        // Customer Name elements
        By CustomerName = By.XPath("//a[contains(text(),'Customer Name')]");
        By EditDetails = By.Id("edit-name-link");
        By Title = By.XPath("//select[@id='Salutation']");
        By FirstName = By.XPath("//input[@id='FirstName']");
        By Surname = By.XPath("//input[@id='Surname']");
        By Cancel = By.XPath("//input[@id='cancel']");
        By SaveBtnCustomerName = By.XPath("//input[@id='btnSave']");


        //Phone Numbers elements
        By PhoneNumbers = By.XPath("//a[contains(text(),'Phone Numbers')]");
        By EditDetailsPhoneNumbersTab = By.Id("edit-phone-link");
        By LandlineField = By.Id("PhoneNumber");
        By MobileField = By.Id("Mobile");
        By CancelBtn = By.Id("cancel-phone-link");
        By SaveBttnPhoneNumbers = By.Id("btnSave");

        // HomePageLogoIcon
        By MandMHomePageLogoIcon = By.XPath("//img[@class='logo__svg MandMGBP']");



        //Actions
        public CustomerAccountPage CustomerAccountWelcomeLink()
        {
            driver.FindElement(WelcomeLinkMyAccountPage).Click();
            return new CustomerAccountPage(driver);
        }

        public CustomerAccountPage ClickOnMandMHomePageLogoIcon()
        {
            driver.FindElement(MandMHomePageLogoIcon).Click();
            return new CustomerAccountPage(driver);
        }

        public CustomerAccountPage ClickOnYesToConfirmDeleteRequest()
        {
            driver.FindElement(YesButtonDeleteConfirmation).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage CLickOnEditDeliveryAddressBtn2()
        {
            driver.FindElement(EditDeliveryAddressBtn2).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClikcOnDeleteDeliveryAddressesBtn2()
        {
            driver.FindElement(DeleteDeliveryAddressesBtn2).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage TypeIntoPostCodeField2()
        {
            driver.FindElement(PostCodeField2).SendKeys("OL6 6HY");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnNewDeliveryAddress()
        {
            driver.FindElement(NewDeliveryAddress).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnDeliveryAddresses()
        {
            driver.FindElement(DeliveryAddresses).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnDeleteDeliveryAddressButton()
        {
            driver.FindElement(DeleteDeliveryAddressesBtn1).Click();
            return new CustomerAccountPage(driver); 
        }
        public CustomerAccountPage ClickOnEditDeliveryAddressesBtn()
        {
            driver.FindElement(EditDeliveryAddressesBtn1).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage EnterIntoDeliveryAddress1()
        {
            driver.FindElement(AddressLine1Field).SendKeys("10");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage EnterIntoDeliveryAddress2()
        {
            driver.FindElement(AddressLine2Field).SendKeys("Cantebury Street");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage EnterIntoDeliveryAddress3()
        {
            driver.FindElement(AddressLine3Field).SendKeys("Ashton-U-Lyne");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage EnterIntoTownField()
        {
            driver.FindElement(TownField).SendKeys("Greater Manchester");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage EnterPostCode()
        {
            driver.FindElement(PostCodeField1).SendKeys("OL6 6HY");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnSave()
        {
            driver.FindElement(SaveButton).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnPostcodeLookup()
        {
            driver.FindElement(LookUpPostCodeLink).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnFindMyAddress()
        {
            driver.FindElement(FindMyAddressBtn).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage SelectFromSearchedAddressesAlbertFieldsWalk()
        {
            driver.FindElement(CanterburyStreetAddressFromPostCodeSearch).Click();
            return new CustomerAccountPage(driver);
        }

        public CustomerAccountPage TypeInNewAddressLine1ForEditAddressTestCase()
        {
            driver.FindElement(AddressLine1Field).SendKeys("90");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage TypeInNewAddressLine2ForEditAddressTestCase()
        {
            driver.FindElement(AddressLine2Field).SendKeys("Ardwick Green North");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage TypeInNewAddressLine3ForEditAddressTestCase()
        {
            driver.FindElement(AddressLine3Field).SendKeys("Ardwick");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage TypeInNewTownForEditAddressTestCase()
        {
            driver.FindElement(TownField).SendKeys("Manchester");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage TypeInNewPostcodeForEditAddressTestCase()
        {
            driver.FindElement(PostCodeField1).SendKeys("M12 6fx");
            return new CustomerAccountPage(driver);
        }


        
        public CustomerAccountPage ClickAndClearAddressLine1Field()
        {
           // driver.FindElement(AddressLine1Field).Click();
           // Thread.Sleep(1000);
            driver.FindElement(AddressLine1Field).Clear();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickAndClearNewAddressLine2()
        {
            driver.FindElement(AddressLine2Field).Click();
            Thread.Sleep(1000);
            driver.FindElement(AddressLine2Field).Clear();

            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickAndClearNewAddressLine3()
        {
            driver.FindElement(AddressLine3Field).Click();
            Thread.Sleep(1000);
            driver.FindElement(AddressLine3Field).Clear();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickAndClearTownField()
        {
            driver.FindElement(TownField).Click();
            Thread.Sleep(1000);
            driver.FindElement(TownField).Clear();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickAndClearPostcode1Field()
        {
            driver.FindElement(PostCodeField1).Click();
            Thread.Sleep(1000);
            driver.FindElement(PostCodeField1).Clear();

            return new CustomerAccountPage(driver);
        }





        // actions for PhoneNumbers tab

        //Phone Numbers elements
 
        public CustomerAccountPage ClearLandLineField()
        {
            driver.FindElement(LandlineField).Clear();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClearMobileField()
        {
            driver.FindElement(MobileField).Clear();
            return new CustomerAccountPage(driver);
        }

        public CustomerAccountPage ClickOnTelephoneNumbersLink()
        {
            driver.FindElement(PhoneNumbers).Click();
            return new CustomerAccountPage(driver);
        }

        public CustomerAccountPage ClickOnEditDetailsPhoneNumbers()
        {
            driver.FindElement(EditDetailsPhoneNumbersTab).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage PopulateLandLineFieldWithPhoneNumber()
        {
            driver.FindElement(LandlineField).Clear();
            Thread.Sleep(1000);
            driver.FindElement(LandlineField).SendKeys("0121000004");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage PopulateMobileNumberFieldWithPhoneNumber()
        {
            driver.FindElement(MobileField).Clear();
            Thread.Sleep(1000);
            driver.FindElement(MobileField).SendKeys("07800000000");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage cancelbuttonPhoneNumbers()
        {
            driver.FindElement(CancelBtn).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage SavebuttonPhoneNumbers()
        {
            driver.FindElement(SaveBttnPhoneNumbers).Click();
            return new CustomerAccountPage(driver);
        }


        // Actions for Customer Name
        public CustomerAccountPage ClickOnCustomerName()
        {
            driver.FindElement(CustomerName).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnEditDetails()
        {
            driver.FindElement(EditDetails).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage UpdateTitleToMiss()
        {
            driver.FindElement(Title).Click();
            Thread.Sleep(6000);
            driver.FindElement(By.XPath("//option[@value='Mrs']")).Click();
            Thread.Sleep(7000);
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage UpdateTitleToMrs()
        {
            driver.FindElement(Title).Click();
            driver.FindElement(By.XPath("//option[@value='Miss']")).Click();
            return new CustomerAccountPage(driver);
        }


        public CustomerAccountPage UpdateCustomerFirstName()
        {
            driver.FindElement(FirstName).Clear();
            driver.FindElement(FirstName).SendKeys("James");
            return new CustomerAccountPage(driver); 
        }
        public CustomerAccountPage UpdateCustomerLastName()
        {
            driver.FindElement(Surname).Clear();
            driver.FindElement(Surname).SendKeys("Brown Davids");
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnCancel()
        {
            driver.FindElement(CancelBtn).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage ClickOnSaveBttn()
        {
            driver.FindElement(SaveBttnPhoneNumbers).Click();
            return new CustomerAccountPage(driver);
        }
        public CustomerAccountPage UpdateTitleToOther()
        {
            driver.FindElement(Title).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.XPath("//option[@value='Other']")).Click();
            Thread.Sleep(10000);
            return new CustomerAccountPage(driver);
        }


    }
}
