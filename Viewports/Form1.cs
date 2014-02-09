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
    public partial class Viewports : Form
    {
        Form NavigationInput;
        ContextMenu ContexMenu;
        Porthole Porthole = null;
        ViewportLayout ViewportLayout;
        ControlEventManager ControlEventManager = new ControlEventManager();

        /* */

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Alt | Keys.F))
            {

                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        /* */

        public Viewports()
        {
            InitializeComponent();
        }

        public void UpdatePortholeTitle()
        {
            String Title = this.Porthole.GetDocumentTitle();

            if (Title.Length > 0)
            {
                this.Text = Title;
            }
            else
            {
                this.Text = "Viewports";
            }
        }

        public void UpdatePortholeTitle(Porthole Porthole)
        {
            if (this.Porthole != null && Object.ReferenceEquals(this.Porthole, Porthole))
            {
                this.UpdatePortholeTitle();
            }
        }

        public void RegisterControlListener(ControlEventListener EventListener)
        {
            this.ControlEventManager.RegisterEventListener(EventListener);
        }

        public void SetPortholeFocus(Porthole Porthole)
        {
            if (this.Porthole == null || !Object.ReferenceEquals(this.Porthole, Porthole))
            {
                this.Porthole = Porthole;

                // 

                this.Porthole.FocusBrowser();

                this.AddressBar.Text = this.Porthole.GetAddress();
            }
        }

        public void ShowContextMenu(Point Point)
        {
            this.ContexMenu.Show(this, Cursor.Position);
        }

        // 

        public void SetAddress(String Address)
        {
            this.AddressBar.Text = Address;
        }

        //

        public void NotifyNavigationChange(Porthole Porthole)
        {
            if (this.Porthole != null && Object.ReferenceEquals(this.Porthole, Porthole))
            {

            }
        }

        //

        public void GoToAddress(String Address)
        {
            this.AddressBar.Text = Address;

            this.LoadPage();
        }

        /* */

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ViewportLayout = new ViewportLayout(this);

            this.ContexMenu = new ContextMenu();

            this.ContexMenu.MenuItems.Add("Navigate to... ", new EventHandler(this.NavigateTo));
            this.ContexMenu.MenuItems.Add("Split vertically ", new EventHandler(this.SplitVertically));
            this.ContexMenu.MenuItems.Add("Split horizontally ", new EventHandler(this.SplitHorizontally));

            /* Create navigation input */

            this.NavigationInput = new MiniAddressBar(this);
            this.NavigationInput.Location = new Point(200, 200);

            //this.NavigationInput.Show();

            // 

        }

        /* */

        private void LoadPage()
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

            this.AddressBar.Text = Address;

            // Navigate to URL

            if (Porthole == null)
            {
                this.Porthole = this.ViewportLayout.CreatePorthole(this.ViewportContainer);
            }

            this.Porthole.NavigateTo(this.AddressBar.Text);
        }

        /* */

        private void NavigateTo(object sender, EventArgs e)
        {
            this.NavigationInput.Show();
        }

        private void SplitVertically(object sender, EventArgs e)
        {
            this.ViewportLayout.SplitPorthole(this.Porthole, false);
        }

        private void SplitHorizontally(object sender, EventArgs e)
        {
            this.ViewportLayout.SplitPorthole(this.Porthole, true);
        }
        
        private void Form1_ResizeEnd(Object sender, EventArgs e)
        {

        }

        private void Form1_KeyDown(Object sender, KeyEventArgs e)
        {

        }

        private void AddressBar_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddressBar_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoadPage();

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

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
