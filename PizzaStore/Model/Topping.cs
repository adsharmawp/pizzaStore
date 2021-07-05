using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaStore.Model
{
    public class Topping
    {
        public string Name { get; set; }
        public int Cost { get; set; }
    }
    public class ToppingInventory
    {
        public List<Topping> ToppingList { get; set; }
    }
}
