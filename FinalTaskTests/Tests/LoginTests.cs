using NUnit.Framework;
using FinalTaskTests.Pages;
using FluentAssertions;

namespace FinalTaskTests.Tests
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class LoginTests : BaseTest
    {
        private const string url = "https://www.saucedemo.com/";

        public LoginTests(string browser) : base(browser)
        {
        }

        [Test]
        public void SuccessfulLoginTest()
        {
            TestContext.WriteLine($"[STEP] Executing UC-2 SuccessfulLoginTest on {Browser}");

            // 1. Навігація до веб-сайту
            Driver.Navigate().GoToUrl(url);

            // 2. Ініціалізація сторінки LoginPage
            var loginPage = new LoginPage(Driver);

            // 3. Виконання дії входу
            loginPage.Login("standard_user", "secret_sauce");

            // 4. Перевірка 5 елементів головної сторінки (UC-2)
            var inventoryPage = new InventoryPage(Driver);
            inventoryPage.IsBurgerMenuDisplayed().Should().BeTrue("Burger menu button should be displayed");
            inventoryPage.IsHeaderLogoDisplayed().Should().BeTrue("Header logo 'Swag Labs' should be displayed");
            inventoryPage.IsShoppingCartDisplayed().Should().BeTrue("Shopping cart icon should be displayed");
            inventoryPage.IsSortDropdownDisplayed().Should().BeTrue("Sorting dropdown should be displayed");
            inventoryPage.IsInventoryListDisplayed().Should().BeTrue("Inventory list should be displayed");
        }

        [TestCase("standard_user")]
        [TestCase("locked_out_user")]
        public void LoginWithoutInvalidPassword_ShouldShowErrorMessage(string username)
        {
            TestContext.WriteLine($"[STEP] Executing UC-1 LoginWithoutInvalidPassword for '{username}' on {Browser}");

            Driver.Navigate().GoToUrl(url);

            var loginPage = new LoginPage(Driver);

            loginPage.LoginWithUserName(username, "secret");

            loginPage.GetErrorMessage().Should().Contain("Password is required");
        }
    }
}
