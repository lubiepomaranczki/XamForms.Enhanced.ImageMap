using System;

namespace XamForms.Enhanced.ImageMap.iOS
{
    public class ImageMapRegionSelected : EventArgs
    {
        public ImageMapRegionSelected(object region)
        {
            Region = region;
        }

        public object Region { get; }
    }
}
