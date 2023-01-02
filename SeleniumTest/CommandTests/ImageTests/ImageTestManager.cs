using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using SeleniumTest.ResultTestEntity;



namespace SeleniumTest.CommandTests.ImageTests
{
    public class ImageTestManager :ImageTestService
    {
        IWebDriver _webDriver;

        public ImageTestManager(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }


        public ResultTest POSTAddImageTest(int vehicleId, string filePath)
        {
            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div/button")).Click();
            System.Threading.Thread.Sleep(1000);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[1]/div[2]/button")).Click();
            System.Threading.Thread.Sleep(500);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).Clear();
            System.Threading.Thread.Sleep(500);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).SendKeys(vehicleId.ToString());
            System.Threading.Thread.Sleep(500);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[3]/div[2]/div/table/tbody/tr/td[2]/div/input")).SendKeys(filePath);
            System.Threading.Thread.Sleep(500);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[2]/button")).Click();
            var statusCode = _webDriver.FindElement(By.XPath("//*[@id=\"post_api_Images_responses\"]/tbody/tr/td[1]")).Text;
            var statusDescription = _webDriver.FindElement(By.XPath("//*[@id=\"post_api_Images_responses\"]/tbody/tr/td[2]/div/div/p")).Text;

            WebDriverWait wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(20));

            wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[1]")));
            System.Threading.Thread.Sleep(500);
            var serverStatusCode = _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[3]/div[2]/div/div/table/tbody/tr/td[1]")).Text;
            System.Threading.Thread.Sleep(500);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[1]/div[2]/button[1]")).Click();
            System.Threading.Thread.Sleep(500);
            _webDriver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div/button")).Click();
            
            ResultTest result = new()
            {
                FunctionName = "POSTAddImageTest",
                StatusCode = statusCode,
                StatusDescription = statusDescription,
                ServerStatusCode= serverStatusCode
            };
            return result;
        }
    }
}
