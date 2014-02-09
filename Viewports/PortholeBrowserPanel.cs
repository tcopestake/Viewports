using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Viewports
{
    public class PortholeBrowserPanel : Panel
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams Params = base.CreateParams;

                Params.ExStyle |= 0x200;

                return Params;
            }
        }
    }
}
