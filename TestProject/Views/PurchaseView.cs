﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Attributes;
using TestFramework.Core;

namespace TestProject.Views
{
    public class PurchaseView: BaseView
    {
        [Element("Purchase View Header Text")]
        public WebElementWrapper Header() => new(By.XPath("//*[@class='lead']/preceding-sibling::h1"));

        [Element("Purchase View SubHeader Text")]
        public WebElementWrapper SubHeader() => new(By.XPath("//*[@class='lead']"));

        [Element("Size")]
        public WebElementWrapper Size() => new(By.XPath("//*[@*='Size']"));

        [Element("Size")]
        public WebElementWrapper Price() => new(By.XPath("//*[@*='Price']"));

        [Element("Name")]
        public WebElementWrapper Name() => new(By.XPath("//*[@*='Name']"));

        [Element("Quantity")]
        public WebElementWrapper Quantity() => new(By.XPath("//*[@*='Qty']"));

        [Element("Email")]
        public WebElementWrapper Email() => new(By.XPath("//*[@*='Email']"));

        [Element("IsAdult")]
        public WebElementWrapper IsAdult() => new(By.XPath("//*[@*='IsAdult']"));

        [Element("Order Button")]
        public WebElementWrapper OrderButton() => new(By.XPath("//*[@*='btnOrder']"));

        [Element("Continue Shopping")]
        public WebElementWrapper ContinueShopping() => new(By.XPath("//*[contains(text(),'Continue shopping')]"));

 
    }
}
