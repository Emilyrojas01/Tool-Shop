using Tool_shop.PageObject.InicioSesionPage;
using Tool_Shop.Tests;

namespace Tool_shop.Test.InicioSesionTest
{
    [TestFixture]
    public class InicioSesionTest : BaseTest
    {
        public InicioSesionTest() : base("Login") { }

        [Test]
        public void LoginCorrecto_RedireccionExitosa()
        {
            var loginPage = new InicioSesionPage(Driver);

            loginPage.GoTo();


            loginPage.Login("user1414@gmail.com", "User1414*");


            string urlActual = loginPage.GetCurrentUrl();
            Assert.That(urlActual, Does.Contain("/account"),
                $"El login falló. El navegador se quedó en: {urlActual}");
        }

        [Test]
        public void LoginIncorrecto()
        {
            var loginPage = new InicioSesionPage(Driver);

            loginPage.GoTo();
            loginPage.Login("usuario_falso@correo.com", "claveIncorrecta");

            string urlActual = loginPage.GetCurrentUrl();
            Assert.That(urlActual, Does.Contain("/auth/login"),
                $"Se esperaba permanecer en el login, pero la URL fue: {urlActual}");
        }
    }

}
