using OpenQA.Selenium;
using NUnit.Framework;
using FinalTaskTests.Drivers;
using Microsoft.Extensions.Configuration;

namespace FinalTaskTests.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public abstract class BaseTest
    {
        private static readonly IConfiguration Config = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        protected IWebDriver Driver = null!;
        protected readonly string Browser;
        protected string Url => Config["Url"]!;
        protected string User => Config["StandardUser"]!;
        protected string Password => Config["StandardPassword"]!;
        

        protected BaseTest(string browser = "chrome")
        {
            Browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine($"[SETUP] Starting test execution on browser: {Browser}");
            Driver = DriverFactory.CreateDriver(Browser);

            TestContext.WriteLine($"[SETUP] Navigating to: {Url}");
            Driver.Navigate().GoToUrl(Url);
        }

        [TearDown]
        public void Teardown()
        {
            if (Driver != null)
            {
                var status = TestContext.CurrentContext.Result.Outcome.Status;

                TestContext.WriteLine($"[TEARDOWN] Test {TestContext.CurrentContext.Test.Name} finished with status: {status}.");
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}