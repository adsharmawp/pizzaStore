using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaStore.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToppingController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Topping> Get()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"FileData\\Topping.json");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<ToppingInventory>(JSON);
            return root.ToppingList;
        }
    }
}
