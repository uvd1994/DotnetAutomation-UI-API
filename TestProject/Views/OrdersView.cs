using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Attributes;
using TestFramework.Core;
using TestFramework.Utilities;

namespace TestProject.Views
{
    public class OrdersView : BaseView
    {

        [Element("Order View Header Text")]
        public WebElementWrapper Header() => new(By.XPath("//*[@class='lead']/preceding-sibling::h1"));


        [Element("Order View SubHeader Text")]
        public WebElementWrapper SubHeader() => new(By.XPath("//*[@class='lead']"));

        [Element("Order Table Header")]
        public WebElementWrapper OrderTableHeader() => new(By.XPath("//*[@class='table']//thead"));

        [Element("Order Table Body")]
        public WebElementWrapper OrderTableBody() => new(By.XPath("//*[@class='table']//tbody"));

        public void VerifyLatestAddedRowData(JObject inputDataJsonPath)
        {
            var rowElementsQuery = "//*[@class='table']//tbody/tr";
            var rowele = Driver.Instance().Get().FindElements(By.XPath(rowElementsQuery));

            var rowDataQuery = String.Format(rowElementsQuery + "[" + rowele.Count + "]/td");
            var rowdata = Driver.Instance().Get().FindElements(By.XPath(rowDataQuery));

            Assert.AreEqual(rowdata.ElementAt(1).Text, (string)inputDataJsonPath["Name"]);
            Assert.AreEqual(rowdata.ElementAt(2).Text, (string)inputDataJsonPath["Email"]);

            Assert.AreEqual(rowdata.ElementAt(3).Text, Resources.GetSize((string)inputDataJsonPath["SizeIndex"]));
            Assert.AreEqual(rowdata.ElementAt(4).Text, (string)inputDataJsonPath["Quantity"]);
            Assert.AreEqual(rowdata.ElementAt(5).Text, Resources.GetPrice((string)inputDataJsonPath["SizeIndex"], (string)inputDataJsonPath["Quantity"]));
        
        }
    }
}
