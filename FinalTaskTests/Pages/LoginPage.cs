using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FinalTaskTests.Pages
{
    public class LoginPage : BasePage
    {
        private const string PageUrl = "https://www.saucedemo.com/";

        private readonly By _usernameInput = By.Id("user-name");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _errorMessage = By.CssSelector("h3[data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string username, string password)
        {
            WaitUntilElementIsVisible(_usernameInput).SendKeys(username);
            WaitUntilElementIsVisible(_passwordInput).SendKeys(password);
            WaitUntilClickable(_loginButton).Click();
        }

        public void LoginWithUserName(string username, string password)
        {
            WaitUntilElementIsVisible(_usernameInput).SendKeys(username);

            var passwordField = WaitUntilElementIsVisible(_passwordInput);
            passwordField.SendKeys(password);

            new Actions(Driver)
                .Click(passwordField)          // фокус на поле
                .KeyDown(Keys.Control)         // затиснути Ctrl
                .SendKeys("a")               // виділити все
                .KeyUp(Keys.Control)           // відпустити Ctrl
                .SendKeys(Keys.Delete)         // видалити виділене
                .Perform();

            WaitUntilClickable(_loginButton).Click();
        }
        
        public string GetErrorMessage()
        {
            return WaitUntilElementIsVisible(_errorMessage).Text;
        }
    }
}