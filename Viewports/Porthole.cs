using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.ComponentModel;

namespace Viewports
{
    public class Porthole
    {
        Viewports Form;

        // 

        bool CanStop;
        bool CanReload;
        bool ControlBarHidden = false;
        Panel ControlBar;
        TextBox AddressBar;
        PictureButton BackButton;
        PictureButton ForwardButton;
        PictureButton ReloadButton;
        PictureButton StopButton;

        // 

        Panel ContainerPanel = null;
        SplitterPanel ContainerSplitter = null;
        Panel PortholePanel;
        PortholeBrowserPanel PortholeBrowserPanel;

        PortholeWebBrowser PortholeBrowser;
        String DocumentTitle = "";

        String SplashHTML = "<html><head><title>No document</title><style>body { padding: 30px; font: 16px Verdana, Arial; } h1 { color: #7c95b3; } p { color: #777; }</style></head><body><h1>Viewports</h1><ul><li>Hold CTRL</li><li>Right click this window</li><li>Choose 'navigate to...'</li><li>Type a URL and press the enter key</li></ul></body></html>";

        // 

        public Porthole(Viewports Form)
        {
            this.Form = Form;

            // Create container panel

            this.PortholePanel = new Panel();
            this.PortholePanel.AutoScroll = true;
            this.PortholePanel.AutoSize = true;
            this.PortholePanel.Dock = DockStyle.Fill;

            /* Create control bar */

            this.ControlBar = new ControlBarPanel();
            this.ControlBar.Location = new Point(0, 0);
            this.ControlBar.Height = 36;
            this.ControlBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.ControlBar.Dock = DockStyle.Top;

            // Add address bar

            this.AddressBar = new TextBox();
            this.AddressBar.Location = new Point(95, 5);
            this.AddressBar.Height = 25;
            this.AddressBar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            this.AddressBar.Font = new Font("Verdana", 10);

            this.AddressBar.KeyDown += new KeyEventHandler(this.AddressBar_KeyDown);
            this.AddressBar.KeyUp += new KeyEventHandler(this.AddressBar_KeyUp);
            this.AddressBar.KeyPress += new KeyPressEventHandler(AddressBar_KeyPress);

            this.ControlBar.Controls.Add(this.AddressBar);

            // Create buttons.

            this.BackButton = new PictureButton(
                global::Viewports.Properties.Resources.BackDisabled,
                global::Viewports.Properties.Resources.BackEnabled,
                global::Viewports.Properties.Resources.BackDisabledHover,
                global::Viewports.Properties.Resources.BackEnabledHover,
                global::Viewports.Properties.Resources.BackPressed
            );

            this.BackButton.Location = new Point(5, 5);
            this.BackButton.Size = new Size(30, 23);
            this.BackButton.Dock = DockStyle.None;

            this.BackButton.Disable();

            this.BackButton.Click += new EventHandler(this.NavigatePortholeBack);

            // 

            this.ForwardButton = new PictureButton(
                global::Viewports.Properties.Resources.ForwardDisabled,
                global::Viewports.Properties.Resources.ForwardEnabled,
                global::Viewports.Properties.Resources.ForwardDisabledHover,
                global::Viewports.Properties.Resources.ForwardEnabledHover,
                global::Viewports.Properties.Resources.ForwardPressed
            );

            this.ForwardButton.Location = new Point(35, 5);
            this.ForwardButton.Size = new Size(30, 23);
            this.ForwardButton.Dock = DockStyle.None;

            this.ForwardButton.Disable();

            this.ForwardButton.Click += new EventHandler(this.NavigatePortholeForward);

            // 

            this.ReloadButton = new PictureButton(
                global::Viewports.Properties.Resources.ReloadDisabled,
                global::Viewports.Properties.Resources.ReloadEnabled,
                global::Viewports.Properties.Resources.ReloadDisabledHover,
                global::Viewports.Properties.Resources.ReloadEnabledHover,
                global::Viewports.Properties.Resources.ReloadPressed
            );

            this.ReloadButton.Location = new Point(65, 5);
            this.ReloadButton.Size = new Size(30, 23);
            this.ReloadButton.Dock = DockStyle.None;

            this.ReloadButton.Disable();

            this.ReloadButton.Click += new EventHandler(this.ReloadPorthole);

            // 

            this.StopButton = new PictureButton(
                global::Viewports.Properties.Resources.StopDisabled,
                global::Viewports.Properties.Resources.StopEnabled,
                global::Viewports.Properties.Resources.StopDisabledHover,
                global::Viewports.Properties.Resources.StopEnabledHover,
                global::Viewports.Properties.Resources.StopPressed
            );

            this.StopButton.Location = new Point(65, 5);
            this.StopButton.Size = new Size(30, 23);
            this.StopButton.Dock = DockStyle.None;

            this.StopButton.Disable();

            this.StopButton.Click += new EventHandler(this.StopPorthole);

            // Add buttons to control bar

            this.ControlBar.Controls.Add(this.BackButton);
            this.ControlBar.Controls.Add(this.ForwardButton);
            this.ControlBar.Controls.Add(this.ReloadButton);
            //this.ButtonPanel.Controls.Add(StopButton);

            /*
             * Create browser panel (for the border; adding the border to the 
             * browser control itself causes issues with the scrollbars
             * 
             */

            this.PortholeBrowserPanel = new PortholeBrowserPanel();
            this.PortholeBrowserPanel.AutoScroll = true;
            this.PortholeBrowserPanel.AutoSize = true;
            this.PortholeBrowserPanel.Dock = DockStyle.Fill;

            // Create browser

            this.PortholeBrowser = new PortholeWebBrowser(this);
            this.PortholeBrowser.Dock = DockStyle.Fill;

            // Attach browser event handlers

            this.PortholeBrowser.NewWindow += new CancelEventHandler(this.NewWindow);

            this.PortholeBrowser.DocumentTitleChanged += new EventHandler(this.DocumentTitleChanged);

            this.PortholeBrowser.PreviewKeyDown += new PreviewKeyDownEventHandler(this.PreviewKeyDown);
            this.PortholeBrowser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(this.DocumentLoaded);

            this.PortholeBrowser.Navigated += new WebBrowserNavigatedEventHandler(this.BrowserNavigated);

            this.PortholeBrowser.CanGoBackChanged += new EventHandler(this.CanGoBackChanged);
            this.PortholeBrowser.CanGoForwardChanged += new EventHandler(this.CanGoForwardChanged);

            // Set splash screen

            if (this.PortholeBrowser.Document != null)
            {
                this.PortholeBrowser.Document.Write(string.Empty);
            }

            this.PortholeBrowser.DocumentText = this.SplashHTML;

            // Add controls

            this.PortholeBrowserPanel.Controls.Add(this.PortholeBrowser);

            this.PortholePanel.Controls.Add(this.PortholeBrowserPanel);
            this.PortholePanel.Controls.Add(this.ControlBar);

            // Set Z index

            this.PortholePanel.Controls.SetChildIndex(this.ControlBar, 2);
            this.PortholePanel.Controls.SetChildIndex(this.PortholeBrowserPanel, 1);

        }

