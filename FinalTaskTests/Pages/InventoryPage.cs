using OpenQA.Selenium;

namespace FinalTaskTests.Pages
{
    public class InventoryPage : BasePage
    {
        private const string PageUrl = "https://www.saucedemo.com/";
        private readonly By productLink = By.CssSelector(".inventory_item_name");

        // 5 CSS Locators for UC-2
        private readonly By _burgerMenu = By.CssSelector("#react-burger-menu-btn");
        private readonly By _headerLogo = By.CssSelector(".app_logo");
        private readonly By _shoppingCart = By.CssSelector("#shopping_cart_container");
        private readonly By _sortDropdown = By.CssSelector("select[data-test='product-sort-container']");
        private readonly By _inventoryList = By.CssSelector(".inventory_list");

        public InventoryPage(IWebDriver driver) : base(driver)
        {
        }

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(PageUrl);
        }

        public void OpenByNameProduct(string productName)
        {
            WaitUntilElementIsVisible(productLink);
            var allProducts = Driver.FindElements(productLink);

            var product = allProducts.First(item => 
                (!string.IsNullOrEmpty(item.Text) && item.Text.Trim().Equals(productName, StringComparison.OrdinalIgnoreCase)) || 
                (!string.IsNullOrEmpty(item.GetAttribute("innerText")) && item.GetAttribute("innerText")!.Trim().Equals(productName, StringComparison.OrdinalIgnoreCase)));
            
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", product);
        }

        // Methods to verify the 5 elements required for UC-2
        public bool IsBurgerMenuDisplayed() => WaitUntilElementIsVisible(_burgerMenu).Displayed;
        public bool IsHeaderLogoDisplayed() => WaitUntilElementIsVisible(_headerLogo).Displayed;
        public bool IsShoppingCartDisplayed() => WaitUntilElementIsVisible(_shoppingCart).Displayed;
        public bool IsSortDropdownDisplayed() => WaitUntilElementIsVisible(_sortDropdown).Displayed;
        public bool IsInventoryListDisplayed() => WaitUntilElementIsVisible(_inventoryList).Displayed;
    }
}