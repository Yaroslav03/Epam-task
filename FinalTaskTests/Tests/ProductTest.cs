using NUnit.Framework;
using FinalTaskTests.Pages;
using FluentAssertions;

namespace FinalTaskTests.Tests
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class ProductTest : BaseTest
    {
        public ProductTest(string browser) : base(browser)
        {
        }

        [TestCase("Sauce Labs Backpack")]
        [TestCase("Sauce Labs Bike Light")]
        public void UC3_AddProductToCart_CartBadgeShouldDisplayOne(string productName)
        {
            var loginPage = new LoginPage(Driver);
            var inventoryPage = new InventoryPage(Driver);
            var productPage = new ProductPage(Driver);

            loginPage.Login(User, Password);
            inventoryPage.OpenByNameProduct(productName);
            productPage.AddToCart();

            productPage.GetCartBadgeCount().Should().Be("1", "Cart badge should display '1' after adding a product to the cart");
        }
    }
}