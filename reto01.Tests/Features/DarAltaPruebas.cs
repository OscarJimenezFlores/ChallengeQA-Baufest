using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace reto01.Tests.Features
{
    [Binding]
    public sealed class DarAltaPruebas
    {
        private readonly ScenarioContext _scenarioContext;
        IWebDriver _driver;
        public DarAltaPruebas(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            var options = new ChromeOptions();
            options.AddArguments("--disable-dev-shm-usage");
            var capabilities = options.ToCapabilities();
            _driver = new ChromeDriver();
        }

        [Given("Ir a la pagina (.*)")]
        public void Iralapagina(string url)
        {
            _driver.Url = url;
            _driver.Manage().Window.Maximize();
            Thread.Sleep(1000);
        }
        [Given("Presionar link Sign Up")]
        public void PresionarlinkSignUp()
        {
            _driver.FindElement(By.XPath("//*[@id='signin2']")).Click();
            Thread.Sleep(1000);
        }
        [Given("Introducir el nombre usuario (.*) y password (.*)")]
        public void DadoLaClave(string usuario, string clave)
        {
            _driver.FindElement(By.XPath("//*[@id='sign-username']")).SendKeys(usuario);
            _driver.FindElement(By.XPath("//*[@id='sign-password']")).SendKeys(clave);
        }
        [When("Presione click en el boton Sign Up")]
        public void PresioneclickenelbotonSignUp()
        {
            _driver.FindElement(By.XPath("//*[@id='signInModal']/div/div/div[3]/button[2]")).Click();
            Thread.Sleep(3000);
        }

        [Then("Mensaje de usuario dado de alta satisfactoriamente")]
        public void Mensajedeusuariodadodealtasatisfactoriamente()
        {

            string popup = _driver.SwitchTo().Alert().Text;
            Console.WriteLine(popup);
            _driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
            string _mensaje = "Sign up successful";
            _driver.Close();
            Assert.IsTrue(popup.ToLower().Contains(_mensaje.ToLower()));
        }        

        [Then("Mensaje de usuario ya existente")]
        public void Mensajedeusuarioyaexistente()
        {

            string popup = _driver.SwitchTo().Alert().Text;
            Console.WriteLine(popup);
            _driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
            string _mensaje = "already exist";
            _driver.Close();
            Assert.IsTrue(popup.ToLower().Contains(_mensaje.ToLower()));
            //_driver.Dispose();//.Close();
        }        
    }
}