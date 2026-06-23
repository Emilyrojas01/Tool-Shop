using OpenQA.Selenium;
using Tool_Shop.PageObject;

namespace Tool_shop.PageObject.CarritoPage
{
    public class CarritoPage : BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/";

  
        private By btnInicioMenu = By.CssSelector("a[data-test='nav-home']");
        private By tbxBuscarInput = By.CssSelector("input[data-test='search-query']");
        private By btnBuscarSubmit = By.CssSelector("button[data-test='search-submit']");
        private By cardPrimerProductoFiltrado = By.CssSelector("a.card, [data-test^='product-']");
        private By btnAñadirAlCarrito = By.CssSelector("button[data-test='add-to-cart']");
        private By lblCantidadCarritoBadge = By.CssSelector("span[data-test='cart-quantity']");

        public CarritoPage(IWebDriver driver) : base(driver) { }

        private void EnviarTextoLetraPorLetra(IWebElement elemento, string texto)
        {
            elemento.Click();
            elemento.Clear();
            foreach (char letra in texto)
            {
                elemento.SendKeys(letra.ToString());
                System.Threading.Thread.Sleep(60);
            }
        }


        public void IrAlInicio()
        {
            WaitForElementToBeClickable(btnInicioMenu).Click();
            System.Threading.Thread.Sleep(1500);
        }

        public void BuscarProductoPorSuNombre(string nombreProducto)
        {
           
            var inputBuscar = WaitForElementToBeClickable(tbxBuscarInput);
            EnviarTextoLetraPorLetra(inputBuscar, nombreProducto);

         
            WaitForElementToBeClickable(btnBuscarSubmit).Click();
            System.Threading.Thread.Sleep(2000);


            WaitForElementToBeClickable(cardPrimerProductoFiltrado).Click();
            System.Threading.Thread.Sleep(2500);
        }

        public void ClicAñadirAlCarrito()
        {

            var botonVerde = WaitForElementToBeClickable(btnAñadirAlCarrito);
            botonVerde.Click();
            System.Threading.Thread.Sleep(2500);
        }

      
        public string ObtenerCantidadDelCarrito()
        {
            return WaitForElement(lblCantidadCarritoBadge).Text;
        }
    }
}