using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Viewports
{
    public class ViewportSplitContainer : SplitContainer
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(33, 253, 33, 0)), Orientation == Orientation.Horizontal ? new Rectangle(0, SplitterDistance, Width, SplitterWidth) : new Rectangle(SplitterDistance, 0, SplitterWidth, Height));
        }
    }
}
