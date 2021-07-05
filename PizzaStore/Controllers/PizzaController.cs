using Microsoft.AspNetCore.Mvc;
using PizzaStore.Model;
using System.Collections.Generic;
using System.IO;

namespace PizzaStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Pizza> Get()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"FileData\\PizzaInventory.json");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<PizzaInventory>(JSON);
            return root.PizzaList;
        }
    }
}
