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

        // NUEVO: Método para escribir simulando a un humano
        private void EnviarTextoLetraPorLetra(IWebElement elemento, string texto)
        {
            elemento.Click();
            elemento.Clear();

            // Recorremos el texto y enviamos cada letra con una micro-pausa
            foreach (char letra in texto)
            {
                elemento.SendKeys(letra.ToString());
                System.Threading.Thread.Sleep(80); // 80 milisegundos de retraso por letra
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
            campoPassword.SendKeys(Keys.Tab); // Quitamos el foco
        }

        public void ClickLogin()
        {
            var botonSubmit = WaitForElementToBeClickable(btnSubmit);

            // Probamos con un clic normal limpio, ya que los textos entraron bien
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

            // Le damos 3 segundos al navegador después del clic para que cargue la otra página 
            // antes de que el test intente evaluar la URL.
            System.Threading.Thread.Sleep(3000);
        }
    }
}