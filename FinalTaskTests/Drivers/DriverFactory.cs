using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace FinalTaskTests.Drivers
{
    public static class DriverFactory
    {
        public static IWebDriver CreateDriver(string browserName)
        {
            return browserName.ToLower() switch
            {
                "chrome" => CreateChromeDriver(),
                "firefox" => CreateFirefoxDriver(),
                _ => throw new ArgumentException($"Browser '{browserName}' is not supported.")
            };
        }

        private static IWebDriver CreateChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddArgument("--window-size=1920,1080");
            options.AddArgument("--start-maximized");
            // options.AddArgument("--headless"); // Enable for CI/CD
            return new ChromeDriver(options);
        }

        private static IWebDriver CreateFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");
            // options.AddArgument("--headless"); // Enable for CI/CD
            return new FirefoxDriver(options);
        }
    }
}
