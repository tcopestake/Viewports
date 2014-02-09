using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace Viewports
{
    class PictureButton : Panel
    {
        enum States
        {
            Disabled,
            Enabled,
            Hover,
            Pressed
        };

        // 

        bool Pressed = false;
        bool Hovering = false;
        bool ButtonEnabled = true;

        Image DisabledImage;
        Image EnabledImage;
        Image DisabledHoverImage;
        Image EnabledHoverImage;
        Image PressedImage;

        //

        public PictureButton(Image DisabledImage, Image EnabledImage, Image DisabledHoverImage, Image EnabledHoverImage, Image PressedImage)
        {
            this.DisabledImage = DisabledImage;
            this.EnabledImage = EnabledImage;
            this.DisabledHoverImage = DisabledHoverImage;
            this.EnabledHoverImage = EnabledHoverImage;
            this.PressedImage = PressedImage;

            if (this.Enabled)
            {
                this.BackgroundImage = this.EnabledImage;
            }
            else
            {
                this.BackgroundImage = this.DisabledImage;
            }
        }

        public void Enable()
        {
            this.ButtonEnabled = true;

            this.UpdateImage();
        }

        public void Disable()
        {
            this.ButtonEnabled = false;

            this.UpdateImage();
        }

        /* */

        protected void UpdateImage()
        {
            if (this.Pressed)
            {
                this.BackgroundImage = this.PressedImage;
            }
            else if (this.ButtonEnabled)
            {
                this.BackgroundImage = this.Hovering ? this.EnabledHoverImage : this.EnabledImage;
            }
            else
            {
                this.BackgroundImage = this.Hovering ? this.DisabledHoverImage : this.DisabledImage;
            }
        }

        /* */

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);

            // 

            this.Hovering = true;

            this.UpdateImage();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);

            // 

            this.Hovering = false;

            this.UpdateImage();
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            // 

            if (this.ButtonEnabled)
            {
                this.Pressed = true;
                this.UpdateImage();
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);

            // 

            if (this.Pressed)
            {
                this.Pressed = false;
                this.UpdateImage();
            }
        }
    }
}
