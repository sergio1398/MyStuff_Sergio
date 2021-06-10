using MyStuff_Sergio.Services;
using MyStuff_Sergio.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStuff_Sergio
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
