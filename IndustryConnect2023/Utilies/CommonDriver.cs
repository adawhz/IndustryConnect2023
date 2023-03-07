using IndustryConnect2023.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryConnect2023.Utilies
{
    public class CommonDriver
    {
        public  IWebDriver driver;
        [SetUp]
        public void LoginSteps()
        {
            driver = new ChromeDriver(@"Document:/IndustryConnect2023");
            
            //Login page object initialization and definition
            LoginPage LoginPageObj = new LoginPage();
            LoginPageObj.LoginAction(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
 