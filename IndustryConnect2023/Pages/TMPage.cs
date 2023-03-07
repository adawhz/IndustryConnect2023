using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IndustryConnect2023.Utilies;
using NUnit.Framework;

namespace IndustryConnect2023.Pages
{
    public class TMPage
    {
       public void CreateTM(IWebDriver driver)
        {
            //Click on create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[2]/span", 5);

            //Select Time option from Typecode dropdown list

            IWebElement typeDropdown = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[2]/span"));
            typeDropdown.Click();

            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[1]", 5);
            IWebElement timeOption = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[1]"));
            timeOption.Click();
            Thread.Sleep(1000);

            //Input code into code textbox
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("IndustryConnect");
           Thread.Sleep(1000);

            //Input description into Description textbox
            IWebElement descriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            descriptionTextbox.SendKeys("Industry2023");
            Thread.Sleep(1000);


            //Input price per unit textbox
            IWebElement pricePerUnit = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[4]/div/span[1]/span/input[1]"));
            pricePerUnit.SendKeys("20");
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 5);

            //Click on save button
            IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));
            clickSaveButton.Click();
            Thread.Sleep(5000);

            //Check if new time record has been added successfully
            // Navigate the last page

            IWebElement gotoLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotoLastPage.Click();
            Thread.Sleep(5000);

            IWebElement newCode = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            Assert.That(newCode.Text == "IndustryConnect", "Actual and expected code don't match.");
            Assert.That(newDescription.Text == "Industry2023", "Avtual and expected description do not match.");
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[4]/div/div/div[4]/a[4]", 10);


        }
        


        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(5000);
            //Navigate to the TM last record of last page
            IWebElement goToLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            goToLastPage.Click();
            Thread.Sleep(5000);

            //Edit an existing Time and Material rocord
            //Click on edit button of the last Time and Material record
            IWebElement recordToBeEdit = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if(recordToBeEdit.Text== "IndustryConnect")
            {
                IWebElement clickEditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                clickEditButton.Click();
            }
            else
            {
                Assert.Fail("Record to be edited not found.");
            }
            
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span", 10);

            //Change TypeCode of the last record dropdown list
            IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typecodeDropdown.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]", 10);

            IWebElement editTimeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            editTimeOption.Click();
            Thread.Sleep(5000);


            //Edit code of the last record
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("Industry2023");
            Thread.Sleep(500);

            //Edit description of the last record
            IWebElement editDescriptionTextbox = driver.FindElement(By.Id("Description"));
            editDescriptionTextbox.Clear();
            editDescriptionTextbox.SendKeys("Industry2023");
            Thread.Sleep(500);

            //Edit price per unit of the last record
            IWebElement editPriceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            editPriceTextbox.Click();
            Thread.Sleep(500);
            IWebElement editPrice1Textbox = driver.FindElement(By.Id("Price"));

            editPrice1Textbox.Clear();
            editPriceTextbox.Click();

            editPrice1Textbox.SendKeys("18");
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 5);

            //Click on the save button
            IWebElement saveNewButton = driver.FindElement(By.Id("SaveButton"));
            saveNewButton.Click();
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]", 10);

            //Check the last record has been edited successfully
            //Navigate to the last record
            IWebElement navigateLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            navigateLastPage.Click();
            Thread.Sleep(3000);

            //Check the last record has been edited successfully
            //Navigate to the last page of TM
            
            IWebElement goToTheLastPage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]"));
            goToTheLastPage.Click();
            

            IWebElement checkEditRecordCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement checkEditRecordDescription = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[3]"));
           
            Assert.AreEqual("Industry2023", checkEditRecordCode.Text, "Actual and expected description do not match.");
            Assert.AreEqual("Industry2023", checkEditRecordDescription.Text,"Actual and expected description do not match.");


          


        }
        public void DeleteTM(IWebDriver driver)
        {
            //Navigate to the last page
            Thread.Sleep(5000);
            IWebElement goToLastPage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]"));
            goToLastPage.Click();
            Thread.Sleep(1000);
            
            //Check rows of last page berfore delete
            ICollection<IWebElement> rowsBeforeDelete = driver.FindElements(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr"));
            int rowsCountBeforeDelete = rowsBeforeDelete.Count();
            Console.WriteLine("Number of rows before delete: " + rowsCountBeforeDelete);
            Thread.Sleep(5000);

            //Click on delete button of the first record
            IWebElement recordToBeDeleted = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
           if (recordToBeDeleted.Text == "Industry2023")
            {
                IWebElement clickDeleteButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[1]/td[5]/a[2]"));
                clickDeleteButton.Click();
            }
           else
            {
                Assert.Fail("Record to be deleted not found.");
            }

            //Confirm to delete and click on ok button
            Thread.Sleep(5000);
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
            Thread.Sleep(1500);

            // Check rows of last page after delete
            ICollection<IWebElement> rowsAfterDelete = driver.FindElements(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr"));

            int rowsCountAfterDelete = rowsAfterDelete.Count();
            Console.WriteLine("Number of rows after delete: " + rowsCountAfterDelete);

            //Check if the first record has been deleted successfully

            if (rowsCountBeforeDelete == rowsCountAfterDelete + 1)
            {
                Console.WriteLine("The first record has been deleted successfully!");

            }
            else
            {
                Console.WriteLine("The first record has not been deleted sucessfully!");
            }
            Thread.Sleep(2000);
        }

    }

}
