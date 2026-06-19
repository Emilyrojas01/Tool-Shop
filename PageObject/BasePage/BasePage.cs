using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers; // 👈 ¡Súper Importante! Agrega este using
using System;

namespace Tool_Shop.PageObject
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;
        private object resultado;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        // CORREGIDO: Ahora sí espera de verdad hasta 10 segundos a que el elemento aparezca
        protected IWebElement WaitForElement(By Locator)
        {
            return Wait.Until(ExpectedConditions.ElementExists(Locator));
        }

        public string GetCurrentUrl()
        {
            return Driver.Url;
        }
    }
}