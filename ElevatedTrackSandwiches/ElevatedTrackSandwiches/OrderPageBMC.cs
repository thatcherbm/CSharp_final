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
    public partial class OrderPageBMC : OrderPage
    {
        //i need a way to alter the controls in the child from the parent
        //this array stores the values of which controls should be disabled
        //if an item is out of stock.
        public bool[] enabledControls = new bool[9]; 
        

        public OrderPageBMC()
        {
            InitializeComponent();
            //initialize enabledControls values to true
            for (int i = 0; i < enabledControls.Length; i++)
            {
                if (TC.Inventory[i].Quantity == 0)
                    enabledControls[i] = false;
                else
                    enabledControls[i] = true;
            }
            
        }

        private void OrderPageBMC_Shown(object sender, EventArgs e)
        {
            refreshControls();
        }

        //refreshes the controls on the form based on the boolean array enabledControls
        //which the parent window has set based on the inventory.
        private void refreshControls()
        {
            
            
            whiteRdoBtn.Enabled = enabledControls[TC.WHITE];
            wheatRdoBtn.Enabled = enabledControls[TC.WHEAT];
            beefRdoBtn.Enabled = enabledControls[TC.BEEF];
            hamRdoBtn.Enabled = enabledControls[TC.HAM];
            turkeyRdoBtn.Enabled = enabledControls[TC.TURKEY];
            americanRdoBtn.Enabled = enabledControls[TC.AMERICAN];
            swissRdoBtn.Enabled = enabledControls[TC.SWISS];
            provoloneRdoBtn.Enabled = enabledControls[TC.PROVOLONE];
            cheddarRdoBtn.Enabled = enabledControls[TC.CHEDDAR];
        }

        //returns true if one item from each group has been selected, false otherwise
        public bool allSelected()
        {
            return ((whiteRdoBtn.Checked || wheatRdoBtn.Checked) && 
                (beefRdoBtn.Checked || hamRdoBtn.Checked || turkeyRdoBtn.Checked) && 
                (americanRdoBtn.Checked || swissRdoBtn.Checked || provoloneRdoBtn.Checked || cheddarRdoBtn.Checked));
        }

        //returns the values of the selections [bread, meat, cheese]
        public List<int> selections()
        {
            List<int> selected = new List<int>();
            //bread selected[0]
            if (whiteRdoBtn.Checked)
                selected.Add(TC.WHITE);
            else
                selected.Add(TC.WHEAT);
            //meat selected[1]
            if (beefRdoBtn.Checked)
                selected.Add(TC.BEEF);
            else if (hamRdoBtn.Checked)
                selected.Add(TC.HAM);
            else
                selected.Add(TC.TURKEY);
            //cheese selected[2]
            if (americanRdoBtn.Checked)
                selected.Add(TC.AMERICAN);
            else if (swissRdoBtn.Checked)
                selected.Add(TC.SWISS);
            else if (provoloneRdoBtn.Checked)
                selected.Add(TC.PROVOLONE);
            else
                selected.Add(TC.CHEDDAR);

            return selected;
        }
    }
}
