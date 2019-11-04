using TaskManager.Entities;
using Xamarin.Forms;

namespace TaskManager.Custom
{
   public class CustomCell:ViewCell
    {
        public CustomCell()
        {
            //instantiate each of our views
           // var image = new Image();
           // StackLayout cellWrapper = new StackLayout();
           // StackLayout horizontalLayout = new StackLayout();
            Label left = new Label();
            Label right = new Label();

            //set bindings
            left.SetBinding(Label.TextProperty, "FullName");
            right.SetBinding(Label.TextProperty, "UserName");

            //Set properties for desired design
            left.BackgroundColor = Color.FromHex("#eee");
            right.BackgroundColor = Color.FromHex("#44ed19");
            right.HorizontalOptions = LayoutOptions.EndAndExpand;
            left.TextColor = Color.FromHex("#f35e20");
            right.TextColor = Color.FromHex("503026");

            //add views to the view hierarchy
            View = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = LayoutOptions.StartAndExpand,
                Padding = new Thickness(15, 5, 5, 15),
                Children = {
                    right, left
                }
            };

        }
    }
}
