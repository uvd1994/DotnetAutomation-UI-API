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
    public class BobchosBarHomeView : BaseView
    {
        //By NavBarPurchaseLink = By.XPath("//ul[@class='nav navbar-nav']//child::a[@href='/Purchase']");

        [Element("Nav Bar Purchase")]
        public WebElementWrapper NavBarPurchaseLink()=> new(
            By.XPath("//ul[@class='nav navbar-nav']//child::a[@href='/Purchase']"));

        By NavBarOrdersLink = By.XPath("//ul[@class='nav navbar-nav']//child::a[@href='/Orders']");
        By NavBarAPILink = By.XPath("//ul[@class='nav navbar-nav']//child::a[@href='/Help']");
        By PurchaseButton = By.XPath("//*[@class='btn btn-primary btn-lg']");

        public void ClickPurchaseButton()
        {
            //NavBarPurchaseLink().Click();

        }
    }
}
