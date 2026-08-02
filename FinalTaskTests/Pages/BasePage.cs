using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace FinalTaskTests.Pages
{
    public abstract class BasePage
    {
        protected readonly IWebDriver Driver;
        protected readonly WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        protected IWebElement WaitUntilElementIsVisible(By locator)
        {
            Wait.Message = $"[TIMEOUT] Element with locator '{locator}' was not visible after waiting for 10 seconds.";
            TestContext.WriteLine($"[PAGE LOG] Waiting for visibility:'{locator}'");

            return Wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return element.Displayed ? element : null!;
                }
                catch (NoSuchElementException)
                {
                    return null!;
                }
                catch (StaleElementReferenceException)
                {
                    return null!;
                }
            });
        }

        protected IWebElement WaitUntilClickable(By locator)
        {
            Wait.Message = $"[TIMEOUT] Element with locator '{locator}' was not clickable after 10 seconds.";
            TestContext.WriteLine($"[PAGE LOG] Waiting for elements to be clickable:'{locator}'");

            return Wait.Until(d =>
            {
                try
                {
                    var element = d.FindElement(locator);
                    return (element.Displayed && element.Enabled) ? element : null!;
                }
                catch (NoSuchElementException)
                {
                    return null!;
                }
                catch (StaleElementReferenceException)
                {
                    return null!;
                }
            });
        }
    }
}