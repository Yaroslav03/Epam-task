using OpenQA.Selenium;

namespace FinalTaskTests.Pages
{
    public class ProductPage : BasePage
    {
        private readonly By _addToCartBtn = By.CssSelector("button[data-test='add-to-cart']");
        private readonly By _cartBadge = By.CssSelector(".shopping_cart_badge");

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public void AddToCart()
        {
            var btn = WaitUntilClickable(_addToCartBtn);
            ((IJavaScriptExecutor)Driver).ExecuteScript("arguments[0].click();", btn);
        }

        public string GetCartBadgeCount()
        {
            return WaitUntilElementIsVisible(_cartBadge).Text;   
        }
    }
}