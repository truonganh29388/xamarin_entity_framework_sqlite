using Xamarin.Forms;
using TaskManager.ViewModels;
using TaskManager.Custom;

namespace TaskManager.Pages
{
    public class HomePage : ViewPage<HomeViewModel>
    {
        public HomePage()
        {
            Label header = new Label
            {
                Text = "StackLayout",
                FontSize = 50,
                FontAttributes = FontAttributes.Bold,
                HorizontalOptions = LayoutOptions.Center
            };

            var stackLayout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10),
                Children =
                {
                    new ListView
                    {
                        ItemsSource = ViewModel.Users,
                        ItemTemplate = new DataTemplate(typeof(CustomCell))
                    }
                }
            };

            // Build the page.
            Title = "StackLayout Demo";
            Content = new StackLayout
            {
                Children =
                {
                    header,
                    stackLayout
                }
            };
            
        }
    }
}
