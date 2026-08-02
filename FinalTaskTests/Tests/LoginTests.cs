 using NUnit.Framework;
using FinalTaskTests.Pages;
using FluentAssertions;

namespace FinalTaskTests.Tests
{
    [TestFixture("chrome")]
    [TestFixture("firefox")]
    public class LoginTests : BaseTest
    {
        

        public LoginTests(string browser) : base(browser)
        {
        }


        [Test]
        public void UC2_SuccessfulLoginTest()
        {
            var loginPage = new LoginPage(Driver);

            loginPage.Login(User, Password);

            var inventoryPage = new InventoryPage(Driver);
            inventoryPage.IsBurgerMenuDisplayed().Should().BeTrue("Burger menu button should be displayed");
            inventoryPage.IsHeaderLogoDisplayed().Should().BeTrue("Header logo 'Swag Labs' should be displayed");
            inventoryPage.IsShoppingCartDisplayed().Should().BeTrue("Shopping cart icon should be displayed");
            inventoryPage.IsSortDropdownDisplayed().Should().BeTrue("Sorting dropdown should be displayed");
            inventoryPage.IsInventoryListDisplayed().Should().BeTrue("Inventory list should be displayed");
        }

        [TestCase("standard_user")]
        public void UC1_LoginWithoutPassword_ShouldShowErrorMessage(string username)
        {
            var loginPage = new LoginPage(Driver);

            loginPage.LoginWithClearedPassword(username, Password);

            loginPage.GetErrorMessage().Should().Contain("Password is required");
        }
    }
}