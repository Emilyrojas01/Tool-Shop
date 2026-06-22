using OpenQA.Selenium;
using Tool_Shop.PageObject;

namespace Tool_shop.PageObject.CategoriaPage
{
    public class CategoriaPage : BasePage
    {
        private readonly string homeUrl = "https://practicesoftwaretesting.com/";

        private By btnInicioMenu = By.CssSelector("a[data-test='nav-home']");

      
        private By chkCategoria = By.XPath("//label[contains(text(),'Hammer')] | //input[contains(@data-test,'category')]/following-sibling::label[contains(text(),'Hammer')]");

        private By lblPrimerProductoFiltrado = By.CssSelector("[data-test='product-name']");

        public CategoriaPage(IWebDriver driver) : base(driver) { }

 
        public void GoTo()
        {
            Driver.Navigate().GoToUrl(homeUrl);
        }

        public void IrAlInicio()
        {
          
            WaitForElementToBeClickable(btnInicioMenu).Click();


            System.Threading.Thread.Sleep(1500);
        }

        public void SeleccionarCategoriaHammer()
        {
           
            IrAlInicio();

          
            var checkboxLabel = WaitForElementToBeClickable(chkCategoria);
            checkboxLabel.Click();

          
            System.Threading.Thread.Sleep(2500);
        }

 
        public string ObtenerNombreDelProductoFiltrado()
        {
            return WaitForElement(lblPrimerProductoFiltrado).Text;
        }
    }
}