        public void AddTo(Panel Target)
        {
            this.ContainerPanel = Target;

            Target.Controls.Add(this.PortholePanel);
        }

        public void RemoveFromContainer()
        {
            if (this.ContainerPanel != null)
            {
                this.ContainerPanel.Controls.Remove(this.PortholePanel);
                this.ContainerPanel = null;
            }
        }

        //


        public void FocusBrowser()
        {
            this.PortholeBrowser.Focus();
        }

        // 

        public void NavigateTo(String Address)
        {
            this.AddressBar.Text = Address;

            this.PortholeBrowser.Navigate(Address);
        }

        public String GetAddress()
        {
            return this.AddressBar.Text;
        }

        // 

        public Panel GetContainer()
        {
            return this.ContainerPanel;
        }

        public Panel GetPortholePanel()
        {
            return this.PortholePanel;
        }

        public PortholeBrowserPanel GetPortholeBrowserPanel()
        {
            return this.PortholeBrowserPanel;
        }

        // 

        public void EnableMenu()
        {
            this.PortholeBrowser.IsWebBrowserContextMenuEnabled = true;
        }

        public void DisableMenu()
        {
            this.PortholeBrowser.IsWebBrowserContextMenuEnabled = false;
        }

        // 

        public void EnableScrollbars()
        {
            this.PortholeBrowser.ScrollBarsEnabled = true;
        }

        public void DisableScrollbars()
        {
            this.PortholeBrowser.ScrollBarsEnabled = false;
        }

        // 

        public bool CanGoBack()
        {
            return (this.PortholeBrowser.CanGoBack);
        }

        public bool CanGoForward()
        {
            return (this.PortholeBrowser.CanGoForward);
        }

        //

        public void GoBack()
        {
            this.PortholeBrowser.GoBack();
        }

        public void GoForward()
        {
            this.PortholeBrowser.GoForward();
        }

        public void Stop()
        {
            this.PortholeBrowser.Stop();
        }

        public void Reload()
        {
            this.PortholeBrowser.Refresh();
        }

        /* */

