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
    public partial class SupplierPage : ContentPage
    {

        SupplierViewModel SupplierVM;

        public SupplierPage()
        {
            InitializeComponent();

            BindingContext = SupplierVM = new SupplierViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            LstSupplier.ItemsSource = SupplierVM.GetSuppliersVM();
        }

        private async void BtnAgregarSupplier_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarSupplierPage());
        }

        private void LstSupplier_ItemTapped(object sender, ItemTappedEventArgs e)
        {

            Supplier MySupplier = e.Item as Supplier;
            EditarSupplierPage MyEditarSupplierPage = new EditarSupplierPage();
            MyEditarSupplierPage.BindingContext = MySupplier;
            Navigation.PushAsync(MyEditarSupplierPage); 

        }
    }
}