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
            WaitForElementToBeClickable(btnMenuIniciarSesion).Click();
        }

     
        private void EnviarTextoLetraPorLetra(IWebElement elemento, string texto)
        {
            elemento.Click();
            elemento.Clear();

            
            foreach (char letra in texto)
            {
                elemento.SendKeys(letra.ToString());
                System.Threading.Thread.Sleep(80); 
            }
        }

        public void EnterUsername(string username)
        {
            var campoEmail = WaitForElementToBeClickable(tbxUsername);
            EnviarTextoLetraPorLetra(campoEmail, username);
        }

        public void EnterPassword(string password)
        {
            var campoPassword = WaitForElementToBeClickable(tbxPassword);
            EnviarTextoLetraPorLetra(campoPassword, password);
            campoPassword.SendKeys(Keys.Tab); 
        }

        public void ClickLogin()
        {
            var botonSubmit = WaitForElementToBeClickable(btnSubmit);

            
            botonSubmit.Click();
        }

        public void Login(string username, string password)
        {
            IrAlFormularioLogin();

            System.Threading.Thread.Sleep(1500);

            EnterUsername(username);
            System.Threading.Thread.Sleep(300);

            EnterPassword(password);
            System.Threading.Thread.Sleep(1000);

            ClickLogin();

            
            System.Threading.Thread.Sleep(3000);
        }
    }
}