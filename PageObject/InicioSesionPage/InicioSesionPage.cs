using OpenQA.Selenium;
using Tool_Shop.PageObject;

namespace Tool_shop.PageObject.InicioSesionPage
{
    public class InicioSesionPage : BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/";

        private By btnMenuIniciarSesion = By.CssSelector("[data-test='nav-sign-in']");
        private By tbxUsername = By.Id("email");
        private By tbxPassword = By.Id("password");
        private By btnSubmit = By.CssSelector("input[data-test='login-submit']");

        public InicioSesionPage(IWebDriver driver) : base(driver) { }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(homeUrl);
        }

        public void IrAlFormularioLogin()
        {
            WaitForElement(btnMenuIniciarSesion).Click();
        }

        public void EnterUsername(string username)
        {
            var campoEmail = WaitForElement(tbxUsername);
            campoEmail.Clear();
            campoEmail.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            var campoPassword = WaitForElement(tbxPassword);
            campoPassword.Clear();
            campoPassword.SendKeys(password);
        }

        public void ClickLogin()
        {
            WaitForElement(btnSubmit).Click();
        }

        public void Login(string username, string password)
        {
            IrAlFormularioLogin();
            EnterUsername(username);
            EnterPassword(password);
            ClickLogin();
        }
    }
}