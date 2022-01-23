using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;

namespace LoginSystem
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Button buttonLogin;
        private Button buttonSignUp;
        private Dialog signUpDialog;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            buttonSignUp = FindViewById<Button>(Resource.Id.sign_up_button);
            buttonSignUp.Click += buttonShowUp_click;
        }

        private void buttonShowUp_click(object sender, EventArgs e)
        {
            signUpDialog = new Dialog(this);
            signUpDialog.SetContentView(Resource.Layout.fragment_dialog);
            signUpDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            signUpDialog.Show();
        }
    }
}