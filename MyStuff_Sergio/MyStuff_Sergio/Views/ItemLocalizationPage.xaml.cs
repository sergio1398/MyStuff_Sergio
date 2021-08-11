using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyStuff_Sergio.ViewModels;
using MyStuff_Sergio.Models;

namespace MyStuff_Sergio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemLocalizationPage : ContentPage
    {

        public ItemLocalizationViewModel MyItemLocalization { get; set; }

        public ItemLocalizationPage()
        {
            InitializeComponent();
            BindingContext = MyItemLocalization = new ItemLocalizationViewModel();

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LstItemLocalización.ItemsSource = MyItemLocalization.GetItemLocalization();
        }

        private async void BtnAgregarItemLocalization_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarItemLocalizationPage());
        }

        private async void LstItemLocalización_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            ItemLocalization MyItemLocalization = e.Item as ItemLocalization;
            EditarItemLocalizationPage EditarLocalization = new EditarItemLocalizationPage();
            EditarLocalization.BindingContext = MyItemLocalization;
            await Navigation.PushAsync(EditarLocalization);

        }
    }
}