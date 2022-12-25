// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.CommandTests.Images;

IWebDriver driver = new ChromeDriver();


driver.Navigate().GoToUrl("https://localhost:7096/swagger/index.html");


IList<string> results= new List<string>();

ImageTests imageTests = new ImageTests(driver);

results.Add(imageTests.POSTImageTest(1, "C:\\Users\\emred\\Pictures\\asd.PNG"));
results.Add(imageTests.POSTImageTest(1, "C:\\Users\\emred\\Pictures\\asd.PNG"));
results.Add(imageTests.POSTImageTest(1, "C:\\Users\\emred\\Pictures\\asd.PNG"));

foreach (var result in results)
{
    Console.WriteLine(result);
}

driver.Quit();

