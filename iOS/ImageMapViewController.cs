using UIKit;

namespace XamForms.Enhanced.ImageMap.iOS
{
    public class ImageMapViewController : UIViewController
    {
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
            };
            Add(imageMap);

            imageMap.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
            imageMap.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
            imageMap.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
            imageMap.BottomAnchor.ConstraintEqualTo(View.CenterYAnchor).Active = true;
        }
    }
}