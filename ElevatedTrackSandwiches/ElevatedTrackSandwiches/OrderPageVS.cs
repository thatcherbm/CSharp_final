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
    
    
    public partial class OrderPageVS : OrderPage
    {
        //i need a way to alter the controls in the child from the parent
        //this array stores the values of which controls should be disabled
        //if an item is out of stock.  i want to use meaningful indices, even 
        //though that means I have a number of unused/empty elements in the array
        public bool[] enabledControls = new bool[22]; 
        
        public OrderPageVS()
        {
            InitializeComponent();
            //initialize enabledControls values to true
            for (int i = TC.PICKLES; i <= TC.VINAIGRETTE; i++)
            {
                if (TC.Inventory[i].Quantity == 0)
                    enabledControls[i] = false;
                else
                    enabledControls[i] = true;
            }
        }

        private void OrderPageVS_Shown(object sender, EventArgs e)
        {
            refreshControls();
        }

        //refreshes the controls on the form based on the boolean array enabledControls
        //which the parent window has set based on the inventory.
        private void refreshControls()
        {
            picklesChkBx.Enabled = enabledControls[TC.PICKLES];
            olivesChkBx.Enabled = enabledControls[TC.OLIVES];
            cucumberChkBx.Enabled = enabledControls[TC.CUCUMBER];
            tomatoChkBx.Enabled = enabledControls[TC.TOMATO];
            lettuceChkBx.Enabled = enabledControls[TC.LETTUCE];
            spinachChkBx.Enabled = enabledControls[TC.SPINACH];
            greenpeppersChkBx.Enabled = enabledControls[TC.GREENPEPPERS];
            bananapeppersChkBx.Enabled = enabledControls[TC.BANANAPEPPERS];
            mayoChkBx.Enabled = enabledControls[TC.MAYO];
            mustardChkBx.Enabled = enabledControls[TC.MUSTARD];
            honeymustardChkBx.Enabled = enabledControls[TC.HONEYMUSTARD];
            southwestChkBx.Enabled = enabledControls[TC.SOUTHWEST];
            vinagretteChkBx.Enabled = enabledControls[TC.VINAIGRETTE];
        }

        //returns the values of the selections as a list of integers
        public List<int> selections()
        {
            List<int> selected = new List<int>();
            if (picklesChkBx.Checked)
                selected.Add(TC.PICKLES);
            if (olivesChkBx.Checked)
                selected.Add(TC.OLIVES);
            if (cucumberChkBx.Checked)
                selected.Add(TC.CUCUMBER);
            if (tomatoChkBx.Checked)
                selected.Add(TC.TOMATO);
            if (lettuceChkBx.Checked)
                selected.Add(TC.LETTUCE);
            if (spinachChkBx.Checked)
                selected.Add(TC.SPINACH);
            if (greenpeppersChkBx.Checked)
                selected.Add(TC.GREENPEPPERS);
            if (bananapeppersChkBx.Checked)
                selected.Add(TC.BANANAPEPPERS);
            if (mayoChkBx.Checked)
                selected.Add(TC.MAYO);
            if (mustardChkBx.Checked)
                selected.Add(TC.MUSTARD);
            if (honeymustardChkBx.Checked)
                selected.Add(TC.HONEYMUSTARD);
            if (southwestChkBx.Checked)
                selected.Add(TC.SOUTHWEST);
            if (vinagretteChkBx.Checked)
                selected.Add(TC.VINAIGRETTE);

            return selected;
        }
    }
}
