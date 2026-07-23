using OpenQA.Selenium;
using NUnit.Framework;
using FinalTaskTests.Drivers;

namespace FinalTaskTests.Tests
{
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public abstract class BaseTest
    {
        protected IWebDriver Driver = null!;
        protected readonly string Browser;

        protected BaseTest(string browser = "chrome")
        {
            Browser = browser;
        }

        [SetUp]
        public void Setup()
        {
            TestContext.WriteLine($"[INFO] Starting test execution on browser: {Browser}");
            Driver = DriverFactory.CreateDriver(Browser);
        }

        [TearDown]
        public void Teardown()
        {
            if (Driver != null)
            {
                TestContext.WriteLine($"[INFO] Quitting driver for browser: {Browser}");
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}
