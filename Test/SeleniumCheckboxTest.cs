using AutomatinisTestavimas3ND.Page;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AutomatinisTestavimas3ND.Test
{
    public  class SeleniumCheckboxTest
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Url = "https://demo.seleniumeasy.com/basic-checkbox-demo.html";
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            _driver.Quit();
        }
        [Order(3)]
        [TestCase("Success - Check box is checked", TestName = "TestOneCheckbox")]
        public static void CheckOneCheckbox(string result)
        {
            SeleniumcCheckboxPage page = new SeleniumcCheckboxPage(_driver);
            page.ClickOneCheckbox();
            page.TestIfOneCheckBoxIsChecked(result);
        }
        [Order(1)]
        [TestCase("Uncheck All", TestName = "TestCheckMultipleCheckboxes")]
        public static void CheckMultipleCheckboxes(string expectedValue)
        {
            SeleniumcCheckboxPage page = new SeleniumcCheckboxPage(_driver);
            page.SelectAllCheckBoxes();
            page.CheckButtonText(expectedValue);
        }
        [Order(2)]
        [TestCase("Uncheck All", "0", TestName = "TestUncheckMultipleCheckboxes")]
        public static void UncheckMultipleCheckboxes(string value, string expectedValue)
        {
            SeleniumcCheckboxPage page = new SeleniumcCheckboxPage(_driver);
            page.ClickToUncheckValue(value);
            page.TestIfAllCheckboxesAreUnchecked(expectedValue);
        }
    }
}
