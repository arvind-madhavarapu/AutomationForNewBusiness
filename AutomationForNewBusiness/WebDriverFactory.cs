using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Diagnostics;

namespace AutomationForNewBusiness
{
     public class WebDriverFactory
    {

        public IWebDriver _driver;

        public IWebDriver InitializeDriver()
        {
            //_driver = new ChromeDriver(@"C:\Automation");
            _driver = new ChromeDriver(); 
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities = DesiredCapabilities.Chrome(); 
            capabilities.SetCapability(CapabilityType.BrowserName, "chrome");
            capabilities.SetCapability(CapabilityType.Platform, new Platform(PlatformType.XP));
            _driver = new RemoteWebDriver(new Uri("http://10.1.10.6:5557/wd/hub"), capabilities);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            return _driver;
            

        }

        public void TearDown()
        {
            _driver.Quit();

            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }

        }
        public void KillingChrome()
        {
            foreach (var process in Process.GetProcessesByName("chrome"))
            {
                process.Kill();
            }


        }


    }
}
