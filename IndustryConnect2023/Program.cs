// Open chrome broswer
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;

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

IWebElement timeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
timeMaterial.Click();

//Click on create new button
IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
createNewButton.Click();

//Select Time option from Typecode dropdown list

IWebElement typeDropdown = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[2]/span"));
IWebElement timeOption = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[1]/div/span[1]/span/span[1]"));
timeOption.Click();


//Input code into code textbox

IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
codeTextbox.SendKeys("IndustryConnect");

//Input description into Description textbox
IWebElement descriptionTextbox = driver.FindElement(By.XPath("//*[@id=\"Description\"]"));
descriptionTextbox.SendKeys("IndustryConnect");

//Input price per unit textbox
IWebElement pricePerUnit = driver.FindElement(By.XPath("/html/body/div[4]/form/div/div[4]/div/span[1]/span/input[1]"));
pricePerUnit.SendKeys("20");

//Click on save button
IWebElement clickSaveButton = driver.FindElement(By.Id("SaveButton"));
clickSaveButton.Click();
Thread.Sleep(1500);

//Check if new time record has been added successfully
// Navigate the last page
IWebElement gotoLastPage = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[4]/a[4]"));

gotoLastPage.Click();

IWebElement newCode = driver.FindElement(By.XPath("/html/body/div[4]/div/div/div[3]/table/tbody/tr[last()]"));
if (newCode.Text == "IndestryConnect")
    {
    Console.WriteLine("New time record has been added successfully!");
}
else
{
    Console.WriteLine("New time record has not been added successfully!");
}


