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
    public partial class Welcome : Form
    {
        private List<int> sandwichSelections = new List<int>();
        private int step = 0;

        
        public Welcome()
        {
            InitializeComponent();
            TC.InitializeInventory();
        }
                

        //instantiates a new OrderPageBMC form
        private void newBMC()
        {
            OrderPageBMC bmc = new OrderPageBMC();
            bmc.MdiParent = this;
            
            bmc.Show();
            this.LayoutMdi(MdiLayout.Cascade);
        }

        //instantiates a new OrderPageVS form
        private void newVS()
        {
            OrderPageVS vs = new OrderPageVS();
            vs.MdiParent = this;
            
            vs.Show();
            this.LayoutMdi(MdiLayout.Cascade);
        }

        //instantiates a new OrderPagePay form
        private void newPay()
        {
            OrderPagePay pay = new OrderPagePay(sandwichSelections);
            pay.MdiParent = this;

            pay.Show();
            this.LayoutMdi(MdiLayout.Cascade);
        }

        //instantiates a new OrderPageInventory form
        private void newInv()
        {
            OrderPageInventory inv = new OrderPageInventory();
            inv.MdiParent = this;

            inv.Show();
            this.LayoutMdi(MdiLayout.Cascade);
        }

        //saves selections to sandwichSelections
        private void saveSelections(List<int> selected)
        {
            foreach (int s in selected)
                sandwichSelections.Add(s);
        }

        //updates the inventory removing the items from a specific order then 
        //clears sandwichSelections
        private void updateInventory()
        {
            foreach (int s in sandwichSelections)
                TC.Inventory[s].Quantity -= 1;
            sandwichSelections.Clear();
        }

        //generates the first child window for making a sandwich
        private void newSandwichToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newBMC(); //create and show new OrderPageBMC child

            //enable/disable controls and iterate step counter
            nextToolStripMenuItem.Enabled = true;
            cancelToolStripMenuItem.Enabled = true;
            newSandwichToolStripMenuItem.Enabled = false;
            step = 1;
        }

        private void nextToolStripMenuItem_Click(object sender, EventArgs e)
        {
            switch (step)
            {
                case 1: //next has been clicked from OrderPageBMC
                    OrderPageBMC bmc = (OrderPageBMC)ActiveMdiChild;

                    if (bmc.allSelected()) //save selection values, open next window, close bmc
                    {
                        //retrieve and store the users selections from the form
                        saveSelections(bmc.selections());

                        bmc.Close();  //close the current child window
                        newVS(); //create and show new OrderPageVS child
                        step = 2; //iteratestep counter to VS window
                    }
                    else //create message window informing user to select one of each
                    {
                        MessageBox.Show("You must select at least one option from each group",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                        break;
                case 2: //next has been clicked from OrderPageVS
                    //retrieve and store users selections from the form
                    OrderPageVS vs = (OrderPageVS)ActiveMdiChild;
                    saveSelections(vs.selections());

                    vs.Close();
                    newPay();//create and show new OrderPagePay child
                    step = 3; //iterate step counter to Pay window
                    break;
                case 3: //next clicked from OrderPagePay
                    //retrieve the form
                    OrderPagePay pay = (OrderPagePay)ActiveMdiChild;
                    //validate the pay info, if the allowed attempts is exceeded cancel the order
                    if (!pay.validatePayment()) //if the payment was invalid
                    {
                        //validatePayment does all the heavy lifting except for cancelling the order
                        //which we have to do here, so if the allowed attempts have been exceeded
                        //we cal the function to cancel the order.
                        if (pay.Attempts == 0) //if there are no attempts left
                            cancelOrder();
                    }
                    else //thank customer for order and close window, update inventory and display                    
                    {
                        MessageBox.Show("Thank you for your order",
                            "Thank your", MessageBoxButtons.OK, MessageBoxIcon.None);
                        pay.Close();

                        updateInventory(); //remove sandwichSelections from inventory and clear list

                        //display the updated inventory screen
                        newInv();

                        //Disable the cancel button since it no longer applies
                        cancelToolStripMenuItem.Enabled = false;
                        step = 4;
                    }
                    break;
                case 4: //next is pressed from OrderPageInventory
                    OrderPageInventory inv = (OrderPageInventory)ActiveMdiChild;
                    inv.Close();

                    //enable/disable controls and reset step counter
                    nextToolStripMenuItem.Enabled = false;
                    newSandwichToolStripMenuItem.Enabled = true;
                    step = 0;
                    //program is now ready to accept a new sandwich order
                    break;

            } //end switch
        }

        //can be called at any time in order process, calls cancelOrder
        private void cancelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cancelOrder();
        }

        //function that actually does the work of cancelling the order so we can call it 
        //when the payment attempts are exceeded
        private void cancelOrder()
        {
            //close active window
            switch (step)
            {
                case 1: //cancel has been clicked from OrderPageBMC
                    OrderPageBMC bmc = (OrderPageBMC)ActiveMdiChild;
                    bmc.Close();  //close the current child window

                    break;
                case 2: //cancel has been clicked from OrderPageVS
                    OrderPageVS vs = (OrderPageVS)ActiveMdiChild;

                    vs.Close(); //close the current child window
                    break;
                case 3:
                    OrderPagePay pay = (OrderPagePay)ActiveMdiChild;

                    pay.Close(); //close the current child window
                    break;

            } //end switch

            //empty sandwichSelections list
            sandwichSelections.Clear();
            //reset step to 0
            step = 0;

            MessageBox.Show("Order Canceled",
                           "Order Canceled", MessageBoxButtons.OK, MessageBoxIcon.None);

            nextToolStripMenuItem.Enabled = false;
            cancelToolStripMenuItem.Enabled = false;
            newSandwichToolStripMenuItem.Enabled = true;
        }


    }
}
