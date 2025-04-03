using MandMdirectExampleProject.Pages;
using MandMdirectExampleProject.Pages.UserAccount;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.BiDi.Modules.BrowsingContext;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using TechTalk.SpecFlow;

namespace MandMdirectExampleProject.StepDefinitions
{
    [Binding]
    public sealed class AddingItemsToWishlistStepDefinitions
    {



        private IWebDriver driver;
        // create object of the pages so you can call the correct method
        Homepage homepage;
        AccountLoginPage accountLoginPage;
        CustomerAccountPage customerAccountPage;
        WishlistPage wishlistPage;



        public AddingItemsToWishlistStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }







        [Given(@"User is on the landing page")]
        public void GivenUserIsOnTheLandingPage()
        {
            homepage = new Homepage(driver);

            driver.Url = "https://www.mandmdirect.com/";
            Thread.Sleep(3000);
            homepage.ClickOnCookiesAcceptButton();
            Thread.Sleep(3000);
            driver.Manage().Window.FullScreen();
            Thread.Sleep(4000);
          
    
    Thread.Sleep(3500);
        }

        [Given(@"User searches for watches")]
        public void GivenUserSearchesForWatches()
        {
            Homepage homepage = new Homepage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);

            homepage.SearchForWatch();
            Thread.Sleep(3500);
            homepage.ClickOnSearchButton();
            Thread.Sleep(3500);

        }

        [Given(@"User selects few watches from the search results")]
        public void GivenUserSelectsFewWatchesFromTheSearchResults()
        {
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);
            ProductPage productPage = new ProductPage(driver);
            AccountLoginPage accountLoginPage = new AccountLoginPage(driver);

            searchResultsPage.ClickDFNDlondonWatch();
            Thread.Sleep(2500);
            productPage.clickSizeDropDownMenu();
            Thread.Sleep(3500);
            productPage.ClickOnOneSizeFromSizeDropDownMenu();
            Thread.Sleep(3500);
            productPage.ClickAddToWishlist();
            Thread.Sleep(3500);
            accountLoginPage.TypeInUserNameEmailAddress();
            Thread.Sleep(3500);
            accountLoginPage.TypeInUserPassword();
            Thread.Sleep(3500);
            accountLoginPage.ClickContinueToAccessCustomerAccount();
            Thread.Sleep(3500);



            //
            productPage.clickSizeDropDownMenu();
            Thread.Sleep(3500);
            productPage.ClickOnOneSizeFromSizeDropDownMenu();
            Thread.Sleep(3500);
            productPage.ClickAddToWishlist();

            //

            productPage.ClickAddToBasket();
            Thread.Sleep(3500);
            homepage.SearchForWatch();
            Thread.Sleep(3500);
            homepage.ClickOnSearchButton();
            Thread.Sleep(3500);




           // productPage.ClickOnReturnToSearchResultsBttn();
            //Thread.Sleep(3500);

            searchResultsPage.CLickOnLiverpoolKidsWatch();
            Thread.Sleep(3500);
            productPage.clickSizeDropDownMenu();
            Thread.Sleep(3500);
            productPage.ClickOnOneSizeFromSizeDropDownMenu();
            Thread.Sleep(3500);
            productPage.ClickAddToWishlist();
            Thread.Sleep(3500);
//            accountLoginPage.TypeInUserNameEmailAddress();
  //          Thread.Sleep(3000);
    //        accountLoginPage.TypeInUserPassword();
      //      Thread.Sleep(3000);
        //    accountLoginPage.ClickContinueToAccessCustomerAccount();
          //  Thread.Sleep(3000);
            //productPage.ClickAddToBasket();
           // Thread.Sleep(3000);




        }

     //   [When(@"User adds selected watches to wishlist")]
       // public void WhenUserAddsSelectedWatchesToWishlist()
       // {
         //   ProductPage productPage = new ProductPage(driver);
          //  productPage.clickSizeDropDownMenu();
           // Thread.Sleep(3500);
          //  productPage.ClickOnOneSizeFromSizeDropDownMenu();
          //  Thread.Sleep(3500);
           // productPage.ClickAddToWishlist();
           // Thread.Sleep(3500);

      //  }

      [Then(@"Watches should be added to the wishlist\.")]
        public void ThenWatchesShouldBeAddedToTheWishlist_()
        {
            Homepage homepage = new Homepage(driver);
            WishlistPage wishlistPage = new WishlistPage(driver);
            homepage.ClickOnMyWishlistLink();
            Thread.Sleep(3500);


            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Locate the element
          By elementLocator = By.XPath("//h2[contains(text(),'DFND London Mens Faux Multi Dial Strap Watch Brown')]");

           // Wait until the element is visible
            wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));

          // Assert the element is visible
           IWebElement element = driver.FindElement(elementLocator);
           Assert.IsTrue(element.Displayed, "The element is not visible on the screen.");

            Thread.Sleep(3500);

        }
        [When(@"User removes items from the wishlist")]
        public void WhenUserRemovesItemsFromTheWishlist()
        {
            wishlistPage = new WishlistPage(driver);
            wishlistPage.ClickOnRemoveIcon();
            Thread.Sleep(3500);
            wishlistPage.ClickOnContinueButton();
            Thread.Sleep(3500);
            wishlistPage.ClickOnRemoveIcon();
            Thread.Sleep(3500);
            wishlistPage.ClickOnContinueButton2();
            Thread.Sleep(3500);
        }

        [Then(@"Wishlist should be removed")]
        public void ThenWishlistShouldBeRemoved()
        {
            // Locate the element for the 'Your wishlist is empty' button
            IWebElement element = driver.FindElement(By.XPath("//div[@class='wishlist__empty']"));

            // Assert that the element is not displayed on the page
            Assert.True(element.Displayed, "Revisit the code. The wishlist may contain some items");
        }



    }

    
}
