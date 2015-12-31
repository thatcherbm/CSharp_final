namespace ElevatedTrackSandwiches
{
    partial class OrderPageInventory
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderPageInventory));
            this.inventoryTxtBx = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // inventoryTxtBx
            // 
            this.inventoryTxtBx.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inventoryTxtBx.Location = new System.Drawing.Point(13, 13);
            this.inventoryTxtBx.MinimumSize = new System.Drawing.Size(290, 325);
            this.inventoryTxtBx.Name = "inventoryTxtBx";
            this.inventoryTxtBx.ReadOnly = true;
            this.inventoryTxtBx.Size = new System.Drawing.Size(290, 325);
            this.inventoryTxtBx.TabIndex = 0;
            this.inventoryTxtBx.Text = resources.GetString("inventoryTxtBx.Text");
            // 
            // OrderPageInventory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 352);
            this.Controls.Add(this.inventoryTxtBx);
            this.MinimumSize = new System.Drawing.Size(330, 390);
            this.Name = "OrderPageInventory";
            this.Text = "Inventory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox inventoryTxtBx;
    }
}