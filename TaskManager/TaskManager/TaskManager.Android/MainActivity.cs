
using Android.App;
using Android.Content.PM;
using Android.OS;
using Firebase;

namespace TaskManager.Droid
{
    [Activity(Label = "TaskManager", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        internal static Activity CurrentActivityRef { get; private set; }

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            global::Xamarin.Forms.Forms.Init(this, bundle);
            CurrentActivityRef = this;
            var builder = new FirebaseOptions.Builder();
            builder.SetApiKey("AIzaSyAaDvgA60S659P6DDZoAXx_HxEnQGwHw-8");
            builder.SetProjectId("task-manager-99e87");
            builder.SetStorageBucket("task-manager-99e87.appspot.com");
            builder.SetApplicationId("1:358089600915:android:01c3cfbae105ed8331c266");
            var options = builder.Build();
            FirebaseApp.InitializeApp(this, options);
            LoadApplication(new App(new Setup()));
        }
    }
}