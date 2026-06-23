using OpenQA.Selenium;
using Tool_Shop.PageObject;

namespace Tool_shop.PageObject.DetalleProductoPage
{
    public class DetalleProductoPage : BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/";

        private By cardProductoPliers = By.XPath("//h5[contains(text(),'Pliers')] | //a[contains(@class,'card') or contains(@data-test,'product-')]//h5[contains(text(),'Pliers')]");

        private By lblTituloDetalleProducto = By.CssSelector("h1[data-test='product-name']");

        public DetalleProductoPage(IWebDriver driver) : base(driver) { }

        public void GoTo()
        {
            Driver.Navigate().GoToUrl(homeUrl);
        }

        public void SeleccionarProductoPliers()
        {
            var producto = WaitForElementToBeClickable(cardProductoPliers);
            producto.Click();

            System.Threading.Thread.Sleep(2000);
        }
        public string ObtenerNombreDelProductoDetalle()
        {
            return WaitForElement(lblTituloDetalleProducto).Text;
        }
    }
}