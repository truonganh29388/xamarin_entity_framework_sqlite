using Autofac;
using System;
using TaskManager.Helpers;
using TaskManager.IocContainer;
using TaskManager.Services;
using TaskManager.ViewModels;
using Xamarin.Forms;

namespace TaskManager.Pages
{
    public class LoginPage : ViewPage<LoginViewModel>
    {
        private readonly IOtpService _optService;
        public LoginPage()
        {
            using(var scope = AppContainer.Container.BeginLifetimeScope())
            {
                _optService = AppContainer.Container.Resolve<IOtpService>();
            }

            // Build the page.
            Title = "Login";
            Content = new StackLayout
            {
                Children =
                {
                    BuilContentChildren()
                }
            };
        }

        private StackLayout BuilContentChildren()
        {
            // var fontFamily = (string)((OnPlatform<string>)Application.Current.Resources["MaterialFontFamily"]).Platforms.FirstOrDefault(p => p.Platform[0] == Device.RuntimePlatform)?.Value; ;
            var phoneEntry = FormControlHelper.CreateStandardPhoneEntry("Phone Number");
            phoneEntry.SetBinding(Entry.TextProperty, nameof(ViewModel.PhoneNumber));

            var submitButton = FormControlHelper.CreateStandardButton("Submit");
            submitButton.Clicked += SendOtp;

            var stackLayout = new StackLayout
            {
                Spacing = 0,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Padding = new Thickness(10),
                Children =
                {
                    phoneEntry, submitButton
                }
            };

            return stackLayout;
        }

        private void SendOtp(object sender, EventArgs args)
        {
            var phone = ViewModel.PhoneNumber;
            _optService.SendOtp(phone);
        }
    }
}
