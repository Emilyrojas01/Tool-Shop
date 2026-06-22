using Tool_shop.PageObject.CategoriaPage;
using Tool_shop.PageObject.InicioSesionPage;
using Tool_Shop.Tests;

namespace Tool_shop.Test.CategoriaTest
{
    [TestFixture]
    public class CategoriaTest : BaseTest
    {
        public CategoriaTest() : base("Filtro Categoria") { }

        [Test]
        public void FiltrarPorCategoria()
        {
            var loginPage = new InicioSesionPage(Driver);
            var categoriaPage = new CategoriaPage(Driver);

         
            loginPage.GoTo();
            loginPage.Login("user1515@gmail.com", "User1515*");

            categoriaPage.SeleccionarCategoriaHammer();

            string productoVisible = categoriaPage.ObtenerNombreDelProductoFiltrado();

            Assert.That(productoVisible, Does.Contain("Hammer").IgnoreCase.Or.Contains("Mallet").IgnoreCase,
                $"El filtro falló o se mostró un producto incorrecto: {productoVisible}");
        }
    }
}