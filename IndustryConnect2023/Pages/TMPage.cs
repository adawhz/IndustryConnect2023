﻿using OpenQA.Selenium;
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


        }

        public void EditTM(IWebDriver driver)
        {
            //Edit an existing Time and Material rocord //*[@id="tmsGrid"]/div[3]/table/tbody/tr[10]/td[5]/a[1]
            Wait.WaitToBeClickable(driver, "XPath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]", 10);

            //Click on edit button of the last Time and Material record
            IWebElement clickEditButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            clickEditButton.Click();

            //Change TypeCode of the last record dropdown list
            IWebElement typecodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
            typecodeDropdown.Click();
            Thread.Sleep(500);
            IWebElement editTimeOption = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[1]"));
            editTimeOption.Click();
            Thread.Sleep(500);


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
            IWebElement editPriceTextbox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
            editPriceTextbox.Clear();
            editPriceTextbox.SendKeys("18");
            Thread.Sleep(500);

            //Click on the save button
            IWebElement saveNewButton = driver.FindElement(By.Id("SaveButton"));
            saveNewButton.Click();
            Thread.Sleep(1500);

            //Check the last record has been edited successfully
            //Navigate to the last record
            IWebElement navigateLastPage = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            navigateLastPage.Click();
            Thread.Sleep(3000);

            //Check the last record has been edited successfully
            IWebElement checkEditRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            if (checkEditRecord.Text == "Industry2023")
            {
                Console.WriteLine("The last record has been edited successfully!");
            }
            else
            {
                Console.WriteLine("The last record has been failed to edit! Code: " + checkEditRecord.Text);
            }


        }
        public void DeleteTM(IWebDriver driver)
        {
            // Delete an existing Time and Material record
            //Navigarte to Time and Material page
            IWebElement adminDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminDropdown.Click();
            IWebElement timeandMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeandMaterial.Click();
            Thread.Sleep(1500);


            //Navigate to the last page
            IWebElement goToLastPage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]"));
            goToLastPage.Click();
            Thread.Sleep(1000);

            //Check rows of last page berfore delete
            ICollection<IWebElement> rowsBeforeDelete = driver.FindElements(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr"));
            int rowsCountBeforeDelete = rowsBeforeDelete.Count();
            Console.WriteLine("Number of rows before delete: " + rowsCountBeforeDelete);

            //Click on delete button of the first record
            IWebElement clickDeleteButton = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[1]/td[5]/a[2]"));
            clickDeleteButton.Click();

            //Confirm to delete and click on ok button
            Thread.Sleep(1500);
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
