using IndustryConnect2023.Pages;
using IndustryConnect2023.Utilies;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace IndustryConnect2023.StepDefinitions
{
    [Binding]
    public class EmployeeFeatureStepDefinitions:CommonDriver
    {
        //Page object initialization
        LoginPage LoginPageObj = new LoginPage();
        HomePage HomePageObj = new HomePage();
        EmployeePage EmployeePageObj = new EmployeePage();

        [Given(@"I logged in TurnUp portal successfully")]
        public void GivenILoggedInTurnUpPortalSuccessfully()
        {
            //Open Chrome driver
            driver = new ChromeDriver(@"Document:/IndustryConnect2023");

            //Login page object initialization and definition
            LoginPageObj.LoginAction(driver);
        }

        [When(@"I navigate to employee page")]
        public void WhenINavigateToTMPage()
        {

            //Employee page object initialization and definition
            HomePageObj.GoToEmployeePage(driver);

        }

        [When(@"I create a new employee record with valid details")]
        public void WhenICreateANewEmployeeRecordWithValidDetails()
        {
            //Create Employee
            EmployeePageObj.CreateEmployee(driver);
        }

        [Then(@"The new employee recoed should be created successfully")]
        public void ThenTheNewEmployeeRecoedShouldBeCreatedSuccessfully()
        {
            string createdName = EmployeePageObj.GetName(driver);
            string createdUserName = EmployeePageObj.GetUserName(driver);
            Assert.AreEqual("Jeffery",createdName, "Actual and expected name do not match.");
            Assert.AreEqual("JefferyP",createdUserName, "Actual and expected username do not match.");
        }

        [When(@"I update '([^']*)','([^']*)' on an existing employee record")]
        public void WhenIUpdateOnAnExistingEmployeeRecord(string Name, string Username)
        {
            //Edit employee
            EmployeePageObj.EditEmployee(driver,Name,Username);
        }

        [Then(@"The record should have updated '([^']*)','([^']*)'")]
        public void ThenTheRecordShouldHaveUpdated(string Name, string Username)
        {
            string editedName = EmployeePageObj.GetEmployeeName(driver);
            string editedUsername = EmployeePageObj.GetEmployeeUsername(driver);
            Assert.AreEqual(Name, editedName, "Actual and expected employee name do not match.");
            Assert.AreEqual(Username, editedUsername, "Actual and expected employee name do not match.");
        }


    }
}
