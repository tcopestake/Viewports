namespace Viewports
{
    partial class MiniAddressBar
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
            this.AddressBar = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AddressBar
            // 
            this.AddressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressBar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressBar.Location = new System.Drawing.Point(12, 6);
            this.AddressBar.Name = "AddressBar";
            this.AddressBar.Size = new System.Drawing.Size(426, 23);
            this.AddressBar.TabIndex = 0;
            this.AddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressBar_KeyDown);
            this.AddressBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressBar_KeyPress);
            this.AddressBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddressBar_KeyUp);
            // 
            // MiniAddressBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 36);
            this.ControlBox = false;
            this.Controls.Add(this.AddressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiniAddressBar";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Deactivate += new System.EventHandler(this.OnBlur);
            this.Layout += new System.Windows.Forms.LayoutEventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddressBar;
    }
}