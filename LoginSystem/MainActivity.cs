using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using Java.Lang;

namespace LoginSystem
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]

    public class SignUpCredentialsEventArgs : EventArgs
    {
        private string FirstName { get; set; }
        private string Email { get; set; }
        private string Password { get; set; }

        public SignUpCredentialsEventArgs(string firstName, string email, string password)
        {
            FirstName = firstName;
            Email = email;
            Password = password;
        }
    }
    public class MainActivity : AppCompatActivity
    {
        private Button _buttonLogin;
        private Button _buttonSignUp;
        private Dialog _signUpDialog;

        private Button _buttonSignUpDialog;

        private EditText _editTextFirstName;
        private EditText _editTextEmail;
        private EditText _editTextPassword;

        private ProgressBar _progressBar;

        private event EventHandler<SignUpCredentialsEventArgs> OnSignUpComplete;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            _buttonSignUp = FindViewById<Button>(Resource.Id.sign_up_button);
            _progressBar = FindViewById<ProgressBar>(Resource.Id.progressBar_progressbar);
            _buttonSignUp.Click += OnButtonSignUpClick;
        }

        private void OnButtonSignUpClick(object sender, EventArgs e)
        {

            _signUpDialog = new Dialog(this);

            _editTextFirstName = _signUpDialog.FindViewById<EditText>(Resource.Id.first_name_edittext);
            _editTextEmail = _signUpDialog.FindViewById<EditText>(Resource.Id.email_edittext);
            _editTextPassword = _signUpDialog.FindViewById<EditText>(Resource.Id.password_edittext);
            _buttonSignUpDialog = _signUpDialog.FindViewById<Button>(Resource.Id.sign_up_dialog_button);

            _signUpDialog.SetContentView(Resource.Layout.fragment_dialog);
            _signUpDialog.Window.SetSoftInputMode(SoftInput.AdjustResize);
            _signUpDialog.Show();


            _buttonSignUpDialog.Click += ButtonSignUpDialog_Click;
            OnSignUpComplete += (o, args) =>
            {
                _progressBar.Visibility = ViewStates.Visible;
                Thread thread = new Thread(ActionRequest);
                thread.Start();
            };
        }

        private void ActionRequest()
        {
            Thread.Sleep(3000);

            RunOnUiThread(() => { _progressBar.Visibility = ViewStates.Invisible; });
        }

        private void ButtonSignUpDialog_Click(object sender, EventArgs e)
        {
            OnSignUpComplete.Invoke(this, new SignUpCredentialsEventArgs(_editTextFirstName.Text, _editTextEmail.Text, _editTextPassword.Text));
            _signUpDialog.Hide();
        }
    }
}