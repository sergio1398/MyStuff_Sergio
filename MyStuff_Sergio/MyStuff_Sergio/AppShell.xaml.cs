using MyStuff_Sergio.ViewModels;
using MyStuff_Sergio.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace MyStuff_Sergio
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
