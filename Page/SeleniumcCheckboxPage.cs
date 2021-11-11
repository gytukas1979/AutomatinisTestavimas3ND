using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatinisTestavimas3ND.Page
{
    public class SeleniumcCheckboxPage /*: BasePage*/
    {   
        private static IWebDriver _driver;
        
        private IWebElement _oneCheckbox => _driver.FindElement(By.Id("isAgeSelected"));
        private IWebElement _text => _driver.FindElement(By.Id("txtAge"));
        private IReadOnlyCollection<IWebElement> _multipleCheckboxList => _driver.FindElements(By.ClassName("cb1-element"));
        private IWebElement _button => _driver.FindElement(By.Id("check1"));


        //public SeleniumcCheckboxPage(IWebDriver webdriver) : base(webdriver)
        //{
        //}
        public SeleniumcCheckboxPage(IWebDriver webdriver)
        {
            _driver = webdriver;
        }
        public SeleniumcCheckboxPage ClickOneCheckbox()
        {
            if (!_oneCheckbox.Selected)
            {
                _oneCheckbox.Click();
            }
            return this;
        }
        public SeleniumcCheckboxPage TestIfOneCheckBoxIsChecked(string expectedResult)
        {
            Assert.IsTrue(_text.Text.Equals(expectedResult), "Checkbox wasn't checked");
            return this;
        }
        public SeleniumcCheckboxPage SelectAllCheckBoxes()
        {
            foreach (IWebElement element in _multipleCheckboxList)
            {
                element.Click();
            }
            return this;
        }
        public SeleniumcCheckboxPage CheckButtonText(string expectedValue)
        {
            Assert.IsTrue(_button.GetAttribute("value").Equals(expectedValue), "Not all checkboxes are checked");
            return this;
        }
        public SeleniumcCheckboxPage ClickToUncheckValue(string value)
        {
            if (_button.GetAttribute("value") == value)
            {
                _button.Click();
            }
            return this;
        }
        public SeleniumcCheckboxPage TestIfAllCheckboxesAreUnchecked(string expectedValue)
        {
            int counter = 0;
            foreach(IWebElement element in _multipleCheckboxList)
            {
                if (element.Selected)
                {
                    counter++;
                }
            }
            Assert.AreEqual(expectedValue, counter.ToString(), "Some of checkboxes are still checked");
            return this;
        }
            
    }
}
