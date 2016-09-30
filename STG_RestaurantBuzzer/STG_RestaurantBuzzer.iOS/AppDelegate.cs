using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace STG_RestaurantBuzzer.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            var formsApp = new App();
            formsApp.TableReady += FormsApp_TableReady;

            LoadApplication(formsApp);

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Sound, null);

                app.RegisterUserNotificationSettings(notificationSettings);
            }

            if (options != null && options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
            {
                var localNotification =
                    options[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;

                if (localNotification != null)
                {
                    ShowNotification(localNotification);
                }
            }

            return base.FinishedLaunching(app, options);
        }

        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            ShowNotification(notification);
        }

        private void ShowNotification(UILocalNotification notification)
        {
            var okayAlertController = UIAlertController.Create(notification.AlertAction, notification.AlertBody,
                UIAlertControllerStyle.Alert);
            okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));

            Window.RootViewController.PresentViewController(okayAlertController, true, null);
        }

        private void FormsApp_TableReady()
        {
            var notification = new UILocalNotification
            {
                FireDate = NSDate.Now, // dangit.
                AlertAction = "OK",
                AlertBody = "Your table is ready! Please check in at the front desk to be seated.",
                SoundName = UILocalNotification.DefaultSoundName
            };

            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}