        public void ShowControlBar()
        {
            if (this.ControlBarHidden)
            {
                this.PortholePanel.Controls.Add(this.ControlBar);

                this.PortholePanel.Controls.SetChildIndex(this.ControlBar, 2);
                this.PortholePanel.Controls.SetChildIndex(this.PortholeBrowserPanel, 1);

                ControlBarHidden = false;
            }
        }

        public void HideControlBar()
        {
            if (!this.ControlBarHidden)
            {
                this.PortholePanel.Controls.Remove(this.ControlBar);

                ControlBarHidden = true;
            }
        }

        // 

        public void ShowReloadButton()
        {
            this.CanStop = false;
            this.CanReload = true;

            // 

            this.ReloadButton.Enable();

            this.ControlBar.Controls.Remove(this.StopButton);
            this.ControlBar.Controls.Add(this.ReloadButton);
        }

        public void ShowStopButton()
        {
            this.CanReload = false;
            this.CanStop = true;

            // 

            this.StopButton.Enable();

            this.ControlBar.Controls.Remove(this.ReloadButton);
            this.ControlBar.Controls.Add(this.StopButton);
        }

        //

        public String GetDocumentTitle()
        {
            return this.DocumentTitle;
        }

        //

        public void SetControlPressed(bool IsPressed)
        {
            if (IsPressed)
            {
                this.ShowControlBar();
            }
            else
            {
                this.HideControlBar();
            }
        }

        //

        private void ReloadPorthole(object sender, EventArgs e)
        {
            if (this.CanReload)
            {
                this.Reload();
            }
        }

        private void StopPorthole(object sender, EventArgs e)
        {
            if (this.CanStop)
            {
                this.Stop();
            }
        }

        private void NavigatePortholeBack(object sender, EventArgs e)
        {
            this.GoBack();
        }

        private void NavigatePortholeForward(object sender, EventArgs e)
        {
            this.GoForward();
        }

        /* */

        private void NewWindow(Object sender, CancelEventArgs e)
        {
            e.Cancel = true;
        }

        private void DocumentTitleChanged(object sender, EventArgs e)
        {
            this.DocumentTitle = this.PortholeBrowser.DocumentTitle;

            this.Form.UpdatePortholeTitle(this);
        }

        private void PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

        }

        private void DocumentLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            /* Attach event handlers */

            this.PortholeBrowser.Document.Body.MouseOver += new HtmlElementEventHandler(this.BrowserMouseOver);

            this.PortholeBrowser.Document.Body.MouseDown += new HtmlElementEventHandler(this.BrowserMouseClick);

            /* */

            this.ShowReloadButton();
        }

        //

        private void UpdateButtons()
        {
            if (this.PortholeBrowser.CanGoBack)
            {
                this.BackButton.Enable();
            }
            else
            {
                this.BackButton.Disable();
            }

            if (this.PortholeBrowser.CanGoForward)
            {
                this.ForwardButton.Enable();
            }
            else
            {
                this.ForwardButton.Disable();
            }
        }

        /* Browser events */

        private void BrowserNavigated(Object sender, WebBrowserNavigatedEventArgs e)
        {
            this.ShowStopButton();

            this.AddressBar.Text = this.PortholeBrowser.Url.ToString();

            if (this.PortholeBrowser.Focused)
            {
                this.Form.SetAddress(this.AddressBar.Text);
            }
        }

        private void CanGoBackChanged(Object sender, EventArgs e)
        {
            this.UpdateButtons();
        }

        private void CanGoForwardChanged(Object sender, EventArgs e)
        {
            this.UpdateButtons();
        }

        /* Mouse events */

        private void BrowserMouseClick(object sender, HtmlElementEventArgs e)
        {
            if (e.MouseButtonsPressed == MouseButtons.Right)
            {
                // Hide IE's normal context menu if CTRL is pressed

                if ((Control.ModifierKeys & Keys.Control) != 0)
                {
                    this.PortholeBrowser.IsWebBrowserContextMenuEnabled = false;

                    this.Form.ShowContextMenu(e.MousePosition);
                }
                else
                {
                    this.PortholeBrowser.IsWebBrowserContextMenuEnabled = true;
                }
            }
            else
            {
            }
        }

        private void BrowserMouseOver(object sender, HtmlElementEventArgs e)
        {
            this.Form.SetPortholeFocus(this);
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
                else if (!Address.StartsWith("about:", StringComparison.InvariantCultureIgnoreCase))
                {
                    // Format URL

                    Address = Address.Trim();

                    if (!Address.StartsWith("http://", StringComparison.InvariantCultureIgnoreCase) && !Address.StartsWith("https://", StringComparison.InvariantCultureIgnoreCase))
                    {
                        Address = "http://" + Address;
                    }

                    this.AddressBar.Text = Address;

                    // Navigate to URL

                    this.PortholeBrowser.Navigate(Address);
                }

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
