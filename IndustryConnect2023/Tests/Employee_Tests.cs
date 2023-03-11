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
    public class Employee_Tests:CommonDriver
    {
        //Page object initialization
        HomePage HomePageObj = new HomePage();
        EmployeePage EmployeePageObj = new EmployeePage();



        [Test,Order(1),Description("Check if user is able to create a new employee record with valid data")]
        public void CreateEmployeeTest()
        {

            //Employee page object initialization and definition
            HomePageObj.GoToEmployeePage(driver);

            //Create Employee
            EmployeePageObj.CreateEmployee(driver);
        }

        [Test,Order(2),Description("Check if user is able to edit an existing employee record")]
        public void EditEmployeetest()
        {
            //Employee page object initialization and definition
            HomePageObj.GoToEmployeePage(driver);

            //Edit employee
           // EmployeePageObj.EditEmployee(driver);
        }

        [Test,Order(3),Description("Check if user is able to delete an existing employee record")]
        public void DeleteEmployeeTest()
        {
           
            //Employee page object initialization and definition
            HomePageObj.GoToEmployeePage(driver);

            //Delete employee
            EmployeePageObj.DeleteEmployee(driver);
        }
       
    }
}





   

