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
    public partial class EditarSupplierPage : ContentPage
    {

        SupplierViewModel SupplierVM;

        public EditarSupplierPage()
        {
            InitializeComponent();
            SupplierVM = new SupplierViewModel();
        }

        private bool ValidarCamposNull()
        {

            if (TxtSupplierId.Text != null &&
                TxtSupplierName.Text != null &&
                TxtSupplierPhone.Text != null &&
                TxtSupplierEmail.Text != null &&
                TxtUserId.Text != null)
            {

                return true;
            }

            return false;

        }

        private bool ValidarCamposVacios()
        {

            if (!string.IsNullOrEmpty(TxtSupplierId.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtSupplierName.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtSupplierPhone.Text.Trim()) &&
                !string.IsNullOrEmpty(TxtSupplierEmail.Text.Trim()) &&
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
                int SupplierId = Convert.ToInt32(TxtSupplierId.Text.Trim());

                int UserId = Convert.ToInt32(TxtUserId.Text.Trim());

                bool R = await SupplierVM.EditarMySupplier(SupplierId, TxtSupplierName.Text.Trim(), TxtSupplierPhone.Text.Trim(), TxtSupplierEmail.Text.Trim(), UserId);

                if (R)
                {

                    //await DisplayAlert("Éxito", "La marca se ha agregado adecuadamente", "OK");
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

        private async void BtnEliminarSupplier_Clicked(object sender, EventArgs e)
        {


            if (ValidarCamposNull() && ValidarCamposVacios())
            {
                int SupplierId = Convert.ToInt32(TxtSupplierId.Text.Trim());

                bool R = await SupplierVM.EliminarMySupplier(SupplierId);

                if (R)
                {

                    //await DisplayAlert("Éxito", "La marca se ha agregado adecuadamente", "OK");
                    await Navigation.PopAsync();

                }
                else
                {
                    await DisplayAlert("Error", "La marca no se ha eliminado", "OK");
                }

            }


        }
    }
}