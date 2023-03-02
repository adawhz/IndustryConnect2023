using IndustryConnect2023.Utilies;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryConnect2023.Pages
{
    public class HomePage
    {
        public void GoToTMPage(IWebDriver driver)
        {
            
            //Navigate to Time and Material page
            IWebElement adminstrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a"));
            adminstrationDropdown.Click();
            Wait.WaitToBeClickable(driver, "XPath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 5);
            IWebElement timeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterial.Click();


        }
    }
}
