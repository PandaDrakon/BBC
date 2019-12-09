using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace BBC
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
           
            _driver.Navigate().GoToUrl("https://bbc.com");
            _driver.FindElement(By.LinkText("News")).Click();
           // _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            string str = "//*[@href='/news/science-environment-50614518']";    // XPath element head line bbc->news
            string strEqual = "Climate talks open as 'point of no return' looms";

            IWebElement element = _driver.FindElement(By.XPath(str));

            Assert.AreEqual(strEqual, element.Text);
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}