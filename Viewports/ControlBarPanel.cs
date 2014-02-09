using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Viewports
{
    class ControlBarPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Draw separator line

            Graphics g = e.Graphics;
            g.DrawLine(Pens.DarkGray, new Point(0, this.Height - 1), new Point(this.Width, this.Height - 1));
        }
    }
}
