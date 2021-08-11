using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyStuff_Sergio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SelectorAccionPage : ContentPage
    {
        public SelectorAccionPage()
        {
            InitializeComponent();
        }

        private async void BtnAgregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarItemPage());
        }

        private async void BtnVerActivos_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListaItemsPage());
        }

        private void BtnConfiguracion_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnSalir_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void BtnMarcas_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new MarcasPage());

        }

        private async void BtnCategoria_Clicked(object sender, EventArgs e)
        {

            await Navigation.PushAsync(new ItemCategoryPage());

        }

        private async void BtnLocalizacion_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ItemLocalizationPage());
        }

        private async void BtnProveedores_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SupplierPage());
        }
    }
}