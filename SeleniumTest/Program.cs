// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.CommandTests.Images;

IWebDriver driver = new ChromeDriver();

// Navigate to the website
driver.Navigate().GoToUrl("https://localhost:7096/swagger/index.html");

// Find the search box element and enter a query
IList<string> results= new List<string>();

ImageTests imageTests = new ImageTests(driver);

results.Add(imageTests.POSTImageTest(1, "C:\\Users\\emred\\Pictures\\asd.PNG"));
results.Add(imageTests.POSTImageTest(1, "C:\\Users\\emred\\Pictures\\asd.PNG"));
results.Add(imageTests.POSTImageTest(1, "C:\\Users\\emred\\Pictures\\asd.PNG"));

foreach (var result in results)
{
    Console.WriteLine(result);
}



//System.Threading.Thread.Sleep(1000);
//driver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div/button")).Click();
//System.Threading.Thread.Sleep(1000);
//driver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[1]/div[2]/button")).Click();
//driver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[2]/div/table/tbody/tr/td[2]/input")).SendKeys("1");
//driver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[3]/div[2]/div/table/tbody/tr/td[2]/div/input")).SendKeys("C:\\Users\\emred\\Pictures\\asd.PNG");
//driver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[2]/button")).Click();
//var item = driver.FindElement(By.XPath("//*[@id=\"post_api_Images_responses\"]/tbody/tr/td[1]")).Text;



// Find the search button and click it
//IWebElement searchButton = driver.FindElement(By.XPath("//*[@id=\"operations-Images-post_api_Images\"]/div[2]/div/div[1]/div[1]/div[2]/button"));
//searchButton.Click();