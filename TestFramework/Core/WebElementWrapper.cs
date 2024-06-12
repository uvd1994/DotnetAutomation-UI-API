using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace TestFramework.Core
{
    public class WebElementWrapper
    {
        private By _query;
        private WebElement _element;

        public WebElementWrapper(By by)
        {
            _query = by;
        }
        public WebElementWrapper(WebElement elem)
        {
            _query = By.Id(elem.GetAttribute("Id"));
            _element = elem;
        }
        public void InitWebElement(int timeout = 120)
        {
           if ( _element is null )
            {
                _element = Driver.Instance().WaitForElement(_query, timeout);
            }
        }

        public WebElementWrapper Click()
        {
            InitWebElement();
            _element.Click();
            return this;
        }

        public void SendKeys(string text)
        {
            InitWebElement();
            _element.Click();
            _element.SendKeys(text);
        }
        public string GetText()
        {
            InitWebElement();
            return _element.Text;
        }

        public bool Exists()
        {
            InitWebElement();
            return Driver.Instance().Exists(_query);
        }

        public void SelectDropdown(int index)
        {
            SelectElement dropdown = new SelectElement(_element);
            dropdown.SelectByIndex(index);

        }



    }

  
}
