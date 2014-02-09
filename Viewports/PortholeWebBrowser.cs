using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Viewports
{
    class PortholeWebBrowser : WebBrowser
    {
        Porthole Porthole;

        bool ControlPressed = false;

        public PortholeWebBrowser(Porthole Porthole)
        {
            this.Porthole = Porthole;
        }

        // 

        public override bool PreProcessMessage(ref Message msg)
        {
            if (msg.Msg == 0x101 || msg.Msg == 0x100)
            {
                bool ControlPressedNow = (ModifierKeys == Keys.Control);


                if (ControlPressed != ControlPressedNow)
                {
                    ControlPressed = ControlPressedNow;

                    this.Porthole.SetControlPressed(ControlPressed);
                }
            }

            return base.PreProcessMessage(ref msg);
        }
    }
}
