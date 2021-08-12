using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyStuff_Sergio.ViewModels;

namespace MyStuff_Sergio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarBrandPage : ContentPage
    {

        BrandViewModel MyBrandVM;

        public AgregarBrandPage()
        {
            InitializeComponent();
            MyBrandVM = new BrandViewModel();
        }

        private bool ValidarCamposNull()
        {

            if (TxtBrandName.Text != null &&
                TxtUserId.Text != null)
            {

                return true;
            }

            return false;

        }

        private bool ValidarCamposVacios()
        {

            if (!string.IsNullOrEmpty(TxtBrandName.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUserId.Text.Trim()) )
            {
                return true;
            }

            return false;

        }

        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {


            if (ValidarCamposNull() && ValidarCamposVacios())
            {
                //int UserId = Convert.ToInt32(TxtUserId.Text.Trim());

                bool R = await MyBrandVM.GurdarBrand(TxtBrandName.Text.Trim(), ObjetosGlobales.MiUsusarioGlobal.UserId);

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
    }
}