using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;


namespace IndustryConnect2023.Pages
{
    public class LoginPage
    {
        public void LoginAction(IWebDriver driver)
        {
            //Open Chrome browser
        
            driver.Manage().Window.Maximize();

            // Launch turnup portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
           
            //Identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            //Identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            //identify login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginButton.Click();

           

        }
    }
}
