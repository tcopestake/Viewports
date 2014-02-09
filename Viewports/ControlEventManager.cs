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
    public delegate void ControlEventListener(Object source, ControlEventArgs e);

    public class ControlEventArgs : EventArgs
    {
        bool ControlIsPressed;

        public ControlEventArgs(bool ControlIsPressed)
        {
            this.ControlIsPressed = ControlIsPressed;
        }

        public bool ControlPressed()
        {
            return ControlIsPressed;
        }
    }

    public class ControlEventManager
    {
        public event ControlEventListener ControlEvent;

        public void ControlStatus(bool ControlPressed)
        {
            ControlEvent(this, new ControlEventArgs(ControlPressed));
        }

        public void RegisterEventListener(ControlEventListener EventListener)
        {
            ControlEvent += EventListener;
        }
    }
}
