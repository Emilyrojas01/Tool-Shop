using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Tool_Shop.PageObject
{
    public abstract class BasePage
    {
        protected IWebDriver Driver;
        protected WebDriverWait Wait;

        protected BasePage(IWebDriver driver)
        {
            Driver = driver;
            
            Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

     
        protected IWebElement WaitForElement(By Locator)
        {
            return Wait.Until(d => d.FindElement(Locator));
        }

       
        protected IWebElement WaitForElementToBeClickable(By Locator)
        {
            return Wait.Until(d =>
            {
                var element = d.FindElement(Locator);
                
                return (element.Displayed && element.Enabled) ? element : null;
            });
        }

        public string GetCurrentUrl()
        {
            return Driver.Url;
        }
    }
}