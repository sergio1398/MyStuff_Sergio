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
    public partial class EditarItemCategoryPage : ContentPage
    {
        ItemCategoryViewModel MyItemCategoryVM;
        
        public EditarItemCategoryPage()
        {
            InitializeComponent();
            MyItemCategoryVM = new ItemCategoryViewModel();
        }

        private bool ValidarCamposVacios()
        {

            if (!string.IsNullOrEmpty(TxtItemCategoryId.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtCategory.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtUserId.Text.Trim()))
            {
                return true;
            }

            return false;

        }


        private bool ValidarCamposNull()
        {

            if (TxtItemCategoryId.Text != null &&
                TxtCategory.Text != null &&
                TxtUserId.Text != null)
            {

                return true;
            }

            return false;

        }

        private async void BtnEliminarItemCategory_Clicked(object sender, EventArgs e)
        {
            if (ValidarCamposNull() && ValidarCamposVacios())
            {
                int ItemCategoryId = Convert.ToInt32(TxtItemCategoryId.Text.Trim());


                bool R = await MyItemCategoryVM.EliminarItemCategoria(ItemCategoryId);

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

        private async void BtnGuardarItemCategory_Clicked(object sender, EventArgs e)
        {
            if (ValidarCamposNull() && ValidarCamposVacios())
            {
                int ItemCategoryId = Convert.ToInt32(TxtItemCategoryId.Text.Trim());

                int UserId = Convert.ToInt32(TxtUserId.Text.Trim());

                bool R = await MyItemCategoryVM.EditarItemCategoria(ItemCategoryId, TxtCategory.Text.Trim(), UserId);

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











    }
}