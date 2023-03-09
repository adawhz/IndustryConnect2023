using IndustryConnect2023.Pages;
using IndustryConnect2023.Utilies;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace IndustryConnect2023.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions:CommonDriver
    {
        LoginPage LoginPageObj = new LoginPage();
        HomePage HomePageObj = new HomePage();
        TMPage TMPageObj = new TMPage();

        [Given(@"Logged in TurnUp portal successfully")]
        public void GivenLoggedInTurnUpPortalSuccessfully()
        {
            //Open chrome driver
            driver = new ChromeDriver(@"Document:/IndustryConnect2023");

            //Login page object initialization and definition
            LoginPageObj.LoginAction(driver);
        }

        [When(@"Navigate to TM page")]
        public void WhenNavigateToTMPage()
        {
            //TM page object initialization and definition
            HomePageObj.GoToTMPage(driver);
        }

        [When(@"Create a new TM record")]
        public void WhenCreateANewTMRecord()
        {
            //TM page object initialization and definition
            HomePageObj.GoToTMPage(driver);
            //Creat TM
            TMPageObj.CreateTM(driver);
        }
    
        [Then(@"The new TM record should be created successfully")]
        public void ThenTheNewTMRecordShouldBeCreatedSuccessfully()
        {
            string newCode = TMPageObj.GetCode(driver);
            string newDescription = TMPageObj.GetDescription(driver);   
            string newPrice = TMPageObj.GetPrice(driver);
            Assert.That(newCode == "IndustryConnect", "Actual and expected code don't match.");
            Assert.That(newDescription == "Industry2023", "Actual and expected description do not match.");
            Assert.AreEqual("$20.00", newPrice, "Actual and expected price do not match.");
        }

        [When(@"I update '([^']*)', '([^']*)', '([^']*)' on an existing TM record")]
        public void WhenIUpdateOnAnExistingTMRecord(string description, string code, string price)
        {
            TMPageObj.EditTM(driver, description, code, price);
            
           
        }

        [Then(@"The record should have the updated '([^']*)','([^']*)','([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdated(string description, string code, string price)
        {
            string editedDescription = TMPageObj.GetEditedDescription(driver);
            string editedCode = TMPageObj.GetEditedCode(driver);
            string editedPrice = TMPageObj.GetEditedPrice(driver);
            Assert.AreEqual(description, editedDescription, "Actual and expected description do not match.");
            Assert.AreEqual(code,editedCode, "Actual and expected code do not match.");
            Assert.AreEqual("$" + price + ".00", editedPrice, "Actual and expected price do not match");

        }


    }

}


