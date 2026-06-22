using NUnit.Framework;
using Tool_shop.PageObject.InicioSesionPage;
using Tool_shop.PageObject.BusquedaPage;
using Tool_Shop.Tests;

namespace Tool_shop.Test.BusquedaTest
{
    [TestFixture]
    public class BusquedaTest : BaseTest
    {
        public BusquedaTest() : base("Busqueda Con Login") { }

        [Test]
        public void BuscarProducto_ConSesionIniciada()
        {
           
            var loginPage = new InicioSesionPage(Driver);
            var busquedaPage = new BusquedaPage(Driver);

            
            loginPage.GoTo();
            loginPage.Login("user1414@gmail.com", "User1414*");

            
            busquedaPage.RealizarBusqueda("Slip");

            string productoObtenido = busquedaPage.ObtenerNombreDelPrimerProducto();
            Assert.That(productoObtenido, Does.Contain("Slip Joint Pliers"),
                $"La búsqueda falló. Se encontró el producto: {productoObtenido}");
        }
    }
}