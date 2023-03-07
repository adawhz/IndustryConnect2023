using IndustryConnect2023.Pages;
using IndustryConnect2023.Utilies;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IndustryConnect2023.Tests
{
    [TestFixture]
    [Parallelizable]
    public class TM_Tests:CommonDriver
    {
        //Page object initialization
        HomePage HomePageObj = new HomePage();
        TMPage TMPageObj = new TMPage();

        [Test,Order(1),Description("Check if user is able to create Time record with valid data")]
        public void CreateTMTest()
        {
            //TM page object initialization and definition
            HomePageObj.GoToTMPage(driver);

            //Creat TM
            TMPageObj.CreateTM(driver);
        }

        [Test,Order(2),Description("Check if user is able to edit an existing record with valid data")]
        public void EditTMTest()
        {
            //Home page object initialization and definition
            HomePageObj.GoToTMPage(driver);

            //Edit TM
            TMPageObj.EditTM(driver);
        }

        [Test,Order(3),Description("Check if user is able to delete an existing record")]
        public void DeleteTMTest()
        {
            //Home page object initialization and definition  
            HomePageObj.GoToTMPage(driver);

            //DElete TM
            TMPageObj.DeleteTM(driver);
        }
       

    }
}
