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
    public partial class EditarItemLocalizationPage : ContentPage
    {
        ItemLocalizationViewModel ItemLocalizationVM;

        public EditarItemLocalizationPage()
        {
            InitializeComponent();
            ItemLocalizationVM = new ItemLocalizationViewModel();
        }

        private bool ValidarCamposVacios()
        {

            if (!string.IsNullOrEmpty(TxtItemLocalizationId.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtLocalization.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUserId.Text.Trim()))
            {
                return true;
            }

            return false;

        }


        private bool ValidarCamposNull()
        {

            if (TxtItemLocalizationId.Text != null &&
                TxtLocalization.Text != null &&
                TxtUserId.Text != null)
            {

                return true;
            }

            return false;

        }




        private async void BtnGuardarItemLocalization_Clicked(object sender, EventArgs e)
        {

            if (ValidarCamposNull() && ValidarCamposVacios())
            {
                int ItemLocalizationId = Convert.ToInt32(TxtItemLocalizationId.Text.Trim());

                int UserId = Convert.ToInt32(TxtUserId.Text.Trim());

                bool R = await ItemLocalizationVM.EditarItemLocallizacion(ItemLocalizationId, TxtLocalization.Text.Trim(), UserId);

                if (R)
                {
                    await DisplayAlert("Éxito", "La categoría del item se ha agregado adecuadamente", "OK");
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Error", "La categoría del item no se ha agregado adecuadamente", "OK");
                }


            }
            else
            {
                await DisplayAlert("Error", "Los campos no pueden estar vacios, por favor digite los datos", "OK");
            }

        }


        private async void BtnEliminarItemLocalization_Clicked(object sender, EventArgs e)
        {

            if (ValidarCamposNull() && ValidarCamposVacios())
            {
                int ItemLocalizationId = Convert.ToInt32(TxtItemLocalizationId.Text.Trim());


                bool R = await ItemLocalizationVM.EliminarItemLocalizacion(ItemLocalizationId);

                if (R)
                {
                    await DisplayAlert("Éxito", "La localización se ha eliminado adecuadamente", "OK");
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Error", "La localización no se ha eliminado adecuadamente", "OK");
                }


            }

        }



    }
}