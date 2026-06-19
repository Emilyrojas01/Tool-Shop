using NUnit.Framework;
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

            // 1. Navega al inicio
            loginPage.GoTo();

            // 2. Ejecuta el flujo completo usando tus credenciales válidas
            loginPage.Login("emilyrangelrojas111@gmail.com", "Password1244**");

            // 3. Al ser datos correctos, la página sí te va a redireccionar a /account
            string expectedUrl = "https://practicesoftwaretesting.com/account";

            // 4. Validación final
            Assert.That(loginPage.GetCurrentUrl(), Is.EqualTo(expectedUrl),
                $"El login falló. El navegador se quedó atrapado en: {loginPage.GetCurrentUrl()}");
        }

        [Test]
        public void LoginIncorrecto()
        {
            var loginPage = new InicioSesionPage(Driver);

            loginPage.GoTo();
            // Dejamos este con datos erróneos a propósito para validar el flujo negativo
            loginPage.Login("usuario_falso@correo.com", "claveIncorrecta");

            string expectedUrl = "https://practicesoftwaretesting.com/auth/login";
            Assert.That(loginPage.GetCurrentUrl(), Is.EqualTo(expectedUrl), "La URL no coincide con la esperada.");
        }
    }
}