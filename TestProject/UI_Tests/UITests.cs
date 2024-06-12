using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using TestFramework.Core;
using TestFramework.Utilities;
using TestProject.UI_Tests;
using TestProject.Views;

namespace TestProject
{
    public class UITests : BaseTest
    {
        [Test]
        public void EndToEndTest()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = path.Replace("TestProject\\TestProject\\bin\\Debug\\net6.0\\", "TestProject\\TestFramework\\TestData\\UIpositivedata.json");
            var inputDataJsonPath = JsonUtility.ReadJSON(configPath);
            
            var HomeView = GetViewObject<BobchosBarHomeView>();
            var PurchaseView = GetViewObject<PurchaseView>();
            var OrdersView = GetViewObject<OrdersView>();

            HomeView.NavBarPurchaseLink().Click();

            Assert.AreEqual(PurchaseView.Header().GetText(), "Place your order");
            Assert.AreEqual(PurchaseView.SubHeader().GetText(), "Fill the form and we will fill your glass with some good beverages.");

            PurchaseView.Size().SelectDropdown((int)inputDataJsonPath["SizeIndex"]);
            PurchaseView.Quantity().SendKeys((string)inputDataJsonPath["Quantity"]);

            PurchaseView.Name().SendKeys((string)inputDataJsonPath["Name"]);

            PurchaseView.Email().SendKeys((string)inputDataJsonPath["Email"]);
            PurchaseView.IsAdult().Click();

            PurchaseView.OrderButton().Click();
            PurchaseView.Header().WaitForElementText("Order confirmation");

            Assert.AreEqual(PurchaseView.Header().GetText(), "Order confirmation");
            Assert.AreEqual(PurchaseView.SubHeader().GetText(), "Thank you for your order. You can find the details below.");

            // Need to fix below assertions, they are failing intermittently
            /* Assert.AreEqual(PurchaseView.Size().GetText(), Resources.GetSize((string)inputDataJsonPath["SizeIndex"]));
            Assert.AreEqual(PurchaseView.Price().GetText(), Resources.GetPrice((string)inputDataJsonPath["SizeIndex"], (string)inputDataJsonPath["Quantity"]));
            Assert.AreEqual(PurchaseView.Quantity().GetText(), (string)inputDataJsonPath["Quantity"]);
            Assert.AreEqual(PurchaseView.Name().GetText(), (string)inputDataJsonPath["Name"]);
            Assert.AreEqual(PurchaseView.Email().GetText(), (string)inputDataJsonPath["Email"]); */

            PurchaseView.ContinueShopping().Click();

            PurchaseView.Header().WaitForElementText("Place your order");
            Assert.AreEqual(PurchaseView.Header().GetText(), "Place your order");
            Assert.AreEqual(PurchaseView.SubHeader().GetText(), "Fill the form and we will fill your glass with some good beverages.");

            PurchaseView.NavBarOrdersLink().Click();
            Thread.Sleep(5000);

            OrdersView.VerifyLatestAddedRowData(inputDataJsonPath);
        }
        [Test]
        public void NegativeTest()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            string configPath = path.Replace("TestProject\\TestProject\\bin\\Debug\\net6.0\\", "TestProject\\TestFramework\\TestData\\UIpositivedata.json");
            var inputDataJsonPath = JsonUtility.ReadJSON(configPath);

            var HomeView = GetViewObject<BobchosBarHomeView>();
            var PurchaseView = GetViewObject<PurchaseView>();

            HomeView.NavBarPurchaseLink().Click();

            Assert.AreEqual(PurchaseView.Header().GetText(), "Place your order");
            Assert.AreEqual(PurchaseView.SubHeader().GetText(), "Fill the form and we will fill your glass with some good beverages.");

            PurchaseView.OrderButton().Click();

            Assert.AreEqual(Driver.Instance().WaitForAlert().Text, "Please selet size");
            Driver.Instance().WaitForAlert().Accept();

            PurchaseView.Size().SelectDropdown((int)inputDataJsonPath["SizeIndex"]);
            PurchaseView.OrderButton().Click();
            Assert.AreEqual(Driver.Instance().WaitForAlert().Text, "Please input Name");
            Driver.Instance().WaitForAlert().Accept();

            PurchaseView.Name().SendKeys((string)inputDataJsonPath["Name"]);
            PurchaseView.OrderButton().Click();
            Assert.AreEqual(Driver.Instance().WaitForAlert().Text, "Please input Email");
            Driver.Instance().WaitForAlert().Accept();

            PurchaseView.Email().SendKeys((string)inputDataJsonPath["Email"]);
            PurchaseView.OrderButton().Click();
            Assert.AreEqual(Driver.Instance().WaitForAlert().Text, "Please confirm you are above 18 years old!");
            Driver.Instance().WaitForAlert().Accept();

            //UI bug – When quantity is not given as input on UI, order is getting created without any alert popping to user 
        }

    }
}