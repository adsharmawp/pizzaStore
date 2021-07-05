using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Model
{
    public class Pizza
    {
        public string Name { get; set; }
        public int Cost { get; set; }
        public string ImagePath { get; set; }
    }
    public class PizzaInventory
    {
        public List<Pizza> PizzaList { get; set; }
    }
}
