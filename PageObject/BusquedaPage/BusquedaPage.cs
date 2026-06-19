using OpenQA.Selenium;
using Tool_Shop.PageObject;

namespace Tool_shop.PageObject.BusquedaPage
{
    public class BusquedaPage : BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/";

     
        private By btnInicioMenu = By.XPath("//a[contains(text(),'Inicio')]");
        private By tbxBuscarInput = By.CssSelector("input[data-test='search-query']");
        private By btnBuscarSubmit = By.CssSelector("button[data-test='search-submit']");
        private By lblPrimerProductoResultado = By.CssSelector("[data-test='product-name']");

        public BusquedaPage(IWebDriver driver) : base(driver) { }

        
        public void GoTo()
        {
            Driver.Navigate().GoToUrl(homeUrl);
        }

        public void ClicEnInicio()
        {
            WaitForElementToBeClickable(btnInicioMenu).Click();
        }

        
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

        public void EscribirProductoA_Buscar(string nombreProducto)
        {
            var inputBuscar = WaitForElementToBeClickable(tbxBuscarInput);
            EnviarTextoLetraPorLetra(inputBuscar, nombreProducto);
        }

        public void ClicBotonBuscar()
        {
            WaitForElementToBeClickable(btnBuscarSubmit).Click();
       
            System.Threading.Thread.Sleep(2000);
        }

      
        public string ObtenerNombreDelPrimerProducto()
        {
          
            return WaitForElement(lblPrimerProductoResultado).Text;
        }

        
        public void RealizarBusqueda(string producto)
        {
            ClicEnInicio();
            System.Threading.Thread.Sleep(1000);
            EscribirProductoA_Buscar(producto);
            System.Threading.Thread.Sleep(500);
            ClicBotonBuscar();
        }
    }
}