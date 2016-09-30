using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Xamarin.Forms.Platform.Android;

namespace STG_RestaurantBuzzer.Droid
{
    [Activity(Label = "STG_RestaurantBuzzer", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        private static readonly int ButtonClickNotificationId = 1000;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            var app = new App();
            app.TableReady += App_TableReady;

            LoadApplication(app);
        }

        private void App_TableReady()
        {
            var notification = new Notification.Builder(this)
                .SetAutoCancel(true)
                .SetContentTitle("Time to eat!")
                .SetContentText("Your table is ready! Please check in at the front desk to be seated.")
                .SetSmallIcon(Icon.CreateWithResource(Application.Context, Resource.Drawable.icon))
                .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)
                .SetPriority((int) NotificationPriority.High)
                .Build();

            ((NotificationManager) GetSystemService(NotificationService)).Notify(ButtonClickNotificationId, notification);
        }
    }
}

