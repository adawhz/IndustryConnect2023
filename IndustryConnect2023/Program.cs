// Open chrome broswer
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.Collections;


IWebDriver driver = new ChromeDriver();
// Launch turnup portal
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
driver.Manage().Window.Maximize();
//Identify username textbox and enter valid username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");
//Identify password textbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");
//identify login button and click on it
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginButton.Click();
// Check user logged in successfully
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));
if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("Logged in sucessfully!"); 
}
else
   {
    Console.WriteLine("Logged in unsucessfully!");
}

//Create a new Time record
Thread.Sleep(1500);
//Navigate to Time and Material page
IWebElement adminstrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
adminstrationDropdown.Click();
Thread.Sleep(1000);
IWebElement timeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
timeMaterial.Click();

//Click on create new button
IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNewButton.Click();

//Select Time option from Typecode dropdown list

IWebElement typeDropdown = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[2]/span"));
IWebElement timeOption = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[1]"));
timeOption.Click();
Thread.Sleep(2000);
//Input code into code textbox
IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
codeTextbox.SendKeys("IndustryConnect");
Thread.Sleep(2000);
//Input description into Description textbox
IWebElement descriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
descriptionTextbox.SendKeys("IndustryConnect");
Thread.Sleep(2000);
//Input price per unit textbox
IWebElement pricePerUnit = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[4]/div/span[1]/span/input[1]"));
pricePerUnit.SendKeys("20");
Thread.Sleep(2000);
//Click on save button
IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));
clickSaveButton.Click();
Thread.Sleep(5000);

//Check if new time record has been added successfully
// Navigate the last page
IWebElement gotoLastPage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]"));

gotoLastPage.Click();
Thread.Sleep(1000);
IWebElement newCode = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]/td[1]"));

if (newCode.Text == "IndustryConnect")
    {
    Console.WriteLine("New time record has been added successfully!");
}
else
{
    Console.WriteLine("New time record has not been added successfully!");
};

// Delete an existing Material record
//Navigarte to Time and material page
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

//Click on delete button of the last record
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

if(rowsCountBeforeDelete == rowsCountAfterDelete + 1)
{
    Console.WriteLine("The last record has been deleted successfully!");

}
else
{
    Console.WriteLine("The first record has not been deleted sucessfully!");
}