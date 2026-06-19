using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Genericos.DriversConfig;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Tool_Shop.Tests
{

    public abstract class BaseTest
    {

        protected IWebDriver Driver;

        protected string reportTestPage = "";
        public static ExtentTest extentTest;
        public static ExtentReports extent;

        public BaseTest(string pageContext)
        {

            this.reportTestPage = pageContext;
        }
        [OneTimeSetUp] // inicializar reporte pasando spart - Nuevo

        public void StarReport()
        {

            var spark = new ExtentSparkReporter("Reporte.html");
            extent = new ExtentReports();
            extent.AttachReporter(spark);
            Console.WriteLine(AppDomain.CurrentDomain.BaseDirectory);
        }

        [SetUp]

        public void SetUp()
        {
            extentTest = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");

            Driver = ChromeFactory.CrearDriver(options);
        }

        [TearDown]

        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                extentTest.Pass("Test exitoso");
            }
            else
            {
                extentTest.Fail(
                  TestContext.CurrentContext.Result.Message);

            }

            Driver?.Dispose();
        }
        [OneTimeTearDown]
        public void EndReport()
        {
            extent.Flush();
        }

    }

}