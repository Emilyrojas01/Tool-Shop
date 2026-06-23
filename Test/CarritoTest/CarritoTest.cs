using NUnit.Framework;
using Tool_shop.PageObject.InicioSesionPage;
using Tool_shop.PageObject.CarritoPage;
using Tool_Shop.Tests;

namespace Tool_shop.Test.CarritoTest
{
    [TestFixture]
    public class CarritoTest : BaseTest
    {
        public CarritoTest() : base("Agregar Carrito Por Nombre") { }

        [Test]
        public void AgregarProductoAlCarrito_DeberiaIncrementarElContador()
        {
            var loginPage = new InicioSesionPage(Driver);
            var carritoPage = new CarritoPage(Driver);

     
            loginPage.GoTo();
            loginPage.Login("user1616@gmail.com", "User1616*");

    
            carritoPage.IrAlInicio();


            carritoPage.BuscarProductoPorSuNombre("Combination Pliers");


            carritoPage.ClicAñadirAlCarrito();


            string cantidadActual = carritoPage.ObtenerCantidadDelCarrito();
            Assert.That(cantidadActual, Is.EqualTo("1"),
                $"La validación falló. El contador en la barra superior no aumentó: '{cantidadActual}'");
        }
    }
}