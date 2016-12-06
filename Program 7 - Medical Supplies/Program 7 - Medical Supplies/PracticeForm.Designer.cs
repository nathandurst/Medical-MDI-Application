namespace Program_7___Medical_Supplies
{
    partial class PracticeForm
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
            this.inventory = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // inventory
            // 
            this.inventory.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inventory.FormattingEnabled = true;
            this.inventory.ItemHeight = 16;
            this.inventory.Location = new System.Drawing.Point(0, 97);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(515, 308);
            this.inventory.TabIndex = 0;
            // 
            // PracticeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 405);
            this.Controls.Add(this.inventory);
            this.Name = "PracticeForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox inventory;

    }
}