using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestFramework.Attributes;
using TestFramework.Core;

namespace TestProject.Views
{
    public class BaseView
    {
        [Element("Nav Bar Purchase")]
        public WebElementWrapper NavBarBobchoLink() => new(
    By.XPath("//ul[@class='nav navbar-nav']/..//preceding-sibling::div//child::a"));

        [Element("Nav Bar Purchase")]
        public WebElementWrapper NavBarPurchaseLink() => new(
    By.XPath("//ul[@class='nav navbar-nav']//child::a[@href='/Purchase']"));

        [Element("Nav Bar Orders")]
        public WebElementWrapper NavBarOrdersLink() => new(
            By.XPath("//ul[@class='nav navbar-nav']//child::a[@href='/Orders']"));

        [Element("Nav Bar API")]
        public WebElementWrapper NavBarAPILink() => new(
             By.XPath("//ul[@class='nav navbar-nav']//child::a[@href='/Help']"));
    }
}
