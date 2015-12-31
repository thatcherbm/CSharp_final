using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SandwichLibrary;

namespace ElevatedTrackSandwiches
{
    
    
    public static class TC
    {
        //Constants for accessing array
        //Breads white, wheat
        public const int WHITE = 0, WHEAT = 1;
        //Meats roast beef, ham, turkey
        public const int BEEF = 2, HAM = 3, TURKEY = 4;
        //Cheeses american, swiss, provolone, cheddar
        public const int AMERICAN = 5, SWISS = 6, PROVOLONE = 7, CHEDDAR = 8;
        //Veggies pickles, olives, cucumber, tomato, lettuce, spinach, greenPeppers, bananaPeppers
        public const int PICKLES = 9, OLIVES = 10, CUCUMBER = 11, TOMATO = 12,
            LETTUCE = 13, SPINACH = 14, GREENPEPPERS = 15, BANANAPEPPERS = 16;
        //Sauces mayo, mustard, honeyMustard, southwest, vinagrette
        public const int MAYO = 17, MUSTARD = 18, HONEYMUSTARD = 19, SOUTHWEST = 20, VINAIGRETTE = 21;

        public static InventoryItem[] Inventory = new InventoryItem[22];

        public static void InitializeInventory()
        {
            //initialize breads            
            Inventory[WHITE] = new InventoryItem("White Bread", 10, "rolls", 1.00M);
            Inventory[WHEAT] = new InventoryItem("Wheat Bread", 1, "rolls", 1.00M);
            //initalize meats
            Inventory[BEEF] = new InventoryItem("Roast Beef", 1, "slices", 3.00M);
            Inventory[HAM] = new InventoryItem("Ham", 12, "slices", 2.00M);
            Inventory[TURKEY] = new InventoryItem("Turkey", 0, "slices", 2.00M);
            //initialize cheeses
            Inventory[AMERICAN] = new InventoryItem("American Cheese", 1, "slices", 0.50M);
            Inventory[SWISS] = new InventoryItem("Swiss Cheese", 0, "slices", 0.50M);
            Inventory[PROVOLONE] = new InventoryItem("Provolone Cheese", 12, "slices", 0.50M);
            Inventory[CHEDDAR] = new InventoryItem("Cheddar Cheese", 8, "slices", 0.50M);
            //initialize veggies
            Inventory[PICKLES] = new InventoryItem("Pickles", 8, "ounces", 0.25M);
            Inventory[OLIVES] = new InventoryItem("Olives", 0, "ounces", 0.25M);
            Inventory[CUCUMBER] = new InventoryItem("Cucumber", 24, "slices", 0.25M);
            Inventory[TOMATO] = new InventoryItem("Tomatoes", 32, "slices", 0.25M);
            Inventory[LETTUCE] = new InventoryItem("Lettuce", 1, "ounces", 0.25M);
            Inventory[SPINACH] = new InventoryItem("Spinach", 13, "ounces", 0.45M);
            Inventory[GREENPEPPERS] = new InventoryItem("Green Peppers", 8, "ounces", 0.25M);
            Inventory[BANANAPEPPERS] = new InventoryItem("Banana Peppers", 8, "ounces", 0.45M);
            //initialize sauces
            Inventory[MAYO] = new InventoryItem("Mayo", 1, "ounces", 0.15M);
            Inventory[MUSTARD] = new InventoryItem("Mustard", 15, "ounces", 0.15M);
            Inventory[HONEYMUSTARD] = new InventoryItem("Honey Mustard", 15, "ounces", 0.25M);
            Inventory[SOUTHWEST] = new InventoryItem("Southwest Sauce", 15, "ounces", 0.25M);
            Inventory[VINAIGRETTE] = new InventoryItem("Vinaigrette", 15, "ounces", 0.25M);

        }
    }

    
}
