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
    public partial class MarcasPage : ContentPage
    {
        BrandViewModel MyBrandVM;

        public MarcasPage()
        {
            InitializeComponent();
            BindingContext = MyBrandVM = new BrandViewModel();
          
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
            LstMarcas.ItemsSource = MyBrandVM.ObtenerMarcas();
        }


        private void LstMarcas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
           
            Brand brand = e.Item as Brand;
            EditarBrandPage editarBrandPage = new EditarBrandPage();
            editarBrandPage.BindingContext = brand;
            Navigation.PushAsync(editarBrandPage);


        }

        private void BtnAgregarBrand_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AgregarBrandPage());
        }
    }
}