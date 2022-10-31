// See https://aka.ms/new-console-template for more information
using System.Text;
using System.Text.Json;

Console.WriteLine("Hello, World!");

var _mascota = pruebas.Mascota.CrearMascota("prueba", "perro");
        HttpResponseMessage _respuesta;
using (var client = new HttpClient())
{
    client.BaseAddress = new Uri("https://petstore.swagger.io");
    client.DefaultRequestHeaders.Add("api_key", "special-key");
    //var payload = JsonSerializer.Serialize(_mascota);
    //var content = new StringContent(payload, Encoding.UTF8, "application/json");
    //_respuesta = client.PostAsync("/v2/pet", content).Result;
    _respuesta = client.GetAsync("/v2/pet/6739257").Result;

}
var mascota = JsonSerializer.Deserialize<pruebas.Mascota>(_respuesta.Content.ReadAsStringAsync().Result);
Console.WriteLine(_respuesta.Content.ReadAsStringAsync());
