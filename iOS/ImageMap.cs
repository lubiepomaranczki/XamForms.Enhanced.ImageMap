using UIKit;

namespace XamForms.Enhanced.ImageMap.iOS
{
    public sealed class ImageMap : UIView
    {
        private UIImage maskImage;
        private UIImage image;

        private UIImageView maskImageView;
        private UIImageView imageView;

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
                maskImageView.Image = image;
            }
        }
        public UIImage MapImage
        {
            get => image;
            set
            {
                image = value;
                imageView.Image = image;
            }
        }

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

            imageView = new UIImageView
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            Add(imageView);

            imageView.LeftAnchor.ConstraintEqualTo(LeftAnchor).Active = true;
            imageView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            imageView.RightAnchor.ConstraintEqualTo(RightAnchor).Active = true;
            imageView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;
        }
    }
}
