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
    public class CrustController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Crust> Get()
        {
            var folderDetails = Path.Combine(Directory.GetCurrentDirectory(), $"FileData\\Crust.json");
            var JSON = System.IO.File.ReadAllText(folderDetails);
            var root = Newtonsoft.Json.JsonConvert.DeserializeObject<CurstInventory>(JSON);
            return root.CrustList;
        }
    }
}
