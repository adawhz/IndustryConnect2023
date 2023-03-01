using OpenQA.Selenium;
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
            Thread.Sleep(1000);
            IWebElement timeMaterial = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
            timeMaterial.Click();


        }
    }
}
