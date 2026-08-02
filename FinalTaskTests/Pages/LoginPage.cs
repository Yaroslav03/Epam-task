using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace FinalTaskTests.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By _usernameInput = By.Id("user-name");
        private readonly By _passwordInput = By.Id("password");
        private readonly By _loginButton = By.Id("login-button");
        private readonly By _errorMessage = By.CssSelector("h3[data-test='error']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        public void Login(string username, string password)
        {
            TestContext.WriteLine($"[LOG] Entering username");
            WaitUntilElementIsVisible(_usernameInput).SendKeys(username);
            TestContext.WriteLine($"[LOG] Entering password");
            WaitUntilElementIsVisible(_passwordInput).SendKeys(password);
            TestContext.WriteLine($"[LOG] Clicking the login button");
            WaitUntilClickable(_loginButton).Click();
        }

        public void LoginWithClearedPassword(string username, string password)
        {
            WaitUntilElementIsVisible(_usernameInput).SendKeys(username);

            var passwordField = WaitUntilElementIsVisible(_passwordInput);
            passwordField.SendKeys(password);

            new Actions(Driver)
                .Click(passwordField)          
                .KeyDown(Keys.Control)         
                .SendKeys("a")                 
                .KeyUp(Keys.Control)           
                .SendKeys(Keys.Delete)        
                .Perform();

            WaitUntilClickable(_loginButton).Click();
        }
        
        public string GetErrorMessage()
        {
            return WaitUntilElementIsVisible(_errorMessage).Text;
        }
    }
}