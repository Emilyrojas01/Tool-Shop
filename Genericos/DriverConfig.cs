using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Genericos.DriversConfig
{


    public class ChromeFactory
    {


        public static IWebDriver CrearDriver(ChromeOptions options)
        {

            // Crea y retorna un nuevo ChromeDriver con las opciones proporcionadas
            return new ChromeDriver(options);

        }
    }
}
