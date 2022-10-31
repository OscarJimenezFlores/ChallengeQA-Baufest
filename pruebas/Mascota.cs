using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebas
{
//     {
//   "id": 0,
//   "category": {
//     "id": 0,
//     "name": "dog"
//   },
//   "name": "guauguau",
//   "photoUrls": [
//     "string"
//   ],
//   "tags": [
//     {
//       "id": 0,
//       "name": "dog"
//     }
//   ],
//   "status": "available"
// }
    public class Category
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    public class Tag
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    
    public class Mascota
    {
        public static Mascota CrearMascota(string nombre, string categoria)
        {
            return new Mascota() {
                id = 0,
                category = new Category{ id=0, name=categoria },
                name = nombre,
                photoUrls = new List<string>(),
                tags = new List<Tag>(){ new Tag{id = 0, name = categoria}},
                status = "available"
            };
        }
        public int id { get; set; }
        public Category category { get; set; }
        public string name { get; set; }
        public List<string> photoUrls { get; set; }
        public List<Tag> tags { get; set; }
        public string status { get; set; }
    }
}