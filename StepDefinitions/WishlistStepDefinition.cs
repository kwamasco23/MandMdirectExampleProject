using MandMdirectExampleProject.Pages;
using MandMdirectExampleProject.Pages.UserAccount;
using MandMdirectExampleProject.StepDefinitions;
using OpenQA.Selenium;
using TechTalk.SpecFlow;


    [Binding]
    public sealed class WishlistStepDefinition
    {

        private IWebDriver driver;
        // create object of the pages so you can call the correct method
        Homepage homepage;
        AccountLoginPage accountLoginPage;
        CustomerAccountPage customerAccountPage;



        public WishlistStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
        }
        [Given(@"user lands on the landing page")]
        public void GivenUserLandsOnTheLandingPage()
        {
            // start implementing code here
        }

        [Given(@"user searches for an item on the website")]
        public void GivenUserSearchesForAnItem() { }

        [Given(@"user clicks on the item")]
        public void GivenUserClicksOnTheItem() { }

        [Given(@"user clicks on Add to Wishlist")]
        public void GivenUserClicksOnAddToWishlist() { }

        [When(@"user is presented with login screen")]
        public void WhenUserIsPresentedWithLoginScreen() { }

        [When(@"user enters the correct username")]
        public void WhenUserEntersTheCorrectUsername() { }

        [When(@"user enters the correct password")]
        public void WhenUserEntersTheCorrectPassword() { }

        [Then(@"the item should be added to user wishlist")]
        public void ThenTheItemShouldBeAddedToUserWishlist() { }

        [Then(@"item can also be removed from wishlist")]
        public void ThenItemCanAlsoBeRemovedFromWishlist() { }
    }
