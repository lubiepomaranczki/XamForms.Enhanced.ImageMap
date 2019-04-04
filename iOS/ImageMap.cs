using UIKit;
using System;
using CoreGraphics;
using System.Drawing;
using System.Runtime.InteropServices;

namespace XamForms.Enhanced.ImageMap.iOS
{
    public sealed class ImageMap : UIView
    {
        private UIImage maskImage;
        private UIImage mapImage;

        private UIImageView maskImageView;
        private UIImageView mapImageView;

        public ImageMap()
        {
            InitializeControl();
        }

        public ImageMap(UIImage mapImage, UIImage maskImage) : this()
        {
            MapImage = mapImage;
            MaskImage = maskImage;
        }

        public UIImage MaskImage
        {
            get => maskImage;
            set
            {
                maskImage = value;
                maskImageView.Image = maskImage;
            }
        }

        public UIImage MapImage
        {
            get => mapImage;
            set
            {
                mapImage = value;
                mapImageView.Image = mapImage;
            }
        }

        public override UIViewContentMode ContentMode
        {
            get { return base.ContentMode; }
            set
            {
                base.ContentMode = value;
                mapImageView.ContentMode = value;
                maskImageView.ContentMode = value;
            }
        }

        public event EventHandler<ImageMapRegionSelected> OnAreaTapped;

        private void InitializeControl()
        {
            maskImageView = new UIImageView
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            Add(maskImageView);

            maskImageView.LeftAnchor.ConstraintEqualTo(LeftAnchor).Active = true;
            maskImageView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            maskImageView.RightAnchor.ConstraintEqualTo(RightAnchor).Active = true;
            maskImageView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;

            mapImageView = new UIImageView
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                UserInteractionEnabled = true
            };
            Add(mapImageView);

            mapImageView.LeftAnchor.ConstraintEqualTo(LeftAnchor).Active = true;
            mapImageView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            mapImageView.RightAnchor.ConstraintEqualTo(RightAnchor).Active = true;
            mapImageView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;

            mapImageView.AddGestureRecognizer(new UITapGestureRecognizer(HandleTap));
        }

        private void HandleTap(UITapGestureRecognizer tap)
        {
            if (tap == null)
            {
                throw new ArgumentNullException();
            }

            var tappedLocationPoint = tap.LocationInView(maskImageView);
            var resizedImage = ResizeImage(maskImage, mapImageView.Frame.Size);
            var color = GetPixelColor(new PointF((float)tappedLocationPoint.X, (float)tappedLocationPoint.Y), resizedImage);
            color.GetRGBA(out var red, out var green, out var blue, out var alpha);

            OnAreaTapped.Invoke(this, new ImageMapRegionSelected(color));
        }

        private UIColor GetPixelColor(PointF myPoint, UIImage myImage)
        {
            var rawData = new byte[4];
            var handle = GCHandle.Alloc(rawData);
            UIColor resultColor = null;

            try
            {
                using (var colorSpace = CGColorSpace.CreateDeviceRGB())
                {
                    using (var context = new CGBitmapContext(rawData, 1, 1, 8, 4, colorSpace, CGImageAlphaInfo.PremultipliedLast))
                    {
                        context.DrawImage(new RectangleF(-myPoint.X, (float)(myPoint.Y - myImage.Size.Height), (float)myImage.Size.Width, (float)myImage.Size.Height), myImage.CGImage);
                        float red = rawData[0] / 255.0f;
                        float green = rawData[1] / 255.0f;
                        float blue = rawData[2] / 255.0f;
                        float alpha = rawData[3] / 255.0f;
                        resultColor = UIColor.FromRGBA(red, green, blue, alpha);
                    }
                }
            }
            finally
            {
                handle.Free();
            }

            return resultColor;
        }

        private UIImage ResizeImage(UIImage image, CGSize targetSize)
        {
            UIGraphics.BeginImageContextWithOptions(targetSize, false, 1.0f);
            var context = UIGraphics.GetCurrentContext();
            mapImageView.Layer.RenderInContext(context);
            var newImage = UIGraphics.GetImageFromCurrentImageContext();
            UIGraphics.EndImageContext();

            return newImage;
        }
    }
}
