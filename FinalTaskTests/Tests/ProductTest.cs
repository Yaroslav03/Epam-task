using NUnit.Framework;
using FinalTaskTests.Pages;
using FluentAssertions;

namespace FinalTaskTests.Tests
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class ProductTest : BaseTest
    {
        private const string url = "https://www.saucedemo.com/";

        public ProductTest(string browser) : base(browser)
        {
        }

        [TestCase("Sauce Labs Backpack")]
        [TestCase("Sauce Labs Bike Light")]
        public void UC3_AddProductToCart_CartBadgeShouldDisplayOne(string productName)
        {
            TestContext.WriteLine($"[STEP] Executing UC-3 AddProductToCart for '{productName}' on {Browser}");

            Driver.Navigate().GoToUrl(url);

            var loginPage = new LoginPage(Driver);
            var inventoryPage = new InventoryPage(Driver);
            var productPage = new ProductPage(Driver);

            loginPage.Login("standard_user", "secret_sauce");
            inventoryPage.OpenByNameProduct(productName);
            productPage.AddToCart();

            productPage.GetCartBadgeCount().Should().Be("1", "Cart badge should display '1' after adding a product to the cart");
        }
    }
}