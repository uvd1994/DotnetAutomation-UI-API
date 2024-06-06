using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using TestProject.UI_Tests;
using TestFramework.Core;
using TestProject.Views;

namespace TestProject.UI_Tests
{
    public class BaseTest
    {

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {


        }
        [SetUp]
        public void Setup()
        {
          Driver.Instance().InitDriver();

        }
        [TearDown]
        public void TearDown()
        {
            Driver.Instance().Get().Quit();
        }

        public T GetViewObject<T>() where T : BaseView,new()
        {
            var page = Activator.CreateInstance(typeof(T));
            return (T)page;
        }

    }
}
