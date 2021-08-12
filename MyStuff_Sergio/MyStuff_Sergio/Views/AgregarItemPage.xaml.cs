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
    public partial class AgregarItemPage : ContentPage
    {

        public ItemViewModel MiItemVM { get; set; }

        public int BrandId { get; set; }

        public int ItemCategoryId { get; set; }

        public int LocalizacionItemId { get; set; }

        public int ProveedorId { get; set; }

        public int MonedaID { get; set; }

        public AgregarItemPage()
        {
            InitializeComponent();

            MiItemVM = new ItemViewModel();

            BindingContext = MiItemVM = new ItemViewModel();

            CboMarca.ItemsSource = MiItemVM.MyBrands;

        }

        private void BtnCancelar_Clicked(object sender, EventArgs e)
        {

        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {


            int Costo = Convert.ToInt32(TxtCosto.Text.Trim());

            decimal Depreciacion = Convert.ToInt32(TxtDepreciacion.Text.Trim());

            bool R = await MiItemVM.GurdarItem(TxtNombre.Text.Trim(), TxtDescripcion.Text.Trim(), Costo, TxtSerie.Text.Trim(),
                                               TxtNumeroFactura.Text.Trim(), Depreciacion,
                                               BrandId, ItemCategoryId, LocalizacionItemId, ProveedorId, MonedaID, TxtImagenItem.Text.Trim());

            if (R)
            {

                await DisplayAlert("Éxito", "La marca se ha agregado adecuadamente", "OK");
                await Navigation.PopAsync();

            }
            else
            {
                await DisplayAlert("Error", "La marca no se ha agregado adecuadamente", "OK");
            }


        }

        private void CboMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Brand selectedItem = CboMarca.SelectedItem as Brand;
            BrandId = selectedItem.BrandId;

        }

        private void CboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemCategory SelectedItem = CboCategoria.SelectedItem as ItemCategory;
            ItemCategoryId = SelectedItem.ItemCategoryId;
           
        }

        private void CboLocalizacionItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ItemLocalization SelectedItem = CboLocalizacionItem.SelectedItem as ItemLocalization;
            LocalizacionItemId = SelectedItem.ItemLocalizationId;
            
        }

        private void CboProveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            Supplier SelectedItem = CboProveedor.SelectedItem as Supplier;
            ProveedorId = SelectedItem.SupplierId;

        }

        private void CboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            Currency SelectedItem = CboCurrency.SelectedItem as Currency;
            MonedaID = SelectedItem.CurrencyId;
        }
    }


}