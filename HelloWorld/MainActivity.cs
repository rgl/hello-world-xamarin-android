using Android.App;
using Android.OS;
using Android.Widget;

namespace HelloWorld
{
    [Activity(
        Label = "Hello World",
        MainLauncher = true,
        Icon = "@drawable/icon",
        Theme = "@android:style/Theme.DeviceDefault.NoActionBar")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var helloButton = FindViewById<Button>(Resource.Id.HelloButton);

            helloButton.Click += async (sender, args) =>
            {
                var ip = await HttpBin.GetIp();

                var d = new AlertDialog.Builder(this);
                d.SetTitle("Hello?");
                d.SetMessage($"Hello World!\n\nyour ip is {ip}");
                d.SetPositiveButton("Dismiss", (s, a) => { });
                d.Show();
            };
        }
    }
}
