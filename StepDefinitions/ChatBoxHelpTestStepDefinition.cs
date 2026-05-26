using MandMdirectExampleProject.Pages;
using MandMdirectExampleProject.Pages.UserAccount;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandMdirectExampleProject.StepDefinitions
{
    [Binding]
    internal class ChatBoxHelpTestStepDefinition
    {


        private IWebDriver driver;


        // create object of the pages so you can call the correct method
        Homepage homepage;
       


        // logic to get or define constructor that will accept the web driver object from hooks class
        public ChatBoxHelpTestStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
        }




    }
}
