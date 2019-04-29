using System;
using UIKit;

namespace XamForms.Enhanced.ImageMap.iOS
{
    public class ImageMapViewModel
    {
        public UIImage MaskImage { get; set; }
        public UIImage MapImage { get; set; }
        public UIViewContentMode ContentMode { get; set; }
    }
}