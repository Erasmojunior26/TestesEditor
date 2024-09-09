using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestEditor
{
    public class Begin
    {
        public IWebDriver driver;
        public bool Quit = false;

        [SetUp]
        public void StartTest()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://klist.app/#welcome");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(6);
        }

        [TearDown]
        public void StopTest()
        {
            if (Quit != false) driver.Close();
        }
    }
}