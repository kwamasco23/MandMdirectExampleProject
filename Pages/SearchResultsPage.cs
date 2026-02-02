using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandMdirectExampleProject.Pages
{
    public class SearchResultsPage
    {
        private IWebDriver driver;

        //Definiing constructor to initate web driver
        public SearchResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        //Element locators

        // Standard & Smart watch search 
        By ReflexActiveSmartWatchOne = By.XPath("//h2[contains(text(),' Series 13 Smart Watch And True Wireless Sound Earbuds Gift Set Black')]");
        By ReflexActiveSmartWatchTwo = By.XPath("//h2[contains(text(),' Womens Series 13 Smart Watch And True Wireless Sound Earbuds Gift Set Pink/​White')]");
        By DFNDlondonWatch = By.XPath("(//h2[@class='product__title'])[1]");
        By LiverpoolKidsWatch = By.XPath("//h2[contains(text(),' Kids Football Club LED Watch Black')]");

        // Filter By Brand
        By FilterBrand = By.Id("filter_brand");
        By AdidasBrand = By.XPath("//span[contains(text(),'adidas')]");
        By PumaBrand = By.XPath("//label[@for='brand_puma']");
        By AdidasSamba = By.XPath("//h2[contains(text(),' Mens Samba OG Trainers Core Black/​Footwear White/​Gum 5')]");


        // Filter By order
        By SortByDropDown = By.Id("sortByTop");
        By SortByMostPopular = By.XPath("//option[contains(text(),'Most Popular')]");
        By SortByLowestPrice = By.XPath("//option[contains(text(),'Lowest Price')]");
        By SortByHighestPrice = By.XPath("//option[contains(text(),'Highest Price')]");
        By SortByWhatsNew = By.XPath("//option[contains(text(),'What's New')]");
        By SortByPercentageSaving = By.XPath("//option[contains(text(),'Percentage Saving')]");

        // Filter By Gender
        By GenderLink = By.XPath("//h2[contains(text(),'GENDER')]");
        By MensLink = By.XPath("//span[contains(text(),'Mens')]");
        By WomensLink = By.XPath("//span[contains(text(),'Womens')]");
        By BoysLink = By.XPath("//span[contains(text(),'Boys')]");
        By GirlsLink = By.XPath("//span[contains(text(),'Girls')]");

        //Filters
        By ProductType = By.Id("//details[@id='filter_producttype']");
        By RunningShoes = By.XPath("//label[contains(text(),'Running Shoes')]");

        //Product to be selected
        By PumaSoftrideProduct = By.XPath("(//h2[@class='product__title'])[15]");

        // Specific products tailored for test scenarios.
        By TedBakerPhyilipaTimelinesWatch = By.XPath("//h2[contains(text(),' Mens Phylipa Timeless Watch Silver Tone/​Black')]");








        //Actions


        
       

       public ProductPage ClickOnPumaSoftrideProduct()
        {
            {
                driver.FindElement(PumaSoftrideProduct);
                return new ProductPage(driver);
            }
        }
        public SearchResultsPage RunningShoesCheckBox()
        {
            {
                driver.FindElement(RunningShoes).Click();
                return new SearchResultsPage(driver);
            }
        }
        public SearchResultsPage ProductTypeFilter()
        {
            {
                driver.FindElement(ProductType).Click();
                return new SearchResultsPage(driver);
            }
        }
        public SearchResultsPage ClickOnPumaBrand()
        {
            driver.FindElement(PumaBrand).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickOnAdidasSamba()
        {
            driver.FindElement(AdidasSamba).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickOnAdidasBrand()
        {
            driver.FindElement(AdidasBrand).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickOnBrandFilter()
        {
            driver.FindElement(FilterBrand).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickOnTedBakerPhyilipaTimelessWatch()
        {
            driver.FindElement(TedBakerPhyilipaTimelinesWatch).Click();
            return new SearchResultsPage(driver);
        }

        // Filter actions By Gender
        public SearchResultsPage ClickOnGirlsLink()
        {
            driver.FindElement(GirlsLink).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickOnBoysLink()
        {
            driver.FindElement(BoysLink).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickOnWomensLink()
        {
            driver.FindElement(WomensLink).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickOnMensLink()
        {
            driver.FindElement(MensLink).Click();
            return new SearchResultsPage(driver);
        }

        public SearchResultsPage ClickOnGenderLink()
        {
            driver.FindElement(GenderLink).Click();
            return new SearchResultsPage(driver);
        }




        //Actions by order
        public SearchResultsPage SelectSortByDropDown()
        {
            driver.FindElement(SortByDropDown).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickOnSortByMostPopular()
        {
            driver.FindElement(SortByMostPopular).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickSortByLowestPrice()
        {
            driver.FindElement(SortByLowestPrice).Click();
            return new SearchResultsPage (driver);
        }
        public SearchResultsPage ClickOnSortByHighestPrice()
        {
            driver.FindElement(SortByHighestPrice).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage ClickSortWhatsNew()
        {
            driver.FindElement(SortByWhatsNew).Click();
            return new SearchResultsPage(driver);
        }
        public SearchResultsPage clickSortByPercentageSaving()
        {
            driver.FindElement(SortByPercentageSaving).Click();
            return new SearchResultsPage(driver);
        }

        // Watch logic
        public ProductPage ReflexSmartWatchOne()
        {
            driver.FindElement(ReflexActiveSmartWatchOne).Click();
            return new ProductPage(driver);
        }
        public ProductPage ReflexSmartWatchTwo()
        {
            driver.FindElement(ReflexActiveSmartWatchTwo).Click();
            return new ProductPage(driver);
        }
        public ProductPage ClickDFNDlondonWatch()
        {
            driver.FindElement(DFNDlondonWatch).Click();
            return new ProductPage(driver);
        }
        public ProductPage CLickOnLiverpoolKidsWatch()
        {
            driver.FindElement(LiverpoolKidsWatch).Click();
            return new ProductPage(driver);
        }



      













    }
}
