// See https://aka.ms/new-console-template for more information
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.CommandTests.ImageTests;
using SeleniumTest.CommandTests.VehicleTests;
using SeleniumTest.ResultTestEntity;

IWebDriver driver = new ChromeDriver();


driver.Navigate().GoToUrl("https://localhost:7096/swagger/index.html");


IList<ResultTest> results= new List<ResultTest>();

ImageTestService imageTests = new ImageTestManager(driver);
VehicleTestService vehicleTests = new VehicleTestManager(driver);


results.Add(vehicleTests.POSTVehicleTest("test"));
results.Add(imageTests.POSTImageTest(1, "C:\\Users\\emred\\Pictures\\asd.PNG"));
results.Add(imageTests.POSTImageTest(1, "C:\\Users\\emred\\Pictures\\asd.PNG"));
results.Add(imageTests.POSTImageTest(4, "C:\\Users\\emred\\Pictures\\asd.PNG"));



Console.WriteLine("-----------------------------");
foreach (var result in results)
{
    
    Console.WriteLine("Function Name: " + result.FunctionName);
    if (result.ServerStatusCode.Contains("500"))
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Server Status Code: " + result.ServerStatusCode);
        Console.ForegroundColor = ConsoleColor.White;
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("Server Status Code: " + result.ServerStatusCode);
        Console.ForegroundColor = ConsoleColor.White;
    }
    Console.WriteLine("Status Code: " + result.StatusCode);
    Console.WriteLine("Status Description: " + result.StatusDescription);
    Console.WriteLine("-----------------------------");


}

driver.Quit();

