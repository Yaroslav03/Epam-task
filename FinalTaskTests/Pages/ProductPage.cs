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
            TestContext.WriteLine($"[ACTION] Clicking the 'Add to Cart' button");
            WaitUntilClickable(_addToCartBtn).Click();
        }

        public string GetCartBadgeCount()
        {
            var text =  WaitUntilElementIsVisible(_cartBadge).Text;   
            return int.TryParse(text, out var count) ? count.ToString() : "0";
        }
    }
}