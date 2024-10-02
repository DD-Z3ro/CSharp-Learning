using HelloWorldApp.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HelloWorldApp.Handlers
{
    internal class ShoppingList
    {
        private List<ShoppingListItem> _list;
        public ShoppingList()
        {
            _list = new List<ShoppingListItem>();
        }
        public void AddItem(string name, int amount)
        {

            if (_list.Any(item => item.Name.Equals(name))){
                return;
            }
            _list.Add(new ShoppingListItem(name, amount));
        }
        public void removeItem(string name)
        {
            //looks through the list for the specified name and removes all entries of it
            _list.RemoveAll(item => item.Name.Equals(name));
            return;
        }
        public bool IsonList(string Name)
        {
            //checks to see if the item is on the list
            return _list.Any(item => item.Name.Equals(Name));
        }
        public void AppendItem(string Name, int amount)
        {
            /**
             * get the item from the list
             * update the items amount
             **/
            var listItem = _list.FirstOrDefault(item => item.Name.Equals(Name));
            if (listItem != null)
            {
                listItem.Amount = amount;
            }
        }
        public override string ToString()
        {
            //StringBuilder builder = new StringBuilder();
            //builder.AppendLine("Items in shoppinglist: ");
            //
            //_list.ForEach(item => builder.AppendLine($"- {item}"));
            //return builder.ToString();
            return JsonConvert.SerializeObject(_list);
        }
        public void SaveToFile(string path)
        {
            var json = JsonConvert.SerializeObject(_list);
            File.WriteAllText(path, json);
        }
        public void LoadFromFile(string path)
        {
            /**
             * check if file exists
             * if file doesnt exist create a file with []
             * read the file
             * deserialize the file and store it in _list
             **/
            // exclamations mean nots, so if file doesnt exist
            if (! File.Exists(path)){
                File.WriteAllText(path, "[]");
            }
            // will read from the file
            var json = File.ReadAllText(path);
            _list = JsonConvert.DeserializeObject<List<ShoppingListItem>>(json);
        }
    }
}
