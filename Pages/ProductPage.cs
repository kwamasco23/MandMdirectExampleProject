using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandMdirectExampleProject.Pages
{
    public class ProductPage
    {

        private IWebDriver driver;

        //Definiing constructor to that will get the driver from step definition class
        public ProductPage(IWebDriver driver)
        {
            this.driver = driver;
        }



        By SelectSizeDropDown = By.XPath("(//button[@class='attributes__toggle'])[1]");
        By AddToBasketBttn = By.XPath("(//button[contains(text(),'Add To Basket')])[1]");
        By AddToWishlist = By.ClassName("wishlist__btn");
        By ColourDropDown = By.XPath("(//DIV[@CLASS='attributes__menu'])[1]");
        By OneSizeSmartWatchSize = By.XPath("(//button[contains(text(),'One Size')])[1]");
        By AdidasSambaSize = By.XPath("(//button[@class='attributes__select'])[1]");
        By ReturnToSearchResults = By.Id("back");


        public ProductPage SelectAdidasSambaSize()
        {
            driver.FindElement(AdidasSambaSize).Click();
            return new ProductPage(driver);
        }
        public SearchResultsPage ClickOnReturnToSearchResultsBttn()
        {
            driver.FindElement(ReturnToSearchResults).Click();
            return new SearchResultsPage(driver);
        }
        public ProductPage ClickColourDropDown()
        {
            driver.FindElement(ColourDropDown).Click();
            return new ProductPage(driver);
        }
        public ProductPage ClickAddToWishlist()
        {
            driver.FindElement(AddToWishlist).Click();
            return new ProductPage(driver);
        }
        public ProductPage clickSizeDropDownMenu()
        {
            driver.FindElement(SelectSizeDropDown).Click();
            return new ProductPage(driver);
        }

        public ProductPage ClickAddToBasket()
        {
            driver.FindElement(AddToBasketBttn).Click();
            return new ProductPage(driver);
        }
        public ProductPage ClickOnOneSizeFromSizeDropDownMenu()
        {
            driver.FindElement(OneSizeSmartWatchSize).Click();
            return new ProductPage(driver); 
        }



    }
}
