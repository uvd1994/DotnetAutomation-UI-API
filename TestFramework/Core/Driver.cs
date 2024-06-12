using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestFramework.Utilities;

namespace TestFramework.Core
{
    public class Driver
    {
        private static Driver _instance;

        private static IWebDriver _driver;

        private static DefaultWait<IWebDriver> _wait;

        public static Driver Instance()
        {
            if (_instance == null)
            {
                _instance = new Driver();
            }
            return _instance;
        }

        public IWebDriver Get()
        {
            return _driver;
        }
        public WebElement WaitForElement(By by, int timeout = 120)
        {
            _wait.Timeout = TimeSpan.FromSeconds(timeout);
            return _wait.Until(e=> (WebElement)e.FindElement(by));
        }
        public WebElement WaitForElements(By by, int timeout = 120)
        {
            _wait.Timeout = TimeSpan.FromSeconds(timeout);
            return _wait.Until(e => (WebElement)e.FindElement(by));
        }
        public void InitDriver()
        {
            //Driver init
            InitProcess();
        }
        private static void InitProcess()
        {
            var configData = Resources.GetConfigData();

            _driver = new ChromeDriver();
            _wait = new DefaultWait<IWebDriver>(_driver)
            {
                Timeout = TimeSpan.FromSeconds((double)configData["Timeout"]),
                PollingInterval = TimeSpan.FromMilliseconds((double)configData["PollingTimeout"]),
                Message = "Element not found in set timeout!"
            };
            _driver.Navigate().GoToUrl((string)configData["URL"]);
        }

        public WebElementWrapper FindElement(By by)
        {
            var ele = Driver.Instance().Get().FindElement(by);
            return new WebElementWrapper((WebElement)ele);
        }
        public static List<WebElementWrapper> FindElements(By by)
        {
            var ele = Driver.Instance().Get().FindElements(by);
            var lst = ele.Select(e => new WebElementWrapper((WebElement)e)).ToList();
            return lst;
        }

        public static TimeSpan Timeout => TimeSpan.FromSeconds((double)Resources.GetConfigData()["Timeout"]);
        public bool Exists(By by)
        {
            var startTime = DateTime.Now;

            var elems = new ReadOnlyCollection<IWebElement>(new List<IWebElement>());

            while(DateTime.Now.Subtract(startTime) < Timeout)
            {
                try
                {
                    elems = _driver.FindElements(by);
                }
                catch

                { return false; }
                
                if (elems.FirstOrDefault()!.Displayed)
                {
                    break;
                }

            }
            return (elems.Count>0);
        }


    }


}
