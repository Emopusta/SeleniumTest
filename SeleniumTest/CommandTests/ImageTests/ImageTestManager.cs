using OpenQA.Selenium;
using SeleniumTest.ResultTestEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.CommandTests.ImageTests
{
    public class ImageTestManager :ImageTestService
    {
        IWebDriver _webDriver;

        public ImageTestManager(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public ResultTest POSTImageTest(int id, string filePath)
        {
            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div/button")).Click();
            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[1]/div[2]/button")).Click();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).Clear();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).SendKeys(id.ToString());
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[3]/div[2]/div/table/tbody/tr/td[2]/div/input")).SendKeys(filePath);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[2]/button")).Click();
            var statusCode = _webDriver.FindElement(By.XPath("//*[@id=\"post_api_Images_responses\"]/tbody/tr/td[1]")).Text;
            var statusDescription = _webDriver.FindElement(By.XPath("//*[@id=\"post_api_Images_responses\"]/tbody/tr/td[2]/div/div/p")).Text;
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[1]/div[2]/button[1]")).Click();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div/button")).Click();

            ResultTest result = new()
            {
                FunctionName = "POSTImageTest",
                StatusCode = statusCode,
                StatusDescription = statusDescription
            };
            return result;
        }
    }
}
