using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandMdirectExampleProject.Pages
{
    public class Homepage
    {

        private IWebDriver driver;

        //Definiing constructor to that will get the driver from step definition class
        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
        }



        //defining webpage elements
        By MyAccountLink = By.Id("myaccount");
        By SearchFieldInput = By.ClassName("aa-Input");
        //By SearchFieldHomePage = By.ClassName("aa-Input");
        By CookiesBannerAccept = By.Id("onetrust-accept-btn-handler");
        By LatestOffersBannerCancel = By.ClassName("close");
        By MyWishlistButton = By.ClassName("remnant__wishlist");
        By SearchButton = By.ClassName("aa-SubmitButton");





        //Implementing Absraction method which will perform the action on the webpage
        // and return the results of the action. 


        public WishlistPage ClickOnMyWishlistLink()
        {
            driver.FindElement(MyWishlistButton).Click();
            return new WishlistPage(driver);
        }
        public Homepage ClickToConfirmLatestOffersBanner()
        {
            driver.FindElement(LatestOffersBannerCancel).Click();
            return new Homepage(driver);
        }
        public Homepage ClickOnCookiesAcceptButton()
        {
            driver.FindElement(CookiesBannerAccept).Click();
            return new Homepage(driver);
        }
        public AccountLoginPage ClickOnMyAccount()
        {
            driver.FindElement(MyAccountLink).Click();
            return new AccountLoginPage(driver);
        }


        public Homepage SearchFieldInputProductSearch()
        {
            driver.FindElement(SearchFieldInput).SendKeys("trainers");
            return new Homepage(driver);
        }


        public Homepage ClickOnSearchFieldSearchButton()
        {
            driver.FindElement(SearchButton).Click();
            return new Homepage(driver);
        }

        public Homepage SearchForWatch()
        {
            driver.FindElement(SearchFieldInput).SendKeys("Watch");
            return new Homepage(driver);
        }
        public SearchResultsPage ClickOnSearchButton()
        {
            driver.FindElement(SearchButton).Click();
            return new SearchResultsPage(driver);
        }




    }
}
