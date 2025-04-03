using MandMdirectExampleProject.Pages.UserAccount;
using MandMdirectExampleProject.Pages;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace MandMdirectExampleProject.StepDefinitions
{
    [Binding]
    public sealed class AddAdidasSambaTrainersToWishListStepDefinitions
    {




        private IWebDriver driver;
        // create object of the pages so you can call the correct method
        Homepage homepage;
        SearchResultsPage searchResultsPage;
        ProductPage productPage;
        AccountLoginPage accountLoginPage;
        CustomerAccountPage customerAccountPage;
        WishlistPage wishlistPage;




        [When(@"User searches for Adidas Samba trainers")]
        public void WhenUserSearchesForAdidasSambaTrainers()
        {
            Homepage homepage = new Homepage(driver);
            SearchResultsPage searchResultsPage = new SearchResultsPage(driver);

           
            homepage.SearchFieldInputProductSearch();
            Thread.Sleep(2500);
            homepage.ClickOnSearchFieldSearchButton();
            Thread.Sleep(2500);
            searchResultsPage.ClickOnAdidasBrand();
            Thread.Sleep(2500);
            searchResultsPage.ClickOnAdidasSamba();
            Thread.Sleep(2500);
        }

        [When(@"User adds the trainers to the wishlist")]
        public void WhenUserAddsTheTrainersToTheWishlist()
        {
            ProductPage productPage = new ProductPage(driver);
            productPage.clickSizeDropDownMenu();
            Thread.Sleep(2500);
            productPage.SelectAdidasSambaSize();
            Thread.Sleep(2500);
            productPage.ClickAddToWishlist();
            Thread.Sleep(3500);
        }

        [Then(@"The product should be added to the wishlist")]
        public void ThenTheProductShouldBeAddedToTheWishlist()
        {
            WishlistPage wishlistPage = new WishlistPage(driver);
            Homepage homepage1 = new Homepage(driver);

            Homepage homepage = new Homepage(driver);
            homepage.ClickOnMyWishlistLink();
            Thread.Sleep(2500);

            try
            {
                // Locate the element containing the text (adjust the locator as needed)
                IWebElement element = driver.FindElement(By.XPath("//h2[contains(text(),'adidas Originals Mens Samba OG Trainers Core Black/Footwear White/Gum 5')]"));

                // Verify that the text is displayed
                Assert.IsTrue(element.Displayed);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"The text was not found on the screen.");
            }

        }

        [When(@"Users removes the item from their wishlist")]
        public void WhenUsersRemovesTheItemFromTheirWishlist()
        {
            WishlistPage wishlistPage1 = new WishlistPage(driver);
            wishlistPage.ClickOnRemoveIcon();
            Thread.Sleep(2500);
            wishlistPage.ClickOnContinueButton();
        }

        [Then(@"The item should be removed from their wishlist")]
        public void ThenTheItemShouldBeRemovedFromTheirWishlist()
        {
            WishlistPage wishlistPage = new WishlistPage(driver);



            try
            {
                // Locate the element containing the text (adjust the locator as needed)
                IWebElement element1 = driver.FindElement(By.XPath("//h2[contains(text(),'adidas Originals Mens Samba OG Trainers Core Black/Footwear White/Gum 5')]"));

                // Verify that the text is displayed
                Assert.IsFalse(element1.Displayed);
            }
            catch (NoSuchElementException)
            {
                Assert.Fail($"The text was found on the screen.");
            }
        }
    }
}
