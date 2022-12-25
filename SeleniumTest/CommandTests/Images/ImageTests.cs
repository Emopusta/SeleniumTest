using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.CommandTests.Images
{
    public class ImageTests
    {
        IWebDriver _webDriver;

        public ImageTests(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public string POSTImageTest(int id, string filePath)
        {
            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div/button")).Click();
            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[1]/div[2]/button")).Click();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).Clear();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).SendKeys(id.ToString());
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[3]/div[2]/div/table/tbody/tr/td[2]/div/input")).SendKeys(filePath);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[2]/button")).Click();
            var result = _webDriver.FindElement(By.XPath("//*[@id=\"post_api_Images_responses\"]/tbody/tr/td[1]")).Text;
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[1]/div[2]/button[1]")).Click();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div/button")).Click();
            return result;
        }
    }
}
