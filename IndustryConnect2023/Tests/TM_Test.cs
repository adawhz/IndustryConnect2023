using IndustryConnect2023.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


//Open Chrome Browser
IWebDriver driver = new ChromeDriver(@"Document:/IndustryConnect2023");

//Login page object initialization and definition
LoginPage LoginPageObj = new LoginPage();
LoginPageObj.LoginAction(driver);

//Home page object initialization and definition
HomePage HomePageObj = new HomePage();
HomePageObj.GoToTMPage(driver);

//TM page object initialization and definition
TMPage TMPageObj = new TMPage();
TMPageObj.CreateTM(driver);

//Edit TM
TMPageObj.EditTM(driver);

//DElete TM
TMPageObj.DeleteTM(driver);


