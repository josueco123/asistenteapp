using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

[assembly: Permission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "@PACKAGE_NAME@.permission.C2D_MESSAGE")]
[assembly: UsesPermission(Name = "com.google.android.c2dm.permission.RECEIVE")]

[assembly: UsesPermission(Name = "android.permission.GET_ACCOUNTS")]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.WAKE_LOCK")]

namespace AsistenteJudicialApp.Droid
{
    using Android.Support.V4.App;
    using Android.Util;
    using Gcm.Client;
    using WindowsAzure.Messaging;

    [BroadcastReceiver(Permission = Gcm.Client.Constants.PERMISSION_GCM_INTENTS)]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_MESSAGE }, Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_REGISTRATION_CALLBACK }, Categories = new string[] { "@PACKAGE_NAME@" })]
    [IntentFilter(new string[] { Gcm.Client.Constants.INTENT_FROM_GCM_LIBRARY_RETRY }, Categories = new string[] { "@PACKAGE_NAME@" })]
    public class MyBroadcastReceiver : GcmBroadcastReceiverBase<PushHandlerService>
    {
        public static string[] SENDER_IDS = new string[] { Droid.Constans.SenderID };

        public const string TAG = "MyBroadcastReceiver-GCM";
    }

    [Service]       
    public class PushHandlerService : GcmServiceBase
    {
        #region Attributes
        private NotificationHub Hub { get; set; }
        public static string RegistrationID { get; private set; }
        #endregion

        #region Methods
        public PushHandlerService() : base(Droid.Constans.SenderID)
        {
            Log.Info(MyBroadcastReceiver.TAG, "PushHandlerService() constructor");

        }

        protected override void OnMessage(Context context, Intent intent)
        {
            Log.Info(MyBroadcastReceiver.TAG, "GCM Message Received!");

            var msg = new StringBuilder();

            if (intent != null && intent.Extras != null)
            {
                foreach (var key in intent.Extras.KeySet())
                    msg.AppendLine(key + "=" + intent.Extras.Get(key).ToString());
            }

            var message = intent.Extras.GetString("message");
            var type = intent.Extras.GetString("Type");

            if (!string.IsNullOrEmpty(message))
            {
                var notification = intent.Extras.GetString("Notification");
                createNotification("Asistente Judicial", message);
            }
        }

        protected override bool OnRecoverableError(Context context, string errorId)
        {
            Log.Warn(MyBroadcastReceiver.TAG, "Recoverable Error: " + errorId);

            return base.OnRecoverableError(context, errorId);
        }

        protected override void OnError(Context context, string errorId)
        {
            Log.Error(MyBroadcastReceiver.TAG, "GCM Error: " + errorId);
        }

        protected override void OnRegistered(Context context, string registrationId)
        {
            Log.Verbose(MyBroadcastReceiver.TAG, "GCM Registered: " + registrationId);
            RegistrationID = registrationId;

            Hub = new NotificationHub(Droid.Constans.NotificationHubName, Droid.Constans.ListenConnectionString, context);

            try
            {
                Hub.UnregisterAll(registrationId);
            }
            catch (Exception ex)
            {
                Log.Error(MyBroadcastReceiver.TAG, ex.Message);
            }

            //tags
            var tags = new List<string>() { };

            string userId = App.Current.Properties["UserId"].ToString();
            string userEmail = App.Current.Properties["Email"].ToString();

            if (!String.IsNullOrEmpty(userId))
            {
                tags.Add("userId:" + userId);
            }

            if (!String.IsNullOrEmpty(userEmail))
            {
                tags.Add("userEmail:" + userEmail);
            }            

            try
            {
                var hubRegistration = Hub.Register(registrationId, tags.ToArray());
            }
            catch (Exception ex)
            {
                Log.Error(MyBroadcastReceiver.TAG, ex.Message);
            }
        }

        protected override void OnUnRegistered(Context context, string registrationId)
        {
            Log.Verbose(MyBroadcastReceiver.TAG, "GCM Unregistered: " + registrationId);

            createNotification("GSScore", "The device has been unregistered!");
        }

        void createNotification(string title, string desc)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);

            Random random = new Random();
            int pushCount = random.Next(9999 - 1000) + 1000; //for multiplepushnotificatio

            var notificationBuilder = new Notification.Builder(this)
                   //var notificationBuilder = new NotificationCompat.Builder(this)
                        .SetContentTitle(title)
                        .SetSmallIcon(Resource.Drawable.icn)
                        .SetContentText(desc)
                        .SetAutoCancel(true) 
                        //.SetSound(NotificationDefaults.Sound)
                        //.SetDefaults(NotificationDefaults.Vibrate)
                        .SetDefaults(NotificationDefaults.Sound | NotificationDefaults.Vibrate)                       
                        .SetContentIntent(pendingIntent);

            var notificationManager = NotificationManager.FromContext(this);

            notificationManager.Notify(pushCount, notificationBuilder.Build());
        }
        /*void createNotification(string title, string desc)
        {
            //Create notification
            var notificationManager = GetSystemService(Context.NotificationService) as NotificationManager;

            //Create an intent to show UI
            var uiIntent = new Intent(this, typeof(MainActivity));

            //Create the notification
            var notification = new Notification(Resource.Drawable.ic_launcher, title);
            
            //Auto-cancel will remove the notification once the user touches it
            notification.Flags = NotificationFlags.AutoCancel;
            
            //Set the notification info
            //we use the pending intent, passing our ui intent over, which will get called
            //when the notification is tapped.
            notification.SetLatestEventInfo(this, title, desc, PendingIntent.GetActivity(this, 0, uiIntent, 0));
            
            //Show the notification
            notificationManager.Notify(1, notification);
            dialogNotify(title, desc);
        }*/


        protected void dialogNotify(String title, String message)
        {
            var mainActivity = MainActivity.GetInstance();
            mainActivity.RunOnUiThread(() =>
            {
                AlertDialog.Builder dlg = new AlertDialog.Builder(mainActivity);
                AlertDialog alert = dlg.Create();
                alert.SetTitle(title);
                alert.SetButton("Aceptar", delegate
                {
                    alert.Dismiss();
                });
                alert.SetMessage(message);
                alert.Show();
            });
        }
        #endregion
    }
}