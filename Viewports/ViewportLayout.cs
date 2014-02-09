using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Viewports
{
    public class ViewportLayout
    {
        Viewports Form;
        List<Porthole> PortholeList = new List<Porthole>();
        Porthole LastPorthole = null;

        public ViewportLayout(Viewports Form)
        {
            this.Form = Form;
        }

        public Porthole CreatePorthole()
        {
            Porthole Porthole = new Porthole(this.Form);

            this.PortholeList.Add(Porthole);

            Porthole.FocusBrowser();

            return Porthole;
        }

        public Porthole CreatePorthole(Panel Target)
        {
            Porthole Porthole = this.CreatePorthole();

            Porthole.AddTo(Target);

            return Porthole;
        }

        public Porthole SplitPorthole(Porthole Target, bool Horizontal)
        {
            Panel Container = Target.GetContainer();

            Target.RemoveFromContainer();

            // 

            SplitContainer Splitter = new ViewportSplitContainer();
            Splitter.Dock = DockStyle.Fill;
            Splitter.BorderStyle = BorderStyle.None;
            Splitter.SplitterWidth = 5;

            // 

            if (Horizontal)
            {
                Splitter.Orientation = Orientation.Horizontal;
            }
            else
            {
                Splitter.Orientation = Orientation.Vertical;
            }

            // Move existing porthole

            Panel PortholeContainer = new Panel();
            PortholeContainer.AutoScroll = true;
            PortholeContainer.AutoSize = true;
            PortholeContainer.Dock = DockStyle.Fill;

            Target.AddTo(PortholeContainer);

            Splitter.Panel1.Controls.Add(PortholeContainer);

            // Create new porthole

            PortholeContainer = new Panel();
            PortholeContainer.AutoScroll = true;
            PortholeContainer.AutoSize = true;
            PortholeContainer.Dock = DockStyle.Fill;

            Porthole Porthole = this.CreatePorthole(PortholeContainer);

            Splitter.Panel2.Controls.Add(PortholeContainer);

            // 

            Container.Controls.Add(Splitter);

            // 

            this.LastPorthole = Porthole;

            return Porthole;
        }
    }
}
