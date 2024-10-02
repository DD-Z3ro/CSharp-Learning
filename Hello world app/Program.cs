// See https://aka.ms/new-console-template for more information
using HelloWorldApp.Handlers;
using HelloWorldApp.Model;
using System.Collections;
using System.Xml.Linq;

//Console.WriteLine("Hello, World!");


//ShoppingListItem item = new ShoppingListItem("Bannanas", 5);

//Console.WriteLine(item);

//Console.WriteLine(item.GetName());
//Console.WriteLine(item.GetAmount());

//List<ShoppingListItem> shoppingList = new List<ShoppingListItem>();
//shoppingList.Add(new ShoppingListItem("apples", 2));
//shoppingList.Add(new ShoppingListItem("mints", 3));

//Console.WriteLine(shoppingList.Count);

ShoppingList list = new ShoppingList();
string path = "C:\\Users\\omnig\\Desktop\\Coding\\List.json";
list.LoadFromFile(path);
while (true)
{
    Console.WriteLine("Welcome to the shopping list");
    Console.WriteLine("Type a number to perform the action.");
    Console.WriteLine("1.View list");
    Console.WriteLine("2.Add to list");
    Console.WriteLine("3.Remove from list");
    Console.WriteLine("4.Save list");

    // these are just tests for removal stuff
    //list.AddItem("apples", 3);
    //list.AddItem("mints", 2);

    int choice = Convert.ToInt32(Console.ReadLine());
    if (choice == 1)
    {
        Console.WriteLine(list);
        Console.ReadLine();
        Console.Clear();
    }
    if (choice == 2)
    {
        Console.WriteLine("Name the item you wish to add");
        // takes user input and stores it in itemName as a string
        string itemName = Console.ReadLine();
        if (list.IsonList(itemName))
        {
            Console.WriteLine("This item already exists on the list, would you like to adjust the amount?");
            Console.WriteLine("Type 1 for Yes ");
            Console.WriteLine("Type 2 for No");
            int choice2 = Convert.ToInt32(Console.ReadLine());
            if (choice2 == 1)
            {

                Console.WriteLine("How much of " + itemName + " do you wish to get?");
                int itemAmount = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("The value for " + itemName + " has been changed to " + itemAmount + ".");
                // telling lies and aint changin shiz
                list.AppendItem(itemName, itemAmount);
                Console.WriteLine(list);
                Console.ReadLine();
                Console.Clear();
            }
            if (choice2 == 2)
            {
                Console.WriteLine(list);
                Console.ReadLine();
                Console.Clear();
            }
        }
        else
        {
            Console.WriteLine("..And how much of that item would you like?");
            // Takes user input, converts it into an integer and stores it within itemAmount
            int itemAmount = Convert.ToInt32(Console.ReadLine());
            list.AddItem(itemName, itemAmount);
            Console.WriteLine(list);
            Console.ReadLine();
            Console.Clear();
        }



    }
    if (choice == 3)
    {
        Console.WriteLine(list);
        Console.WriteLine("Name the item you wish to remove");
        //Takes user input for item that is to be removed
        string removeItem = Console.ReadLine();
        list.removeItem(removeItem);
        //will print list to show item has been removed
        Console.WriteLine(list);
        Console.ReadLine();
        Console.Clear();
    }

    if (choice == 4)
    {
        Console.WriteLine("Now saving the shopping list to directory: " + path);
        list.SaveToFile(path);
        Console.WriteLine("Save complete");
        Console.ReadLine();
        Console.Clear();


    }

}
