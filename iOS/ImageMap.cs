using UIKit;

namespace XamForms.Enhanced.ImageMap.iOS
{
    public sealed class ImageMap : UIView
    {
        private UIImage maskImage;
        private UIImage image;

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
                maskImageView.Image = image;
            }
        }

        public UIImage MapImage
        {
            get => image;
            set
            {
                image = value;
                mapImageView.Image = image;
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

            mapImageView = new UIImageView
            {
                TranslatesAutoresizingMaskIntoConstraints = false
            };
            Add(mapImageView);

            mapImageView.LeftAnchor.ConstraintEqualTo(LeftAnchor).Active = true;
            mapImageView.TopAnchor.ConstraintEqualTo(TopAnchor).Active = true;
            mapImageView.RightAnchor.ConstraintEqualTo(RightAnchor).Active = true;
            mapImageView.BottomAnchor.ConstraintEqualTo(BottomAnchor).Active = true;
        }
    }
}
