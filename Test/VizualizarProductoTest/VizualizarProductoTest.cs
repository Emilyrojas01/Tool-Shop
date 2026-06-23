using Tool_shop.PageObject.DetalleProductoPage;
using Tool_shop.PageObject.InicioSesionPage;
using Tool_Shop.Tests;

namespace Tool_shop.Test.DetalleProductoTest
{
    [TestFixture]
    public class VisualizarProductoTest : BaseTest
    {
        public VisualizarProductoTest() : base("Detalle Producto") { }

        [Test]
        public void VerDetalleProducto()
        {
         
            var loginPage = new InicioSesionPage(Driver);
            var detallePage = new DetalleProductoPage(Driver);

         
            loginPage.GoTo();
            loginPage.Login("user1616@gmail.com", "User1616*");

       
            Driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/");
            System.Threading.Thread.Sleep(1500);

            detallePage.SeleccionarProductoPliers();


            string nombreEnDetalle = detallePage.ObtenerNombreDelProductoDetalle();

            Assert.That(nombreEnDetalle, Does.Contain("Pliers").IgnoreCase,
                $"La página de detalle no cargó el producto correcto. Se leyó: {nombreEnDetalle}");
        }
    }
}