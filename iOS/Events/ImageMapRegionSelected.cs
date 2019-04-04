using System;
using UIKit;

namespace XamForms.Enhanced.ImageMap.iOS
{
    public class ImageMapRegionSelected : EventArgs
    {
        public ImageMapRegionSelected(UIColor color)
        {
            Color = color;
        }

        public UIColor Color { get; }
    }
}
