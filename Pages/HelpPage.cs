using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandMdirectExampleProject.Pages
{
    internal class HelpPage
    {

        private IWebDriver driver;

        //Definiing constructor to initate web driver
        public HelpPage(IWebDriver driver)
        {
            this.driver = driver;
        }



        //defining webpage elements
        By HelpPageSearchField = By.Id("query");
        By Returns = By.XPath("(//span[@class='blocks-item-title'])[1]");
        By Delivery = By.XPath("(//span[@class='blocks-item-title'])[2]");
        By Orders = By.XPath("(//span[@class='blocks-item-title'])[3]");
        By General = By.XPath("(//span[@class='blocks-item-title'])[4]");
        By ConctactUs = By.XPath("(//span[@class='blocks-item-title'])[5]");
        By Mens = By.XPath("(//span[@class='blocks-item-title'])[6]");
        By Womens = By.XPath("(//span[@class='blocks-item-title'])[7]");
        By Kids = By.XPath("(//span[@class='blocks-item-title'])[8]");

        
        /// //////////   chatbox and sub menus   //////////////////////
        By OpenChatBox = By.XPath("//div[@class='sc-1q9fwvy-0 DOJFV']");
        By MessageTextField = By.XPath("//textarea[@id='composer-input']");
        By SendMessageButton = By.XPath("//button[@title='Send message']");
        By ExitChatBox = By.XPath("//div[@class='sc-1q9fwvy-0 DOJFV']");




        //Implementing Absraction method which will perform the action on the webpage
        // and return the results of the action. 

        public HelpPage TypeIntoHelpPageSearchField()
        {
            driver.FindElement(HelpPageSearchField).SendKeys("help");
            return new HelpPage(driver);
        }

        public HelpPage ClickOnReturnsLink()
        {
            driver.FindElement(Returns).Click();
            return new HelpPage(driver);
        }
        public HelpPage ClickOnDeliveryLink()
        {
            driver.FindElement(Delivery).Click();
            return new HelpPage(driver);
        }
        public HelpPage ClickOnOrdersLink()
        {
            driver.FindElement(Orders).Click();
            return new HelpPage(driver);
        }
        public HelpPage ClickOnGeneralLink()
        {
            driver.FindElement(General).Click();
            return new HelpPage(driver);
        }
        public HelpPage ClickOnContactUsLink()
        {
            driver.FindElement(ConctactUs).Click();
            return new HelpPage(driver);
        }
        public HelpPage ClickOnMensLink()
        {
            driver.FindElement(Mens).Click();
            return new HelpPage(driver);
        }
        public HelpPage ClickOnWomensLink()
        {
            driver.FindElement(Womens).Click();
            return new HelpPage(driver);
        }
        public HelpPage ClickOnKidsLink()
        {
            driver.FindElement(Kids).Click();
            return new HelpPage(driver);
        }

        public HelpPage ClickOnOpenChatBoxLink()
        {
            driver.FindElement(OpenChatBox).Click();
            return new HelpPage(driver);
        }
        public HelpPage TypeIntoMessageTextField()
        {
            driver.FindElement(MessageTextField).SendKeys("Help me please!");
            return new HelpPage(driver);
        }
        public HelpPage ClickOnSendMessageButtonLink()
        {
            driver.FindElement(SendMessageButton).Click();
            return new HelpPage(driver);
        }
        public HelpPage ClickOnExitLink()
        {
            driver.FindElement(ExitChatBox).Click();
            return new HelpPage(driver);
        }




    }
}
