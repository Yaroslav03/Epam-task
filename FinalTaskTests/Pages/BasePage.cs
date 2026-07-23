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