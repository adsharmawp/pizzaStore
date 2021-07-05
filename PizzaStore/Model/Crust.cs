using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Model
{
    public class Crust
    {
        public string Name { get; set; }
        public int Cost { get; set; }
    }
    public class CurstInventory
    {
        public List<Crust> CrustList { get; set; }
    }
}
