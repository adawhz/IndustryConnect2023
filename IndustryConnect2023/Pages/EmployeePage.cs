using IndustryConnect2023.Utilies;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace IndustryConnect2023.Pages
{
    public class EmployeePage
    {
        public void CreateEmployee(IWebDriver driver)
        {
             Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"container\"]/p/a", 10);
            //Create a new employee record
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Input name into Name textbox
            IWebElement newEmployeeNameTextbox = driver.FindElement(By.Id("Name"));
            newEmployeeNameTextbox.SendKeys("Jeffery");

            //Input user into Username textbox
            IWebElement newEmployeeUserNameTextbox = driver.FindElement(By.Id("Username"));
            newEmployeeUserNameTextbox.SendKeys("JefferyP");

            //Input contact into Contact textbox
            Wait.WaitToBeClickable(driver, "Id", "EditContactButton", 5);
            IWebElement newEmployeeContactButton = driver.FindElement(By.Id("EditContactButton"));
            newEmployeeContactButton.Click();
            Thread.Sleep(1500);

            //Find contact frame
            IWebElement iframe = driver.FindElement(By.XPath("//*[@id=\"contactDetailWindow\"]/iframe"));

            //Switch to the frame
            driver.SwitchTo().Frame(iframe);

            IWebElement firstNameTextbox = driver.FindElement(By.Id("FirstName"));
            firstNameTextbox.SendKeys("Februay");
            Thread.Sleep(1500);

            IWebElement lastNameTextbox = driver.FindElement(By.Id("LastName"));
            lastNameTextbox.SendKeys("Wang");
            Thread.Sleep(1500);

            IWebElement phoneTextbox = driver.FindElement(By.Id("Phone"));
            phoneTextbox.SendKeys("987654");
            Thread.Sleep(1500);

            IWebElement mobileTextbox = driver.FindElement(By.Id("Mobile"));
            mobileTextbox.SendKeys("778899");
            Thread.Sleep(1500);

            IWebElement clickSaveContactButton = driver.FindElement(By.Id("submitButton"));
            clickSaveContactButton.Click();
            driver.SwitchTo().DefaultContent();


            //Input password into Password textbox
            IWebElement newEmployeePasswordTextbox = driver.FindElement(By.Id("Password"));
            newEmployeePasswordTextbox.SendKeys("123456Abc!");

            //Input retype password into RetypePassword textbox
            IWebElement newEmployeeRetypePasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            newEmployeeRetypePasswordTextbox.SendKeys("123456Abc!");

            //Tick checkbox of IsAdmin
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"UserEditForm\"]/div/div[6]/div", 5);
            IWebElement tickCheckboxIsAdmin = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[6]/div"));
            tickCheckboxIsAdmin.Click();

            //Input vehicle into Vehicle textbox
            IWebElement vehicleTextbox = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[7]/div/span[1]/span/input"));
            vehicleTextbox.SendKeys("bus");

            //select group in Groups textbox 
            IWebElement selectGroupTextbox = driver.FindElement(By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]"));
            selectGroupTextbox.Click();
            Thread.Sleep(1500); 
            IWebElement groupOption = driver.FindElement(By.XPath("//*[@id=\"groupList_listbox\"]/li[11]"));
            groupOption.Click();

            //Click on save button
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 5);
            IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));
            clickSaveButton.Click();

            //Click back to list button
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"container\"]/div/a", 5);
            IWebElement clickBackToListButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            clickBackToListButton.Click();

            //Check if new employee record has benn created
            //Go to last page of employee
            Thread.Sleep(5000);
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]"));
            goToLastPage.Click();
            Thread.Sleep(1500);

            IWebElement newEmployeerecordName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));       
            IWebElement newEmployeeRecordUserName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
           
            Assert.That(newEmployeerecordName.Text == "Jeffery", "Actual and expected name do not match");
            Assert.That(newEmployeeRecordUserName.Text == "JefferyP", "Actual and expected username fo not match");

        }

        public string GetName(IWebDriver driver)
        {
            IWebElement newEmployeeName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return newEmployeeName.Text;
        }

        public string GetUserName(IWebDriver driver)
        {
            IWebElement newEmployeeUserName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            return newEmployeeUserName.Text;
        }

        public void EditEmployee(IWebDriver driver,string Name,string Username)
        {
            //Go to last page of employee
            Thread.Sleep(5000);
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]"));
            goToLastPage.Click();

            //Edit the last record of employee
            Thread.Sleep(1500);
            IWebElement employeeToBeEdit = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
           // if (employeeToBeEdit.Text == "Jeffery")
           // {
                IWebElement employeeToBeEditButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
                employeeToBeEditButton.Click();
           // }
           // else
           // {
           //     Assert.Fail("Employee to be edited not found.");            
          //  }
            //Edit name of last employee
            IWebElement nameToBeEditTextbox = driver.FindElement(By.Id("Name"));
            nameToBeEditTextbox.Clear();
            nameToBeEditTextbox.SendKeys(Name);
            Thread.Sleep(1000);
            //Edit username of the last employee
            IWebElement userNameToBeEdittextbox = driver.FindElement(By.Id("Username"));
            userNameToBeEdittextbox.Clear();
            userNameToBeEdittextbox.SendKeys(Username);

            //Click on edit save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();

            //Click on back to list button
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"container\"]/div/a", 5);
            IWebElement backToListButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a"));
            backToListButton.Click();   

            //Check if the last record has been edited successfully
            //Go to last page of employee
            Thread.Sleep(5000);
            IWebElement goToTheLastPage = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]"));
            goToTheLastPage.Click();
            Thread.Sleep(1500);

            //Check if the last record of employee page has been edited successfully
            IWebElement checkNameEditTextbox = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement checkUserNameEditTextbox = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));

           //Assert.That(checkNameEditTextbox.Text == "Industry", "Actual and expected name do not match");
           //Assert.That(checkUserNameEditTextbox.Text == "Connect", "Actual and expected username fo not match");
           

        }

        public string GetEmployeeName(IWebDriver driver)
        {
            IWebElement editedEmployeeName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            return editedEmployeeName.Text;
        } 
        public string GetEmployeeUsername(IWebDriver driver)
        {
            IWebElement editedEmployeeUsername = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));
            return editedEmployeeUsername.Text;
        }


        public void DeleteEmployee(IWebDriver driver)
        {
            //Go to last page of employee
            Thread.Sleep(5000);
            IWebElement goToTheLastPage = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]"));
            goToTheLastPage.Click();

            //Delete the last record of employee
            Thread.Sleep(1500);
            IWebElement nameOfLastEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (nameOfLastEmployee.Text == "Industry")
            {
                //Click on delete button of last record
                Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]", 5);
                IWebElement clickDeleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
                clickDeleteButton.Click();
            }
            else
            {
                Assert.Fail("Record to be deleted not found");
            }

            //Confirm to Delete and click on Ok button
            Thread.Sleep(5000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(1500);

            //Check if the last record has been deleted succesfully
            //Navigate to the last page 
            Thread.Sleep(5000);
            IWebElement navigateToTheLastPage = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]"));
            navigateToTheLastPage.Click();

            //Check if the last record has been deleted
            Thread.Sleep(1500);
            IWebElement checkNameOfLastEmployee = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (checkNameOfLastEmployee.Text != "Industry")
            {
                Assert.Pass(checkNameOfLastEmployee.Text, "The last employee has been deleted successfully.");
            }
            else
            {
                Assert.Fail(checkNameOfLastEmployee.Text,"The last employee has been deleted failed.");
            }


        }
    }
}
