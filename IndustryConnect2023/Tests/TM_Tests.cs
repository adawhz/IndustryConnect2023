using IndustryConnect2023.Pages;
using IndustryConnect2023.Utilies;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryConnect2023.Tests
{
    [TestFixture]
    public class TM_Tests:CommonDriver
    {
        [SetUp]
        public void LoginSteps() 
        {
            driver = new ChromeDriver(@"Document:/IndustryConnect2023");

            //Login page object initialization and definition
            LoginPage LoginPageObj = new LoginPage();

            LoginPageObj.LoginAction(driver);

            //Home page object initialization and definition
            HomePage HomePageObj = new HomePage();
            HomePageObj.GoToTMPage(driver);
        }


        [Test]
        public void CreateTMTest()
        {
            //TM page object initialization and definition
            TMPage TMPageObj = new TMPage();

            //Creat TM
            TMPageObj.CreateTM(driver);

        }

        [Test]
        public void EditTMTest()
        {
            //TM page object initialization and definition
            TMPage TMPageObj = new TMPage();

            //Edit TM
            TMPageObj.EditTM(driver);

        }

        [Test]
        public void DeleteTMTest()
        {
            //TM page object initialization and definition
            TMPage TMPageObj = new TMPage();

            //DElete TM
            TMPageObj.DeleteTM(driver);

        }

        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
