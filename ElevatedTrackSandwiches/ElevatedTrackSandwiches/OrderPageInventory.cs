using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SandwichLibrary;

namespace ElevatedTrackSandwiches
{
    public partial class OrderPageInventory : OrderPage
    {
        public OrderPageInventory()
        {
            InitializeComponent();
            inventoryTxtBx.Text = "";  //clear textbox
            foreach (InventoryItem i in TC.Inventory)
                inventoryTxtBx.AppendText(i + "\n");
        }
    }
}
