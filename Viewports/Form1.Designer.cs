namespace Viewports
{
    partial class Viewports
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
            this.NavigateWindows = new System.Windows.Forms.Button();
            this.NavigateTabs = new System.Windows.Forms.Button();
            this.NewTabTop = new System.Windows.Forms.Button();
            this.NewTabBottom = new System.Windows.Forms.Button();
            this.ViewportContainer = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // AddressBar
            // 
            this.AddressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressBar.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressBar.Location = new System.Drawing.Point(12, 12);
            this.AddressBar.Name = "AddressBar";
            this.AddressBar.Size = new System.Drawing.Size(929, 23);
            this.AddressBar.TabIndex = 0;
            this.AddressBar.TextChanged += new System.EventHandler(this.AddressBar_TextChanged);
            this.AddressBar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddressBar_KeyDown);
            this.AddressBar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AddressBar_KeyPress);
            this.AddressBar.KeyUp += new System.Windows.Forms.KeyEventHandler(this.AddressBar_KeyUp);
            // 
            // NavigateWindows
            // 
            this.NavigateWindows.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.NavigateWindows.Location = new System.Drawing.Point(2, 41);
            this.NavigateWindows.Name = "NavigateWindows";
            this.NavigateWindows.Size = new System.Drawing.Size(21, 458);
            this.NavigateWindows.TabIndex = 1;
            this.NavigateWindows.UseVisualStyleBackColor = true;
            this.NavigateWindows.Click += new System.EventHandler(this.button1_Click);
            // 
            // NavigateTabs
            // 
            this.NavigateTabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NavigateTabs.Location = new System.Drawing.Point(931, 41);
            this.NavigateTabs.Name = "NavigateTabs";
            this.NavigateTabs.Size = new System.Drawing.Size(21, 458);
            this.NavigateTabs.TabIndex = 2;
            this.NavigateTabs.UseVisualStyleBackColor = true;
            // 
            // NewTabTop
            // 
            this.NewTabTop.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewTabTop.Location = new System.Drawing.Point(29, 41);
            this.NewTabTop.Name = "NewTabTop";
            this.NewTabTop.Size = new System.Drawing.Size(896, 25);
            this.NewTabTop.TabIndex = 3;
            this.NewTabTop.UseVisualStyleBackColor = true;
            // 
            // NewTabBottom
            // 
            this.NewTabBottom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NewTabBottom.Location = new System.Drawing.Point(29, 474);
            this.NewTabBottom.Name = "NewTabBottom";
            this.NewTabBottom.Size = new System.Drawing.Size(896, 25);
            this.NewTabBottom.TabIndex = 4;
            this.NewTabBottom.UseVisualStyleBackColor = true;
            // 
            // ViewportContainer
            // 
            this.ViewportContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ViewportContainer.Location = new System.Drawing.Point(29, 72);
            this.ViewportContainer.Name = "ViewportContainer";
            this.ViewportContainer.Size = new System.Drawing.Size(896, 396);
            this.ViewportContainer.TabIndex = 5;
            // 
            // Viewports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 501);
            this.Controls.Add(this.ViewportContainer);
            this.Controls.Add(this.NewTabBottom);
            this.Controls.Add(this.NewTabTop);
            this.Controls.Add(this.NavigateTabs);
            this.Controls.Add(this.NavigateWindows);
            this.Controls.Add(this.AddressBar);
            this.Name = "Viewports";
            this.Text = "Viewports";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeEnd += new System.EventHandler(this.Form1_ResizeEnd);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox AddressBar;
        private System.Windows.Forms.Button NavigateWindows;
        private System.Windows.Forms.Button NavigateTabs;
        private System.Windows.Forms.Button NewTabTop;
        private System.Windows.Forms.Button NewTabBottom;
        private System.Windows.Forms.Panel ViewportContainer;
    }
}

