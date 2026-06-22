using Tool_shop.PageObject.BusquedaPage;
using Tool_Shop.Tests;

namespace Tool_shop.Test.BusquedaTest
{
    [TestFixture]
    public class BusquedaTest : BaseTest
    {
        public BusquedaTest() : base("Busqueda") { }

        [Test]
        public void BuscarProducto_DeberiaMostrarloEnCuadricula()
        {
            var busquedaPage = new BusquedaPage(Driver);

          
            busquedaPage.GoTo();

           
            busquedaPage.RealizarBusqueda("Slip");

            
            string productoObtenido = busquedaPage.ObtenerNombreDelPrimerProducto();

           
            Assert.That(productoObtenido, Does.Contain("Slip Joint Pliers"),
                $"La búsqueda falló. Se encontró el producto: {productoObtenido}");
        }
    }
}