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
    public partial class RegistroPage : ContentPage
    {

        UserViewModel UsuarioVM;

        public RegistroPage()
        {
            InitializeComponent();

            BindingContext = UsuarioVM = new UserViewModel();

        }

        private async void CmdCancelar(object sender, EventArgs e)
        {
            _ = await Navigation.PopAsync();
        }

        private async void CmdAceptar(object sender, EventArgs e)
        {
            bool R = await UsuarioVM.GuardarUsuario(TxtUsuario.Text.Trim(),TxtNombreUsuario.Text.Trim(), TxtPassword.Text.Trim(), NumeroTelefono.Text.Trim(),TxtBackUpEmail.Text.Trim());

            if (R = true)
            {
                await DisplayAlert("Aviso", "Usuario agregado correctamente", "OK");

                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Aviso", "Error el usuario no se agregó", "OK");
            }


        }
    }
}