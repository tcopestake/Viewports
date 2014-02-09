using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viewports
{
    public partial class MiniAddressBar : Form
    {
        Viewports Window;

        /* */

        public MiniAddressBar(Viewports Window)
        {
            this.Window = Window;

            InitializeComponent();
        }

        public void HideBox()
        {
            this.AddressBar.Text = "";

            this.Hide();
        }

        /* */

        private void OnLoad(object sender, LayoutEventArgs e)
        {
            this.AddressBar.Focus();
        }

        private void OnBlur(object sender, EventArgs e)
        {
            this.HideBox();
        }

        /* */

        private void AddressBar_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String Address = this.AddressBar.Text;

                if (Address.Length == 0)
                {
                    Address = "http://www.google.co.uk/";
                }

                // Format URL

                Address = Address.Trim();

                if (!Address.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) && !Address.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
                {
                    Address = "http://" + Address;
                }

                // Navigate to URL

                this.Window.GoToAddress(Address);

                // Hide this form

                this.HideBox();

                // 

                e.Handled = true;
            }
        }

        private void AddressBar_KeyUp(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void AddressBar_KeyPress(Object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }
    }
}
