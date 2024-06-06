using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TestFramework.Core;
using TestProject.UI_Tests;
using TestProject.Views;

namespace TestProject
{
    public class Tests : BaseTest
    {
        [Test]
        public void Dutta()
        {
            var HomeView = GetViewObject<BobchosBarHomeView>();
            HomeView.NavBarPurchaseLink().Click(); ;



            Thread.Sleep(5000);

        }
    
    }
}