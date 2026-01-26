using MandMdirectExampleProject.Pages.UserAccount;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandMdirectExampleProject.Pages
{
    public class AccountLoginPage
    {

        private IWebDriver driver;

        //Definiing constructor to initate web driver
        public AccountLoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }



        //defining webpage elements
        By EmailAddressField = By.Id("EmailAddress");
        By PasswordField = By.Id("Password");
        By ContinueButton = By.XPath("//button[contains(text(),'Continue')]");
        By ToggleViewPassword = By.ClassName("password-box__toggle");




        //Implementing Absraction method which will perform the action on the webpage
        // and return the results of the action. 

        public AccountLoginPage TypeInUserNameEmailAddress()
        {
            driver.FindElement(EmailAddressField).SendKeys("zzz04824@toaik.com");
            return new AccountLoginPage(driver);
            Thread.Sleep(5000);
        }
        public Homepage ClickOnToggleViewPassword()
        {
            driver.FindElement(ToggleViewPassword).Click();
            return new Homepage(driver);
        }

        public AccountLoginPage TypeInUserPassword()
        {
            driver.FindElement(PasswordField).SendKeys("Password@002");
            return new AccountLoginPage(driver);
        }

        public CustomerAccountPage ClickContinueToAccessCustomerAccount()
        {
            driver.FindElement(ContinueButton).Click();
            return new CustomerAccountPage(driver);
        }



    }
}
