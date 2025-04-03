using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandMdirectExampleProject.Pages
{
    public class WishlistPage
    {


        private IWebDriver driver;

        //Definiing constructor to that will get the driver from step definition class
        public WishlistPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        By RemoveIcon = By.XPath("(//button[contains(text(),'Remove')])[1]");
        By AddToBasket = By.ClassName("buyButton");
        By ContinueButton1 = By.XPath("(//button[contains(text(),'Continue')])[1]");
        By ContinueButton2 = By.XPath("(//button[contains(text(),'Continue')])[2]");

        public WishlistPage ClickOnContinueButton2()
        {
            driver.FindElement(ContinueButton2).Click();
            return new WishlistPage(driver);
        }
        public WishlistPage ClickOnContinueButton()
        {
            driver.FindElement(ContinueButton1).Click();
            return new WishlistPage(driver);
        }
        public WishlistPage ClickOnRemoveIcon()
        {
            driver.FindElement(RemoveIcon).Click();
            return new WishlistPage(driver);
        }

        public WishlistPage ClickOnAddToBasket()
        {
            driver.FindElement(AddToBasket).Click();
            return new WishlistPage(driver);
        }




    }
}
