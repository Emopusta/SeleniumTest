using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTest.ResultTestEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTest.CommandTests.VehicleTests
{
    public class VehicleTestManager : VehicleTestService
    {
        IWebDriver _webDriver;

        public VehicleTestManager(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public ResultTest POSTVehicleTest(string name)
        {
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div/button")).Click();
            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div[2]/div/div[1]/div[1]/div[2]/button")).Click();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).Clear();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).SendKeys(name);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div[2]/div/div[2]/button")).Click();
            var statusCode = _webDriver.FindElement(By.XPath("//*[@id=\"post_api_Vehicles_responses\"]/tbody/tr/td[1]")).Text;
            var statusDescription = _webDriver.FindElement(By.XPath("//*[@id=\"post_api_Vehicles_responses\"]/tbody/tr/td[2]/div/div/p")).Text;

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[1]")));


            var serverStatusCode = _webDriver.FindElement(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[1]")).Text;
            
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div[2]/div/div[1]/div[1]/div[2]/button")).Click();
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Vehicles-post_api_Vehicles\"]/div/button")).Click();

            ResultTest result = new()
            {
                FunctionName = "POSTVehicleTest",
                StatusCode = statusCode,
                StatusDescription = statusDescription,
                ServerStatusCode = serverStatusCode
            };
            return result;
        }
    }
}
