using Syncfusion.XForms.Chat;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GettingStarted
{
    public partial class App : Application
    {
        SfChat sfChat;
        public App()
        {
            InitializeComponent();

            SfChat sfChat = new SfChat();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
