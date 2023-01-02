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

        public ResultTest POSTAddVehicleTest(string name)
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
                FunctionName = "POSTAddVehicleTest",
                StatusCode = statusCode,
                StatusDescription = statusDescription,
                ServerStatusCode = serverStatusCode
            };
            return result;
        }


        public ResultTest PUTUpdateVehicleTest(string name, int velocity, int batteryPercentage, int statusId)
        {
            var vehiclePUTHeaderButtonXPath = "//*[@id=\"operations-Vehicles-put_api_Vehicles\"]/div/button";
            var vehicleTryItOutButtonXPath = "//*[@id=\"operations-Vehicles-put_api_Vehicles\"]/div[2]/div/div[1]/div[1]/div[2]/button";
            var vehicleNameInputXPath = "//*[@id=\"operations-Vehicles-put_api_Vehicles\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr[1]/td[2]/input";
            var vehicleVelocityInputXPath = "//*[@id=\"operations-Vehicles-put_api_Vehicles\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr[2]/td[2]/input";
            var vehicleBatteryPercentageInputXPath = "//*[@id=\"operations-Vehicles-put_api_Vehicles\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr[3]/td[2]/input";
            var vehicleStatusIdInputXPath = "//*[@id=\"operations-Vehicles-put_api_Vehicles\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr[4]/td[2]/input";
            var vehicleExecuteButtonXPath = "//*[@id=\"operations-Vehicles-put_api_Vehicles\"]/div[2]/div/div[2]/button";
            var serverStatusCodeXPath = "//*[@id=\"operations-Vehicles-put_api_Vehicles\"]/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[1]";
            var statusCodeXPath = "//*[@id=\"put_api_Vehicles_responses\"]/tbody/tr/td[1]";
            var statusDescriptionXPath = "//*[@id=\"put_api_Vehicles_responses\"]/tbody/tr/td[2]/div/div/p";

            
            _webDriver.FindElement(By.XPath(vehiclePUTHeaderButtonXPath)).Click();
            System.Threading.Thread.Sleep(500);
            _webDriver.FindElement(By.XPath(vehicleTryItOutButtonXPath)).Click();
            System.Threading.Thread.Sleep(500);

            _webDriver.FindElement(By.XPath(vehicleNameInputXPath)).Clear();
            _webDriver.FindElement(By.XPath(vehicleVelocityInputXPath)).Clear();
            _webDriver.FindElement(By.XPath(vehicleBatteryPercentageInputXPath)).Clear();
            _webDriver.FindElement(By.XPath(vehicleStatusIdInputXPath)).Clear();
            System.Threading.Thread.Sleep(500);

            _webDriver.FindElement(By.XPath(vehicleNameInputXPath)).SendKeys(name);
            _webDriver.FindElement(By.XPath(vehicleVelocityInputXPath)).SendKeys(velocity.ToString());
            _webDriver.FindElement(By.XPath(vehicleBatteryPercentageInputXPath)).SendKeys(batteryPercentage.ToString());
            _webDriver.FindElement(By.XPath(vehicleStatusIdInputXPath)).SendKeys(statusId.ToString());
            System.Threading.Thread.Sleep(500);

            _webDriver.FindElement(By.XPath(vehicleExecuteButtonXPath)).Click();
            System.Threading.Thread.Sleep(1000);

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));
            wait.Until(ExpectedConditions.ElementExists(By.XPath(serverStatusCodeXPath)));

            var serverStatusCode = _webDriver.FindElement(By.XPath(serverStatusCodeXPath)).Text;
            var statusCode = _webDriver.FindElement(By.XPath(statusCodeXPath)).Text;
            var statusDescription = _webDriver.FindElement(By.XPath(statusDescriptionXPath)).Text;

            _webDriver.FindElement(By.XPath(vehicleTryItOutButtonXPath)).Click();
            _webDriver.FindElement(By.XPath(vehiclePUTHeaderButtonXPath)).Click();

            ResultTest result = new()
            {
                FunctionName = "PUTUpdateVehicleTest",
                StatusCode = statusCode,
                StatusDescription = statusDescription,
                ServerStatusCode = serverStatusCode
            };
            return result;
        }
    }
}
