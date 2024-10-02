using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldApp.Model
{
    public class ShoppingListItem
    {
        public string Name { get; set; }
        public int Amount { get; set; }
        
        public ShoppingListItem(string name, int amount)
        {
            Name = name;
            Amount = amount;
        }

    }
}
