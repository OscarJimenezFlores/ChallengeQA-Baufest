using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace reto02.Tests.Features
{
    [Binding]
    public sealed class GestionarMascotasPruebas
    {
        private readonly ScenarioContext _scenarioContext;
        HttpClient _cliente;
        Mascota _mascota;
        string _id;
        HttpResponseMessage _respuesta;
        public GestionarMascotasPruebas(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
            //_driver = new ChromeDriver();
        }

        [Given("Teniendo el nombre (.*) y categoria (.*)")]
        public void Teniendoelnombreycategoria(string nombre, string categoria)
        {
            _mascota = Mascota.CrearMascota(nombre, categoria);
        }
        [Given("El identificador de la mascota (.*)")]
        public void Elidentificadordelamascota(string id)
        {
            _id = id;
        }

        [Given("Busco identificador de la mascota (.*) y actualizo el nombre por (.*)")]
        public void Buscoidentificadordelamascotayactualizoelnombrepor(string id, string nombre)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://petstore.swagger.io");
                client.DefaultRequestHeaders.Add("api_key", "special-key");
                _respuesta = client.GetAsync("/v2/pet/"+id).Result;
            }
            Console.WriteLine(_respuesta.Content.ReadAsStringAsync().Result);
            var mascota = JsonSerializer.Deserialize<Mascota>(_respuesta.Content.ReadAsStringAsync().Result);
            mascota.name = nombre;
            _mascota = mascota;
        }
        [When("Envia peticion de agregar")]
        public void Enviapeticiondeagregar()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://petstore.swagger.io");
                client.DefaultRequestHeaders.Add("api_key", "special-key");
                var payload = JsonSerializer.Serialize(_mascota);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");
                _respuesta = client.PostAsync("/v2/pet", content).Result;
            }
        }

        [When("Envia peticion de Obtener")]
        public void EnviapeticiondeObtener()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://petstore.swagger.io");
                client.DefaultRequestHeaders.Add("api_key", "special-key");
                _respuesta = client.GetAsync("/v2/pet/"+_id).Result;
            }
        }

        [When("Envia peticion de Actualizar")]
        public void EnviapeticiondeActualizar()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://petstore.swagger.io");
                client.DefaultRequestHeaders.Add("api_key", "special-key");
                var payload = JsonSerializer.Serialize(_mascota);
                var content = new StringContent(payload, Encoding.UTF8, "application/json");
                _respuesta = client.PutAsync("/v2/pet", content).Result;
            }
        }

        [Then("Retorna mensaje satisfactorio")]
        public void Mensajedeusuariodadodealtasatisfactoriamente()
        {

            Console.WriteLine(_respuesta.Content.ReadAsStringAsync());
            Assert.AreEqual(System.Net.HttpStatusCode.OK, _respuesta.StatusCode);
        }        

        [Then("Retorna una mascota de nombre (.*)")]
        public void Retornaunamascotadenombre(string nombre)
        {
            var mascota = JsonSerializer.Deserialize<Mascota>(_respuesta.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(nombre.ToLower(), mascota.name.ToLower());
        }        
    }
}