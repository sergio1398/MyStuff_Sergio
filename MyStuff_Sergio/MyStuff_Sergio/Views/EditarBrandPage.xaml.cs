using MyStuff_Sergio.ViewModels;
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
    public partial class EditarBrandPage : ContentPage
    {

        public BrandViewModel VmBrand { get; set; }

        public EditarBrandPage()
        {
            InitializeComponent();
            VmBrand = new BrandViewModel();

           // LstItems.ItemsSource = VmItem.ListarItems();
        }

        private bool ValidarCamposVacios()
        {

            if (!string.IsNullOrEmpty(TxtBrandId.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtBrandName.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUserId.Text.Trim()) )
            {
                return true;
            }

            return false;

        }


        private bool ValidarCamposNull()
        {

            if (TxtBrandId.Text != null &&
                TxtBrandName.Text != null &&
                TxtUserId.Text != null )
            {

                return true;
            }

            return false;

        }





        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {

            if (ValidarCamposNull() && ValidarCamposVacios() )
            {
                int BrandId = Convert.ToInt32(TxtBrandId.Text.Trim());

                int UserId = Convert.ToInt32(TxtUserId.Text.Trim());

                bool R = await VmBrand.EditarBrand(BrandId, TxtBrandName.Text.Trim(), UserId);

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
            else
            {
                await DisplayAlert("Error", "Los campos no pueden estar vacios, por favor digite los datos", "OK");
            }

        }

        private async void BtnEliminar_Clicked(object sender, EventArgs e)
        {
            if (ValidarCamposNull() && ValidarCamposVacios())
            {
                int BrandId = Convert.ToInt32(TxtBrandId.Text.Trim());


                bool R = await VmBrand.EliminarBrand(BrandId);

                if (R)
                {
                    await DisplayAlert("Éxito", "La marca se ha eliminado adecuadamente", "OK");
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Error", "La marca no se ha eliminado adecuadamente", "OK");
                }


            }


           
        }
    }
}