using UIKit;
using System.Collections.Generic;

namespace XamForms.Enhanced.ImageMap.iOS
{
    public class ImageMapViewController : UIViewController
    {
        private UIView controlBox;

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            InitializeUI();
        }

        private void InitializeUI()
        {
            View.BackgroundColor = UIColor.Purple;

            var imageMap = new ImageMap
            {
                TranslatesAutoresizingMaskIntoConstraints = false,
                MapImage = UIImage.FromBundle("p2_ship_default"),
                MaskImage = UIImage.FromBundle("p2_ship_mask"),
                ContentMode = UIViewContentMode.ScaleAspectFit,
                Areas = new List<ImageMapArea> { new ImageMapArea(UIColor.FromRGBA(255, 38, 0, 255), "test") }
            };
            Add(imageMap);

            imageMap.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            imageMap.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            imageMap.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
            imageMap.BottomAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
            imageMap.OnAreaTapped += ImageMap_OnAreaTapped;

            controlBox = new UIView { TranslatesAutoresizingMaskIntoConstraints = false };
            Add(controlBox);

            controlBox.TopAnchor.ConstraintEqualTo(imageMap.BottomAnchor, 16).Active = true;
            controlBox.CenterXAnchor.ConstraintEqualTo(View.CenterXAnchor).Active = true;
            controlBox.WidthAnchor.ConstraintEqualTo(32).Active = true;
            controlBox.HeightAnchor.ConstraintEqualTo(32).Active = true;
        }

        private void ImageMap_OnAreaTapped(object sender, ImageMapRegionSelected e)
        {
            //controlBox.BackgroundColor = e.Color;
        }
    }
}