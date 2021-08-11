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
    public partial class AgregarItemLocalizationPage : ContentPage
    {

        ItemLocalizationViewModel ItemLocalizationVM;

        public AgregarItemLocalizationPage()
        {
            InitializeComponent();
            ItemLocalizationVM = new ItemLocalizationViewModel();
        }

        private bool ValidarCamposNull()
        {

            if (TxtLocalization.Text != null &&
                TxtUserId.Text != null)
            {

                return true;
            }

            return false;

        }

        private bool ValidarCamposVacios()
        {

            if (!string.IsNullOrEmpty(TxtLocalization.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUserId.Text.Trim()))
            {
                return true;
            }

            return false;
        }


        private async void BtnGuardar_Clicked(object sender, EventArgs e)
        {

            if (ValidarCamposNull() && ValidarCamposVacios())
            {
                int UserId = Convert.ToInt32(TxtUserId.Text.Trim());

                bool R = await ItemLocalizationVM.GurdarItemLocalizacion(TxtLocalization.Text.Trim(), UserId);

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