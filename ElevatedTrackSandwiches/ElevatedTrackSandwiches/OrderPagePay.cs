using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SandwichLibrary;
using System.Text.RegularExpressions;

namespace ElevatedTrackSandwiches
{
    public partial class OrderPagePay : OrderPage
    {
        private List<int> Selections;
        private decimal Price { get; set; }
        private int attempts = 3;
        public int Attempts
        {
            get
            {
                return attempts;
            }

            private set
            {
                attempts = value;
            }
        }
        
        public OrderPagePay(List<int> selections)
        {
            InitializeComponent();
            Selections = selections;
            Price = calculatePrice();
            generateYearCollection();
        }

        private void OrderPagePay_Shown(object sender, EventArgs e)
        {            
            foreach (int s in Selections)
            {
                selectionsTxtBx.AppendText(String.Format("{0}\n", TC.Inventory[s].Name));
            }

            string priceInfo = string.Format("{0,-12}{1,8:c}","SubTotal: ",Price);
            priceInfo += string.Format("\n{0,-12}{1,8:c}", "Tax (4.5%): ", Price * (decimal)0.045);
            priceInfo += string.Format("\n{0,-12}{1,8:c}", "Total: ", Price * (decimal)1.045);

            priceTxtBx.Text = priceInfo;
        }
        
        //calculates the price of the sandwich with the selected components
        private decimal calculatePrice()
        {
            decimal price = 0;
            foreach (int t in Selections)
            {
                price += TC.Inventory[t].Price;
            }
            return price;
        }

        //generate collection of possible years for the user to choose from on Year ComboBox
        private void generateYearCollection()
        {
            DateTime today = DateTime.Now;
            int year = today.Year;
            int[] yearChoices = new int[7];
            for (int i = 0; i < 7; i++)
                yearComboBox.Items.Add(year + i);
            

        }

        //validate payment
        public bool validatePayment()
        {
            bool valid = true;
            string invalidMessage = "";

            //validate the card number, first check for a length of 16 digits to prevent issues
            //with retrieving the first 4 digits if no card number has been entered            
            string cardNumber = ccnumTxtBx.Text;
            //remove spaces if the customer has decided to add them
            cardNumber = Regex.Replace(cardNumber, @"\s", ""); //removes all whitespace
            if (cardNumber.Length != 16) //card number must be 16 digits
            {
                valid = false;
                invalidMessage += "Credit Card Number is wrong length. Must be 16 digits\n";
            }
            else //first 4 digits must be one of (1298, 1267, 4512, 4567, 8901, 8933)
            {
                string firstFour = cardNumber.Substring(0, 4);
                if (firstFour != "1298" && firstFour != "1267" && firstFour != "4512" && firstFour != "4567" &&
                firstFour != "8901" && firstFour != "8933") //if the first 4 aren't any of the options
                {
                    valid = false;
                    invalidMessage += "Credit Card Number is invalid.\n";
                }                
            }

            //the following try/catch isn't required by the prompt, but technically the card number should only
            //be digits, which could have resulted in a failed length above, but the customer may have also
            //separated 4 digit groups with dashes instead of the spaces the GUI tells them they are allowed
            try
            {
                //attempt to store card number value as an integer keeping in mind that cardNumber had
                //allowed whitespace removed
                long cardNumLong = Convert.ToInt64(cardNumber);
            }
            catch (FormatException)
            {
                valid = false;
                invalidMessage += "Card Number must be digits, no letters or symbols.\n";
            }           
            

            //months combobox limits selections to valid items, as does years combobox via method 
            //generateYearCollection which runs in the constructor.  We still need to verify that
            //the month/year combination is greater than the current month/year combination but not
            //more than 6 years from now
            DateTime today = DateTime.Now; //get today's date
            int userMonth = monthComboBox.SelectedIndex + 1; //cheating with meaningful indices
            int userYear = Convert.ToInt32(yearComboBox.SelectedItem);
            //create a user defined expiration date (most cards expire first day of month after the
            //month indicated)
            int expireMonth = userMonth;
            int expireYear = userYear;
            if (userMonth == 12)  //have to avoid an out of range exception
            {
                expireMonth = 1;
                expireYear = userYear + 1;
            }
            else
                expireMonth = userMonth + 1;
            DateTime user = new DateTime(expireYear, expireMonth, 1);
            //create date 6 years from today
            DateTime todayPlusSixYears = new DateTime(today.Year + 6, today.Month, today.Day);
            //logic to test the expiration date
            //first check to see if expiration date is later than today
            //if today is later than the expiration or the expiration is more than 6 years from today
            if (today.CompareTo(user) >= 0 || user.CompareTo(todayPlusSixYears) > 0) 
            {
                valid = false;
                if (today.CompareTo(user) >= 0)
                    invalidMessage += "Card Has Expired.\n";
                if (user.CompareTo(todayPlusSixYears) > 0)
                    invalidMessage += "Expiration Year out of range.\n";
            }

            //validate the security code
            string secCode = secCodeTxtBx.Text;
            if (secCode.Length != 3)
            {
                valid = false;
                invalidMessage += "Security Code must be 3 digits.\n";
            }
            int secCodeNum;
            try
            {
                secCodeNum = Convert.ToInt32(secCodeTxtBx.Text);
            }
            catch (FormatException)
            {
                valid = false;
                invalidMessage += "Security Code must be digits, no letters or symbols.\n";
            }

            //at this point all fields have been validated.  if any field was invalid valid will return
            //false, we also have a string consisting of one or more messages about what was wrong. 
            //if valid == false create a message box with the error message to re-prompt, if the allowed 
            //attempts have been exceeded inform the customer of order cancelation
            if (valid == false)
            {
                if (--Attempts > 0)
                {
                    invalidMessage += string.Format("\nRe-Enter values, you have {0} attemps remaining.", Attempts);
                    MessageBox.Show(invalidMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    invalidMessage += "\nAllowed Attempts exceeded.  Order Canceled";
                    MessageBox.Show(invalidMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return valid;
        }
    }
}
